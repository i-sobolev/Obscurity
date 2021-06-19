using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    public ScriptableObjects.Building Building { get; private set; }
    public UnityAction OnSelected;

    [SerializeField] private Text _buildingNameField;
    [SerializeField] private Text _requiredComponentsField;

    public void SetBuilding(ScriptableObjects.Building building)
    {
        Building = building;
        _buildingNameField.text = building.Name;
        _requiredComponentsField.text = "None";
    }

    public void Select()
    {
        Player.Instance.Build(Building.BuildingTemplate);
        OnSelected?.Invoke();
    }
}