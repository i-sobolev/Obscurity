using Obscurity.UI;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Obscurity
{
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

        public bool CheckResources(RequiredResource[] requiredResources)
        {
            foreach (var resources in requiredResources)
                if (CheckResource(resources.ResourceType, resources.Amount))
                    return false;

            return true;
        }

        public bool CheckResource(ResouceType resouceType, int requiredAmount)
        {
            foreach (var item in Items)
            {
                if (item is Resource resources)
                {
                    var isRequiredType = resources.ResourceType.Equals(resouceType);
                    var isRequiredAmount = resources.Amount >= requiredAmount;
                    
                    if (isRequiredAmount && isRequiredType)
                        return true;
                }
            }

            return false;
        }

        public void RemoveResources(RequiredResource[] requiredResources)
        {
            var itemsToRemove = new List<Item>();

            foreach (var requiredResource in requiredResources)
            {
                RemoveResource(requiredResource);
            }

            itemsToRemove.ForEach(item => RemoveItem(item));
        }

        public void RemoveResource(RequiredResource requiredResource)
        {
            foreach (var item in Items)
            {
                if (item is Resource resources)
                {
                    var isRequiredType = resources.ResourceType.Equals(requiredResource.ResourceType);
                    var isRequiredAmount = resources.Amount >= requiredResource.Amount;

                    if (isRequiredType && isRequiredAmount)
                    {
                        resources.Amount -= requiredResource.Amount;

                        if (resources.Amount == 0)
                            RemoveItem(item);

                        break;
                    }
                }
            }
        }
    }
}