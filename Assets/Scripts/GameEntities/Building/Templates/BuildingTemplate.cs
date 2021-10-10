using UnityEngine;

namespace Obscurity
{
    [CreateAssetMenu]
    public class BuildingTemplate : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public Building GameObject;
        public RequiredResource[] RequiredResources;
    }
}