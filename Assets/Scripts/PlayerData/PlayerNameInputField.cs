using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputField : MonoBehaviour
{
    public InputField InputField;

    private void Start()
    {
        InputField.onEndEdit.AddListener(PlayerDataSaver.Instance.ChangeNickName);

        PlayerDataSaver.Instance.OnDataLoaded += (name) => InputField.text = name;
    }
}
