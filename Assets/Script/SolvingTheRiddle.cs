using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SolvingTheRiddle : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Text _notCorrected;
    [SerializeField] GameObject _enabledItem;
    Collider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<Collider>();
    }

    public void SelectedItem()
    {
        switch(this.name)
        {
            case "Cushion":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.Scissors))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    if (!_audioSource.isPlaying)
                        _audioSource.PlayOneShot(_audioSource.clip);
                    Item _itemData = ItemDataBaseScript.Instance.Spawn(Item.Type.Gloves);
                    ItemBoxScript.instance.SetItem(_itemData);
                    StartCoroutine(DelayGlovesText());
                    this._collider.enabled = false;
                }
                else
                { StartCoroutine(DelayCoroutine()); }
                break;

            case "Fire":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.BucketFullOfWater))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    if (!_audioSource.isPlaying)
                        _audioSource.PlayOneShot(_audioSource.clip);
                    Item _itemData = ItemDataBaseScript.Instance.Spawn(Item.Type.Bucket);
                    ItemBoxScript.instance.SetItem(_itemData);
                    StartCoroutine(DelayFire());
                }
                else
                { StartCoroutine(DelayCoroutine()); } 
                break;

            case "Water":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.Bucket))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    Item _itemData = ItemDataBaseScript.Instance.Spawn(Item.Type.BucketFullOfWater);
                    ItemBoxScript.instance.SetItem(_itemData);
                    if (!_audioSource.isPlaying)
                        _audioSource.PlayOneShot(_audioSource.clip);
                }
                else
                { StartCoroutine(DelayCoroutine()); }
                break;

            case "Aquarium":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.BucketFullOfWater))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    Item _itemData = ItemDataBaseScript.Instance.Spawn(Item.Type.Bucket);
                    ItemBoxScript.instance.SetItem(_itemData);
                    Animator _aqAnim = GameObject.Find("AquariumWater").GetComponent<Animator>();
                    _aqAnim.SetBool("WaterIn", true);
                    StartCoroutine(DelayEnabledReeds());
                    if (!_audioSource.isPlaying)
                        _audioSource.PlayOneShot(_audioSource.clip);
                    this._collider.enabled = false;
                    this.tag = "Untagged";
                }
                else
                { StartCoroutine(DelayCoroutine()); }
                break;

            case "ScissorsBox":
                transform.Find("ReedsCanvas").gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;

            case "Box":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.Stick))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    GetComponent<Animator>().SetBool("FallBox", true);
                    StartCoroutine(DelayFallBoxSound());
                }
                else
                    { StartCoroutine(DelayCoroutine()); } 
                break;

            case "ExitKeyBox":
                transform.Find("BirthDayCanvas").gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;

            case "Graffiti":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.Towel))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    if (!_audioSource.isPlaying)
                        _audioSource.PlayOneShot(_audioSource.clip);
                    StartCoroutine(DelayGraffiti());
                }
                else
                    { StartCoroutine(DelayCoroutine()); }
                break;

            case "DrawerTop":
                transform.Find("AlphabetCanvas").gameObject.SetActive(true);
                Cursor.lockState= CursorLockMode.None;
                Cursor.visible = true;
                break;
        }
    }

    IEnumerator DelayCoroutine()
    {
        _notCorrected.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _notCorrected.gameObject.SetActive(false);
    }

    IEnumerator DelayFire()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
        _enabledItem.gameObject.SetActive(true);
    }

    IEnumerator DelayEnabledReeds()
    {
        yield return new WaitForSeconds(1.7f);
        GameObject _reeds = transform.Find("Reeds").gameObject;
        _reeds.SetActive(true);
    }

    IEnumerator DelayGlovesText()
    {
        Canvas _canvas = GameObject.Find("GlovesCanvas").GetComponent<Canvas>();
        Text _text = _canvas.transform.Find("GlovesText").GetComponent<Text>();
        _text.text = "’†‚É‚ÍŽè‘Ü‚ª“ü‚Á‚Ä‚¢‚½\nŽè‘Ü‚ðŽè‚É“ü‚ê‚½";
        _text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _text.gameObject.SetActive(false);
    }

    IEnumerator DelayFallBoxSound()
    {
        yield return new WaitForSeconds(2f);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
        _enabledItem.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }

    IEnumerator DelayGraffiti()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
