using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDataBaseEntity : ScriptableObject
{
    public List<Item> _items = new List<Item>();
}
