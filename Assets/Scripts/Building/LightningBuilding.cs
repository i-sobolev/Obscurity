using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBuilding : Building
{
    public int Fuel;
}

[System.Serializable]
public class LightningViewModel
{
    public int Id;
    public int Fuel;
}