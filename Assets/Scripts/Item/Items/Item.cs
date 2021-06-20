using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Item(ScriptableObjects.Item itemReference)
    {
        Name = itemReference.Name;
        GameObject = itemReference.GameObject;
    }

    public string Name;
    public ItemGameObject GameObject;
}
