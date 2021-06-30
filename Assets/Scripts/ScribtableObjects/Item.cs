﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public ItemGameObject GameObject;
        public int TypeId;
    }
}