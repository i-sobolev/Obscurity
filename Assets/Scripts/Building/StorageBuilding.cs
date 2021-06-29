using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageBuilding : Building, IStorage
{
    public List<Item> Items { get; set; }
    public int MaxItems { get; set; }
    public bool IsLocked { get; set; }

    public bool BuildedByPlayer;
    public int StorageId;
    private API.ItemController _apiItemController;

    private void Awake()
    {
        Items = new List<Item>();
    }

    public void SetBuildedByPlayerState()
    {
        BuildedByPlayer = true;
        _apiItemController = new API.ItemController();
    }

    public override void Iteract(Player player)
    {
        if (BuildedByPlayer)
            ItemRequest(() => Open(player)).Start(this);

        else
            Open(player);
    }

    private void Open(Player player)
    {
        player.Inventory.OpenStorage(this);
        ActionsLogger.Instance.Log("Opened");
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);

        Debug.Log(item.Id);

        if (BuildedByPlayer)
            _apiItemController.Put(item.Id).Start(this);
    }

    public void AddItem(Item item)
    {
        Items.Add(item);

        if (BuildedByPlayer)
            _apiItemController.Post(new ItemViewModel()
            {
                typeId = item.TypeId,
                storageId = StorageId,
                resource = item is Resources r ? new ResourceViewModel() { amount = r.Amount } : new ResourceViewModel() { id = -1 }
            }).Start(this);
    }

    public IEnumerator ItemRequest(UnityAction onRequestDone)
    {
        Items = new List<Item>();

        yield return _apiItemController.Get(StorageId).Start(this);

        if (_apiItemController.RequestResult != null)
        {
            _apiItemController.RequestResult.ForEach(itemViewModel =>
            {
                var itemReference = World.Instance.ItemTemplates.Items[itemViewModel.typeId];
                var newItem = itemReference is ScriptableObjects.Resources r ?
                    new Resources(itemReference as ScriptableObjects.Resources) { Amount = itemViewModel.resource.amount } :
                    new Item(itemReference);

                newItem.Id = itemViewModel.id;

                Items.Add(newItem);
            });
        }

        onRequestDone.Invoke();
    }
}

[System.Serializable]
public class StorageViewModel
{
    public int id;
    public bool isLocked;
}