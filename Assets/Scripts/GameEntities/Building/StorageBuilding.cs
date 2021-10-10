using System.Collections.Generic;
using UnityEngine;

namespace Obscurity
{
    public class StorageBuilding : Building, IStorage
    {
        public List<Item> Items { get; set; }
        public int MaxItems { get; set; }
        public bool IsLocked { get; set; }

        private void Awake()
        {
            Items = new List<Item>();
        }

        public override void Iteract(Player player)
        {
            Open(player);
        }

        private void Open(Player player)
        {
            //ActionsLogger.Instance.Log("Opened");
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}