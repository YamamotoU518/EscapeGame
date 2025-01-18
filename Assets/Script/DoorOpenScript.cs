using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenScript : MonoBehaviour
{
    [SerializeField] Animator _anim = null;
    [SerializeField] Text _notCorrected = null;
    [SerializeField] AudioSource _audioSourse;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSourse = GetComponent<AudioSource>();
    }

    public void SelectedItem()
    {
        switch (this.name)
        {
            case "Door":
                if(ItemBoxScript.instance.CheckedSelectedItem(Item.Type.Exitkey))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    Open();
                }
                else
                {
                    StartCoroutine(DelayCoroutine());
                }
                break;

            case "DoorInhouse":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.InHouseKey))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    Open();
                }
                else
                {
                    StartCoroutine(DelayCoroutine());
                }
                break;

            case "Door.L":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.ClosetKey))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    GameObject _lockerDoor = GameObject.Find("Door.R");
                    _lockerDoor.gameObject.GetComponent<DoorOpenScript>().Open();
                    Open();
                }
                else
                {
                    StartCoroutine(DelayCoroutine());
                }
                break;

            case "Door.R":
                if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.ClosetKey))
                {
                    ItemBoxScript.instance.UsedSelectedItem();
                    GameObject _lockerDoor = GameObject.Find("Door.L");
                    _lockerDoor.gameObject.GetComponent<DoorOpenScript>().Open();
                    Open();
                }
                else
                {
                    StartCoroutine(DelayCoroutine());
                }
                break;

            case "ShowerRoomDoor":
                Open();
                break;

            case "ToiletDoor":
                Open();
                break;

            case "GlassDoor":
                Open();
                break;
        }
    }
    public void Open()
    {
        _anim.SetBool("DoorOpen", true);
        if (!_audioSourse.isPlaying)
        {
            _audioSourse.PlayOneShot(_audioSourse.clip);
        }
        this.GetComponent<DoorOpenScript>().enabled = false;
        this.tag = "Untagged";
    }

    IEnumerator DelayCoroutine()
    {
        _notCorrected.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _notCorrected.gameObject.SetActive(false);
    }
}
