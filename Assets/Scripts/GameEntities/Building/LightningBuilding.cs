using UnityEngine;

namespace Obscurity
{
    public class LightningBuilding : Building
    {
        public int Fuel;
        [SerializeField] private GameObject _lightSourceGameObject;

        public override void Iteract(Player player) => _lightSourceGameObject.SetActive(!_lightSourceGameObject.activeInHierarchy);
    }
}