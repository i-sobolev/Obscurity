using UnityEngine;

namespace Obscurity.UI
{
    public class JournalSwitcher : Singleton<JournalSwitcher>
    {
        public bool IsOpened { get; private set; }

        [SerializeField] private GameObject _journalGameObject = null;

        private Journal _journal;

        #pragma warning disable
        private void Awake()
        {
            base.Awake();
            _journal = _journalGameObject.GetComponent<Journal>();
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
                SwitchJournal();
        }

        public void SwitchJournal() => _journalGameObject.SetActive(!_journalGameObject.activeInHierarchy);

        public void OpenJournal() => _journalGameObject.SetActive(true);

        public void CloseJournal() => _journalGameObject.SetActive(false);

        public void OpenJournal(TabType tabType)
        {
            OpenJournal();

            _journal.ShowTab(tabType);
        }
    }
}