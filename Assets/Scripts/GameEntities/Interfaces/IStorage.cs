using System.Collections.Generic;

namespace Obscurity
{
    public interface IStorage : IIteractable
    {
        List<Item> Items { get; set; }
        int MaxItems { get; set; }
        bool IsLocked { get; set; }

        void RemoveItem(Item item);
        void AddItem(Item item);
    }
}