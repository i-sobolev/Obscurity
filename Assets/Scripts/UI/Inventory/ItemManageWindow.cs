using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManageWindow : MonoBehaviour
{
    [Header("Inventory manage buttons")]
    public Button DropButton;

    private new RectTransform transform;
    [SerializeField] private GameObject _turnOffScreenArea; // обозвать нормально

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        Hide();
    }

    public void Show(RectTransform buttonTransform)
    {
        _turnOffScreenArea.SetActive(true);
        transform.anchoredPosition = buttonTransform.anchoredPosition + new Vector2(-buttonTransform.sizeDelta.x * 0.5f, -buttonTransform.sizeDelta.y);
    }

    public void Hide()
    {
        _turnOffScreenArea.SetActive(false);
        gameObject.SetActive(false);
    }
}