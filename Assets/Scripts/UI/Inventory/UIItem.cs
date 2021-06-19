using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item ItemReference;
    public Button ButtonComponent; 

    public void Set(ref Item linkedItem)
    {
        ItemReference = linkedItem;
    }
}
