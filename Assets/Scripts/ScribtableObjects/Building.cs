using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class Building : ScriptableObject
    {
        public global::Building BuildingTemplate;
        public Sprite Icon;
        public string Name;
        public RequiredResources[] RequiredResources;
    }

    [System.Serializable]
    public struct RequiredResources
    {
        public ResoucesType ResoucesType;
        public int Amount;
    }
}