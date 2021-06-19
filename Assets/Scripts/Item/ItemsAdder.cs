using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAdder : MonoBehaviour
{
    [SerializeField] private List<Item> _items;

    public void Start()
    {
        var storage = GetComponent<IStorage>();

        if (storage.Items == null)
            storage.Items = new List<Item>();

        storage.Items.AddRange(_items);
    }
}
