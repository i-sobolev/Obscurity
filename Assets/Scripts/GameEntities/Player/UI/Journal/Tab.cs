using UnityEngine;
using UnityEngine.UI;

namespace Obscurity.UI
{
    public class Tab : MonoBehaviour
    {
        [HideInInspector] public Journal Journal;
        public Button LinkedButton;
        public TabType TabName;
    }

    public enum TabType { Builder, Inventory }
}