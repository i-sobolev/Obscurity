using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class ItemTemplates : ScriptableObject
    {
        public List<Item> Items;
    }
}