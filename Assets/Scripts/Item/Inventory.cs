using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IStorage
{
    public List<Item> Items { get; set; }
    public int MaxItems { get; set; }
    public bool IsLocked { get; set; }

    private void Awake()
    {
        IsLocked = true;
        MaxItems = 20;
        Items = new List<Item>();
    }

    public void Iteract(Player player)
    {
        if (IsLocked)
        {
            ActionsLogger.Instance.Log("Locked");
            return;
        }    
    }

    public virtual void AddItem(ItemGameObject item)
    {
        Items.Add(item.Item);
    }

    public virtual void DropItem(Item item)
    {
        Instantiate(item.Model, transform.position, Quaternion.identity);
        Items.Remove(item);
    }
}