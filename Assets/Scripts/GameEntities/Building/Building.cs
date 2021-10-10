using UnityEngine;

namespace Obscurity
{
    [System.Serializable]
    public class Building : MonoBehaviour, IIteractable
    {
        public virtual void Iteract(Player player) { }
    }
}