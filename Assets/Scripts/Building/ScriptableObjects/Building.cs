﻿using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class Building : ScriptableObject
    {
        public global::Building BuildingTemplate;
        public Image Icon;
        public string Name;
    }
}