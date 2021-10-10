using UnityEngine;

namespace Obscurity
{
    public class Item
    {
        public string Name;
        public Sprite Icon;
        public ItemGameObject GameObject;

        public Item(ItemTemplate itemReference)
        {
            Name = itemReference.Name;
            Icon = itemReference.Icon;
            GameObject = itemReference.GameObject;
        }
    }
}