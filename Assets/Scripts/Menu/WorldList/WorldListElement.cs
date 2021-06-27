using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorldListElement : MonoBehaviour
{
    public UnityAction<int> OnJoinButtonClicked;

    [Header("UI elements")]
    [SerializeField] private Text _worldNameField;
    [SerializeField] private Text _numberOfPlayers;

    [SerializeField] private Button _playerNamesButton;
    [SerializeField] private Button _playerNamesCloseButton;
    [SerializeField] private Button _joinButton;
    
    [SerializeField] private RectTransform _playerNamesListRoot;

    private WorldViewModel _worldReference;

    public void SetWorldReference(WorldViewModel worldViewModel)
    {
        _worldReference = worldViewModel;
        
        SetData();

        _joinButton.onClick.AddListener(() => OnJoinButtonClicked(_worldReference.id));
    }

    public void ShowNamesList()
    {
        _playerNamesButton.gameObject.SetActive(false);
        _playerNamesListRoot.gameObject.SetActive(true);
        _playerNamesCloseButton.gameObject.SetActive(true);
    }

    public void HideNamesList()
    {
        _playerNamesButton.gameObject.SetActive(true);
        _playerNamesListRoot.gameObject.SetActive(false);
        _playerNamesCloseButton.gameObject.SetActive(false);
    }

    private void SetData()
    {
        _worldNameField.text = _worldReference.name;
        _numberOfPlayers.text = $"{_worldReference.playerNames.Length} players";

        SetPlayerNamesList(_worldReference.playerNames);

        if (PlayerData.Values != null && _worldReference.id == PlayerData.Values.worldId)
            _joinButton.gameObject.SetActive(false);
    }

    private void SetPlayerNamesList(string[] names)
    {
        var nameTemplate = _playerNamesListRoot.GetChild(0).GetComponent<Text>();

        foreach (var name in names)
        {
            var nameField = Instantiate(nameTemplate, _playerNamesListRoot);
            nameField.text = name;
        }

        Destroy(nameTemplate.gameObject);
    }
}

[System.Serializable]
public class WorldViewModel
{
    public int id;
    public string name;
    public string[] playerNames;
}