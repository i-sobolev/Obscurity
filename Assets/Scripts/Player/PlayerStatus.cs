using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public List<Note> Notes;

    private void Start()
    {
        AddNote(new Note("Test note.", "Test note added"));
    }

    public void AddNote(Note note)
    {
        Notes.Add(note);

        //if (!string.IsNullOrEmpty(note.LogText))
        ActionsLogger.Instance.Log(note.LogText);
    }

}

[System.Serializable]
public struct Note
{
    public Note(string noteText, string logText) => (NoteText, LogText) = (noteText, logText);

    public string NoteText;
    public string LogText;
}