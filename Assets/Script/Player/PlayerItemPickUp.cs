using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickUp : MonoBehaviour
{
    [SerializeField] ItemSerch _itemSerch;
    [SerializeField] PickUpObject _pickUpObj;
   
    public void PlayerPickUpObj()
    {
        var _item = _itemSerch.GetNearItem();
        if (_item == null) return;
        if (_item.gameObject.activeSelf)
        {
            _pickUpObj = _item.gameObject.GetComponent<PickUpObject>();
            _pickUpObj.OnItemPickUp();
        }
        return;
    }
    private void Update()
    {
        if (Input.GetButtonDown("ItemPickUp"))
        {
            PlayerPickUpObj();
        }
    }
}
