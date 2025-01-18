using UnityEngine;

public class ItemDataBaseScript : MonoBehaviour
{
    public static ItemDataBaseScript Instance;

    public void Awake()
    {
        Instance = this;
    }

    [SerializeField] ItemDataBaseEntity _itemDataBaseEntity = default;

    public Item Spawn(Item.Type _type)
    {
        for (int i = 0; i < _itemDataBaseEntity._items.Count; i++)
        {
            Item _itemData = _itemDataBaseEntity._items[i];
            if (_itemData._type == _type)
            {
                return new Item(_itemData);
            }
        }
        return null;
    }
}
