using System;
using UnityEngine;

[Serializable]
public class Item
{
    /// <summary>
    /// �A�C�e���{�b�N�X�ɓ����A�C�e���͂����ŕ��ޕ�������
    /// </summary>
    public enum Type
    {
        Exitkey,
        InHouseKey,
        ClosetKey,
        Scissors,
        Bucket,
        BucketFullOfWater,
        Gloves,
        Stick,
        Towel,
    }

    public Type _type;
    public Sprite _sprite;
    public String _name;

    public Item(Item _item)
    {
        this._type = _item._type;
        this._sprite = _item._sprite;
        this._name = _item._name;
    }
}