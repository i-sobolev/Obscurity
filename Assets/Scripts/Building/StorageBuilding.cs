using System.Collections.Generic;
using UnityEngine;

public class StorageBuilding : Building, IStorage
{
    public List<Item> Items { get; set; }
    public int MaxItems { get; set; }
    public bool IsLocked { get; set; }

    private void Awake()
    {
        Items = new List<Item>();
    }

    public void Iteract(Player player)
    {
        player.Inventory.OpenStorage(this);
        ActionsLogger.Instance.Log("Opened");
    }
}

[System.Serializable]
public class StorageViewModel
{
    public int id;
    public bool isLocked;
}