using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAdder : MonoBehaviour
{
    [SerializeField] private List<ScriptableObjects.Item> _items;

    public void Start()
    {
        var storage = GetComponent<IStorage>();

        if (storage.Items == null)
            storage.Items = new List<Item>();


        _items.ForEach(item =>
        {
            var newItem = item is ScriptableObjects.Resources ? new Resources(item as ScriptableObjects.Resources) : new Item(item);
            storage.Items.Add(newItem);
        });
    }
}
