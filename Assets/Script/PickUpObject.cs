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
        Debug.Log("�A�C�e���Q�b�g");
        Item _itemData = ItemDataBaseScript.Instance.Spawn(_type);
        ItemBoxScript.instance.SetItem(_itemData);
        _text.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    IEnumerator DalayCoroutine()
    {
        Text _text = transform.Find("Canvas/Text").GetComponent<Text>();
        _text.text = "�M���Ď��Ȃ��B��܂̂悤�Ȃ��̂͂Ȃ�����";
        _text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _text.gameObject.SetActive(false);
    }
}
