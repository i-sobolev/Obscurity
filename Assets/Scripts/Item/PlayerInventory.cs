using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : Inventory
{
    public UnityAction<ItemGameObject> OnAddItem;
    public UnityAction<IStorage> OnStorageOpen;

    public void OpenStorage(IStorage storage)
    {
        JournalSwitcher.Instance.SwitchJournal();
        OnStorageOpen?.Invoke(storage);
    }

    public override void AddItem(ItemGameObject item)
    {
        base.AddItem(item);
        ActionsLogger.Instance.Log(item.Item.Name + " added to inventory.");

        OnAddItem?.Invoke(item);
    }
}