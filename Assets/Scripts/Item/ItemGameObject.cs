using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGameObject : MonoBehaviour, IIteractable
{
    public Item Item;

    public void Iteract(Player player)
    {
        player.Inventory.AddItem(this);
        Destroy(gameObject);
    }
}