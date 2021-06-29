using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Item(ScriptableObjects.Item itemReference)
    {
        Name = itemReference.Name;
        GameObject = itemReference.GameObject;
        TypeId = itemReference.TypeId;
    }

    public string Name;
    public ItemGameObject GameObject;

    public int TypeId;
    public int Id;
}

[System.Serializable]
public class ItemViewModel
{
    public int id;
    public int typeId;
    public int storageId;

    public ResourceViewModel resource;
}