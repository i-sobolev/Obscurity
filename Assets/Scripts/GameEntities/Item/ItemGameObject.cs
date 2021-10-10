using UnityEngine;

namespace Obscurity
{
    public class ItemGameObject : MonoBehaviour, IIteractable
    {
        [SerializeField] private ItemTemplate _itemReference;

        [HideInInspector] public Item Item;

        private void Awake()
        {
            if (Item == null && _itemReference != null)
                Item = _itemReference is ResourcesTemplate ? new Resource(_itemReference as ResourcesTemplate) : new Item(_itemReference);
        }

        public void Iteract(Player player)
        {
            Destroy(gameObject);
        }
    }
}