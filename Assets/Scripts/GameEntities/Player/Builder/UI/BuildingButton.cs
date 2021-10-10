using System;
using UnityEngine;
using UnityEngine.UI;

namespace Obscurity.UI
{
    public class BuildingButton : MonoBehaviour
    {
        public Action<BuildingTemplate> Clicked;

        [Header("References")]
        [SerializeField] private Button _buttonComponent;
        [Header("UI elements")]
        [SerializeField] private Text _name;
        [SerializeField] private Image _icon;
        
        private BuildingTemplate _linkedBuilding;

        public void SetData(BuildingTemplate building)
        {
            _linkedBuilding = building;
            
            _icon.sprite = building.Icon;
            _name.text = building.Name;

            _buttonComponent.onClick.AddListener(OnClick);
        }

        private void OnClick() => Clicked?.Invoke(_linkedBuilding);
    }
}