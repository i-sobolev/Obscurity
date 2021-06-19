using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public IStorage LinkedStorage;
    public Item ItemReference;
    public Button ButtonComponent; 

    public void Set(ref Item linkedItem, IStorage linkedStorage)
    {
        ItemReference = linkedItem;
        LinkedStorage = linkedStorage;
    }
}
