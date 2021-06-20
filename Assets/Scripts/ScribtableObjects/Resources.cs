using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class Resources : Item
    {
        public ResoucesType ResoucesType;
        public int Amount;
    }
}

public enum ResoucesType { Metal, Wood }