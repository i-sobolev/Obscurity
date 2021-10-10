using UnityEngine;
using UnityEngine.UI;

namespace Obscurity.UI
{
    public class Item : MonoBehaviour
    {
        public IStorage LinkedStorage;
        public Obscurity.Item ItemReference;
        public Button ButtonComponent;

        [SerializeField] private Image _icon;
        [SerializeField] private Text _resourcesAmount;

        public void Set(ref Obscurity.Item linkedItem, IStorage linkedStorage)
        {
            ItemReference = linkedItem;
            LinkedStorage = linkedStorage;

            _icon.sprite = linkedItem.Icon;

            if (ItemReference is Resource resources)
                SetResouresAmount(resources.Amount);
        }

        private void SetResouresAmount(int amount) => _resourcesAmount.text = amount.ToString();
    }
}