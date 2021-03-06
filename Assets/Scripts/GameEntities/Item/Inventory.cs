using System.Collections.Generic;
using UnityEngine;

namespace Obscurity
{
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
                //ActionsLogger.Instance.Log("Locked");
                return;
            }
        }

        public virtual void AddItem(Item item)
        {
            Items.Add(item);
        }

        public virtual void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public virtual void DropItem(Item item)
        {
            var droppedItem = Instantiate(item.GameObject, transform.position, Quaternion.identity);
            droppedItem.Item = item;

            Items.Remove(item);
        }
    }
}