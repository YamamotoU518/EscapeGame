using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBoxScript : MonoBehaviour
{
    [SerializeField] SlotScript[] _slots = default;
    public static ItemBoxScript instance;
    SlotScript _selectedSlot;

    public void Awake()
    {
        instance = this;
    }

    public void SetItem(Item _item)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            SlotScript _slot = _slots[i];
            if (_slot.IsEmpty())
            {
                _slot.Set(_item);
                break;
            }
        }
    }
    public void OnSlotClicked(int _position)
    {
        if (_slots[_position].IsEmpty())
        {
            return;
        }
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].HideBackPanel();
        }
        _slots[_position].OnSelect();
        _selectedSlot = _slots[_position];
    }
    public bool CheckedSelectedItem(Item.Type _usedItemType)
    {
        if (_selectedSlot == null)
        {
            return false;

        }
        if (_selectedSlot.GetItem()._type == _usedItemType)
        {
            return true;
        }
        return false;

    }

    public void UsedSelectedItem()
    {
        _selectedSlot.RemoveItem();
        _selectedSlot = null;
    }
}
