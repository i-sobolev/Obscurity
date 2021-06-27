using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : Inventory
{
    public UnityAction OnItemListChanged;
    public UnityAction<IStorage> OnStorageOpen;

    public void OpenStorage(IStorage storage)
    {
        JournalSwitcher.Instance.OpenJournal(TabType.Inventory);
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

    public bool CheckResouces(ResoucesType resoucesType, int requiredAmount)
    {
        foreach (var item in Items)
        {
            if (item is Resources resources)
            {
                if (resources.ResoucesType.Equals(resoucesType))
                    if (resources.Amount >= requiredAmount)
                        return true;
            }
        }

        return false;
    }

    public void RemoveResouces(ScriptableObjects.RequiredResources[] requiredResources)
    {
        var itemsToRemove = new List<Item>();

        foreach (var requiredResource in requiredResources)
        {
            foreach (var item in Items)
            {
                if (item is Resources resources)
                {
                    if (resources.ResoucesType.Equals(requiredResource.ResoucesType))
                    {
                        if (resources.Amount >= requiredResource.Amount)
                        {
                            resources.Amount -= requiredResource.Amount;

                            if (resources.Amount == 0)
                                itemsToRemove.Add(resources);

                            break;
                        }
                    }
                }
            }
        }

        itemsToRemove.ForEach(item => RemoveItem(item));
    }
}