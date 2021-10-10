using UnityEngine;

namespace Obscurity
{
    [CreateAssetMenu]
    public class ItemTemplate : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public ItemGameObject GameObject;
    }
}