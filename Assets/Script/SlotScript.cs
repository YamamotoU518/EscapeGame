using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [SerializeField] Image _image = default;
    [SerializeField] GameObject _backPanel = default;
    [SerializeField] Text _text = default;
    Item _item = null;

    private void Start()
    {
        _backPanel.SetActive(false);
    }

    public void Set(Item _item)
    {
        this._item = _item;
        _image.sprite = _item._sprite;
        _text.text = _item._name;
    }

    public void RemoveItem()
    {
        _item = null;
        _image.sprite = null;
        _text.text = null;
        HideBackPanel();
    }

    public Item GetItem()
    {
        return _item;
    }

    public bool IsEmpty()
    {
        if (_item == null)
        {
            return true;
        }
        return false;
    }

    public void OnSelect()
    {
        _backPanel.SetActive(true);
    }

    public void HideBackPanel()
    {
        _backPanel.SetActive(false);
    }
}
