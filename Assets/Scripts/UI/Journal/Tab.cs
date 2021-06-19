using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    [HideInInspector] public Journal Journal;
    public Button LinkedButton;
    public TabName TabName;
}

public enum TabName { Builder, Inventory }