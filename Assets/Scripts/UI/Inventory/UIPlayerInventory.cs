using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIPlayerInventory : MonoBehaviour
{
    [SerializeField] private UIItem _itemTemplate;
    [SerializeField] private ItemManageWindow _itemManageWindow;

    private PlayerInventory _playerInventory;
    private UIItem _selectedItem;

    //Storage
    private IStorage _openedStorage;
    [SerializeField] private GameObject _storageUIElement; 

    private void Awake()
    {
        HideStorageWindow();
        _itemManageWindow.DropButton.onClick.AddListener(() => DropItem());
    }

    private void Start()
    {
        _playerInventory = Player.Instance.Inventory;
        _playerInventory.OnStorageOpen += ShowStorageWindow;
    }

    private void OnEnable()
    {
        if (_playerInventory)
            ShowItems(_playerInventory, transform);
    }

    private void ShowItems(IStorage storage, Transform parentItemsTransform)
    {
        parentItemsTransform.GetComponentsInChildren<UIItem>().ToList().ForEach(item => Destroy(item.gameObject));

        storage.Items.ForEach(item =>
        {
            var newItemButton = Instantiate(_itemTemplate, transform);
            newItemButton.Set(ref item);
            newItemButton.ButtonComponent.onClick.AddListener(() => ShowItemManageWindow(newItemButton));
        });
    }

    private void ShowItemManageWindow(UIItem itemButton)
    {
        _itemManageWindow.gameObject.SetActive(true);
        _itemManageWindow.Show(itemButton.transform as RectTransform);
        _selectedItem = itemButton;
    }

    private void ShowStorageWindow(IStorage openedStorage)
    {
        _openedStorage = openedStorage;
        _storageUIElement.SetActive(true);
        ShowItems(openedStorage, _storageUIElement.transform);
    }

    private void HideStorageWindow()
    {
        _openedStorage = null;
        _storageUIElement.SetActive(false);
    }

    private void DropItem()
    {
        _playerInventory.DropItem(_selectedItem.ItemReference);
        Destroy(_selectedItem.gameObject);
        _itemManageWindow.Hide();
    }
}