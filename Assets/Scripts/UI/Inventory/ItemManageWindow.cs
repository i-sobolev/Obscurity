using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManageWindow : MonoBehaviour
{
    [Header("Inventory manage buttons")]
    public Button DropButton;
    public Button TakeButton;
    public Button PutButton;

    private new RectTransform transform;
    [SerializeField] private GameObject _turnOffScreenArea;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        Hide();
    }

    public void Show(StorageType storageType)
    {
        ShowButtons(storageType);
        _turnOffScreenArea.SetActive(true);
        transform.anchoredPosition = Input.mousePosition;
    }

    public void Hide()
    {
        _turnOffScreenArea.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ShowButtons(StorageType storageType)
    {
        switch (storageType)
        {
            case StorageType.PlayerInventory:
                SetActiveButtons(true, false, true);
                break;

            case StorageType.Storage:
                SetActiveButtons(false, true, false);
                break;

            case StorageType.JustPlayerInventory:
                SetActiveButtons(true, false, false);
                break;
        }
    }

    private void SetActiveButtons(bool dropButtton, bool takeButton, bool putButton)
    {
        DropButton.gameObject.SetActive(dropButtton);
        TakeButton.gameObject.SetActive(takeButton);
        PutButton.gameObject.SetActive(putButton);
    }

    public enum StorageType { PlayerInventory, Storage, JustPlayerInventory }
}