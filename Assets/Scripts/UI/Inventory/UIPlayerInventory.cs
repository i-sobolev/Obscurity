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
        _itemManageWindow.DropButton.onClick.AddListener(DropItem);
        _itemManageWindow.TakeButton.onClick.AddListener(TakeItemFromStorage);
        _itemManageWindow.PutButton.onClick.AddListener(PutItemInStorage);
        
        HideStorageWindow();
    }

    private void Start()
    {
        _playerInventory = Player.Instance.Inventory;
        _playerInventory.OnStorageOpen += ShowStorageWindow;
        _playerInventory.OnItemListChanged += ShowPlayerInventoryItems; 
    }

    private void OnEnable()
    {
        if (_playerInventory)
            ShowPlayerInventoryItems();
    }

    private void OnDisable()
    {
        HideStorageWindow();
        _itemManageWindow.Hide();
    }

    private void ShowOpenedStorageItems() => ShowItems(_openedStorage, _storageUIElement.transform);

    private void ShowPlayerInventoryItems() => ShowItems(_playerInventory, transform);

    private void ShowItems(IStorage storage, Transform parentItemsTransform)
    {
        parentItemsTransform.GetComponentsInChildren<UIItem>().ToList().ForEach(item => Destroy(item.gameObject));

        storage.Items.ForEach(item =>
        {
            var newItemButton = Instantiate(_itemTemplate, parentItemsTransform.transform);
            newItemButton.Set(ref item, storage);
            newItemButton.ButtonComponent.onClick.AddListener(() => ShowItemManageWindow(newItemButton));
        });
    }

    private void ShowItemManageWindow(UIItem itemButton)
    {
        var itemStorageType =
            _openedStorage == null ?
            ItemManageWindow.StorageType.JustPlayerInventory :
            (object)itemButton.LinkedStorage == _playerInventory ?
            ItemManageWindow.StorageType.PlayerInventory :
            ItemManageWindow.StorageType.Storage;

        _itemManageWindow.gameObject.SetActive(true);
        _itemManageWindow.Show(itemStorageType);
        _selectedItem = itemButton;
    }

    private void ShowStorageWindow(IStorage openedStorage)
    {
        _openedStorage = openedStorage;
        _storageUIElement.transform.parent.gameObject.SetActive(true);
        ShowItems(openedStorage, _storageUIElement.transform);
    }

    private void HideStorageWindow()
    {
        _openedStorage = null;
        _storageUIElement.transform.parent.gameObject.SetActive(false);
    }

    private void DropItem()
    {
        _playerInventory.DropItem(_selectedItem.ItemReference);
        Destroy(_selectedItem.gameObject);
        ShowPlayerInventoryItems();

        _itemManageWindow.Hide();
    }

    private void TakeItemFromStorage()
    {
        _playerInventory.AddItem(_selectedItem.ItemReference);
        _openedStorage.Items.Remove(_selectedItem.ItemReference);
        
        ShowOpenedStorageItems();

        _itemManageWindow.Hide();
    }

    private void PutItemInStorage()
    {
        _playerInventory.RemoveItem(_selectedItem.ItemReference);
        _openedStorage.Items.Add(_selectedItem.ItemReference);
        
        _itemManageWindow.Hide();

        ShowPlayerInventoryItems();
        ShowOpenedStorageItems();
    }
}