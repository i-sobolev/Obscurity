using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : Inventory
{
    public UnityAction OnItemListChanged;
    public UnityAction<IStorage> OnStorageOpen;

    public void OpenStorage(IStorage storage)
    {
        JournalSwitcher.Instance.SwitchJournal();
        OnStorageOpen?.Invoke(storage);
    }

    public override void AddItem(Item item)
    {
        base.AddItem(item);
        ActionsLogger.Instance.Log(item.Name + " added to inventory.");

        OnItemListChanged?.Invoke();
    }

    public override void RemoveItem(Item item)
    {
        base.RemoveItem(item);
        ActionsLogger.Instance.Log(item.Name + " removed from inventory.");

        OnItemListChanged?.Invoke();
    }
}