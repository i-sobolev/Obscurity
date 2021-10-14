using System.Collections.Generic;
using UnityEngine;

namespace Obscurity.UI
{
    public class Journal : MonoBehaviour
    {
        public List<Tab> Tabs;

        private void OnEnable()
        {
            Tabs.ForEach(tab =>
            {
                tab.LinkedButton.onClick.AddListener(() => ShowTab(tab));
            });

            ShowTab(Tabs[0]);
        }

        public void ShowTab(Tab selectedTab) => Tabs.ForEach(tab => tab.gameObject.SetActive(tab == selectedTab));
        public void ShowTab(TabType tabType) => Tabs.ForEach(tab => tab.gameObject.SetActive(tab.TabName == tabType));
    }
}