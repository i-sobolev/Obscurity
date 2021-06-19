using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _journalGameObject = null;
    public static JournalSwitcher Instance { get; private set; }

    private Journal _journal;

    private void Awake()
    {
        Instance = this;
        _journal = _journalGameObject.GetComponent<Journal>();
    }

    public void SwitchJournal() => _journalGameObject.SetActive(!_journalGameObject.activeInHierarchy);
    public void SwitchJournal(TabName tabName)
    {
        SwitchJournal();
        _journal.ShowTab(TabName.Inventory);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            SwitchJournal();
    }
}