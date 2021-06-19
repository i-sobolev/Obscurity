using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingSelector : MonoBehaviour
{
    [SerializeField] private BuildingButton _buttonTemplate = null;

    public UnityEvent OnBuildingSelected;

    public void Start()
    {
        World.Instance.BuildingTemlates.Buildings.ForEach(building => 
        {
            var buttonComponent = Instantiate(_buttonTemplate, transform);
            buttonComponent.SetBuilding(building);
            buttonComponent.OnSelected += OnBuildingSelected.Invoke;
        });
    }
}