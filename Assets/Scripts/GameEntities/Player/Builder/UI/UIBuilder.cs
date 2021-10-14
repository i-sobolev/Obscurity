using System;
using System.Collections.Generic;
using UnityEngine;

namespace Obscurity.UI
{
    public class UIBuilder : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Obscurity.Builder _builder;
        [SerializeField] private BuildingButton _buildingButtonTemplate;
        [Space]
        [SerializeField] private List<BuildingTemplate> _buildings;

        public void Awake()
        {
            InstantiateBuildingButtons();
        }

        private void InstantiateBuildingButtons()
        {
            _buildings.ForEach(building =>
            {
                var buttonComponent = Instantiate(_buildingButtonTemplate, transform);
                
                buttonComponent.SetData(building);
                buttonComponent.Clicked += _builder.Build;
            });
        }
    }
}