using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputField : MonoBehaviour
{
    public InputField InputField;

    private void Start()
    {
        PlayerDataSaver.Instance.OnDataLoaded += (name) => InputField.text = name;
        InputField.onEndEdit.AddListener(PlayerDataSaver.Instance.ChangeNickName);

        InputField.text = PlayerData.Values.name;
    }
}
