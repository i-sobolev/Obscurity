using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDataSaver : MonoBehaviour
{
    public UnityAction<string> OnDataLoaded;

    public static PlayerDataSaver Instance { get; private set; }

    private readonly string DataKey = "PlayerData";

    public API.PlayerController _apiPlayerController;
    
    public void Awake()
    {
        DontDestroyOnLoad(this);
        
        Instance = this;

        _apiPlayerController = new API.PlayerController();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(DataKey))
        {
            PostPlayerRequest("Player").Start(this);
        }

        else
        {
            var json = PlayerPrefs.GetString(DataKey);
            var savedPlayerData = JsonUtility.FromJson<PlayerViewModel>(json);

            PlayerData.Values = new PlayerViewModel() { id = savedPlayerData.id, name = savedPlayerData.name, worldId = savedPlayerData.worldId };

            OnDataLoaded?.Invoke(savedPlayerData.name);
        }
    }

    public void ChangeNickName(string newName) => ChangeNicknameRequest(newName).Start(this);

    private IEnumerator PostPlayerRequest(string name)
    {
        yield return PostPlayer(name).Start(this);
        
        SaveData();
    }

    private IEnumerator ChangeNicknameRequest(string newName)
    {
        yield return _apiPlayerController.Put(newName).Start(this);
        PlayerData.Values.name = newName;

        SaveData();

        OnDataLoaded(newName);
        
        Debug.Log($"Nickname changer: {newName}");
    }

    public void SaveData()
    {
        PlayerPrefs.SetString(DataKey, JsonUtility.ToJson(PlayerData.Values));
        PlayerPrefs.Save();
    }

    private IEnumerator PostPlayer(string name)
    {
        yield return _apiPlayerController.Post(name);

        OnDataLoaded(name);

        PlayerData.Values = _apiPlayerController.RequestResult;
    }
}