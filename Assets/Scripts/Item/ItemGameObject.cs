using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGameObject : MonoBehaviour, IIteractable
{
    [SerializeField] private ScriptableObjects.Item _itemReference;
    
    [HideInInspector] public Item Item;

    private void Awake()
    {
        if (Item == null && _itemReference != null)
            Item = _itemReference is ScriptableObjects.Resources ? new Resources(_itemReference as ScriptableObjects.Resources) : new Item(_itemReference);
    }

    public void Iteract(Player player)
    {
        player.Inventory.AddItem(Item);
        Destroy(gameObject);
    }
}