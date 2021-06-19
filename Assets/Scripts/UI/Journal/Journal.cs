using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public List<Tab> Tabs;


    private void OnEnable()
    {
        Tabs.ForEach(tab =>
        {
            tab.Journal = this;
            tab.LinkedButton.onClick.AddListener(() => ShowTab(tab));
        });

        ShowTab(Tabs[0]);
    }

    public void ShowTab(Tab selectedTab) => Tabs.ForEach(tab => tab.gameObject.SetActive(tab == selectedTab));
    public void ShowTab(TabName tabName) => Tabs.ForEach(tab => tab.gameObject.SetActive(tab.TabName == tabName));
}