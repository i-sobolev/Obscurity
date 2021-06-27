using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(this);

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Menu")
            SceneManager.LoadScene("Menu");
    }

    public void LoadMainScene()
    {
        if (PlayerData.Values.worldId != 0)
            SceneManager.LoadScene("Main");
    }
}
