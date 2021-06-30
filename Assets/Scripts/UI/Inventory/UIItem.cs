﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public IStorage LinkedStorage;
    public Item ItemReference;
    public Button ButtonComponent;

    [SerializeField] private Image _icon;
    [SerializeField] private Text _resourcesAmount;

    public void Set(ref Item linkedItem, IStorage linkedStorage)
    {
        ItemReference = linkedItem;
        LinkedStorage = linkedStorage;

        _icon.sprite = linkedItem.UIIcon;

        if (ItemReference is Resources resources)
            SetResouresAmount(resources.Amount);
    }

    private void SetResouresAmount(int amount) => _resourcesAmount.text = amount.ToString();
}