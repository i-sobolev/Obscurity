using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSwitcher : MonoBehaviour
{
    public bool IsOpened { get; private set; }

    [SerializeField] private GameObject _journalGameObject = null;
    public static JournalSwitcher Instance { get; private set; }

    private Journal _journal;

    private void Awake()
    {
        Instance = this;
        _journal = _journalGameObject.GetComponent<Journal>();
    }

    public void SwitchJournal() => _journalGameObject.SetActive(!_journalGameObject.activeInHierarchy);

    public void OpenJournal() => _journalGameObject.SetActive(true);

    public void CloseJournal() => _journalGameObject.SetActive(false);

    public void OpenJournal(TabType tabType)
    {
        OpenJournal();

        _journal.ShowTab(tabType);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            SwitchJournal();
    }
}