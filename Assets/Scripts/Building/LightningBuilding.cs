using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBuilding : Building
{
    public int Fuel;
    [SerializeField] private GameObject _lightSourceGameObject;

    public override void Iteract(Player player) => _lightSourceGameObject.SetActive(!_lightSourceGameObject.activeInHierarchy);
}

[System.Serializable]
public class LightningViewModel
{
    public int Id;
    public int Fuel;
}