using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    public Item.Type _type = default;
    [SerializeField] Text _text = null;
    public void OnItemPickUp()
    {
        if (this.name == "ClosetKey")
        {
            if (ItemBoxScript.instance.CheckedSelectedItem(Item.Type.Gloves))
            {
                ItemBoxScript.instance.UsedSelectedItem();
            }
            else
            {
                StartCoroutine(DalayCoroutine());
                return;
            }
        }
        Debug.Log("アイテムゲット");
        Item _itemData = ItemDataBaseScript.Instance.Spawn(_type);
        ItemBoxScript.instance.SetItem(_itemData);
        _text.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    IEnumerator DalayCoroutine()
    {
        Text _text = transform.Find("Canvas/Text").GetComponent<Text>();
        _text.text = "熱くて取れない。手袋のようなものはないかな";
        _text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _text.gameObject.SetActive(false);
    }
}
