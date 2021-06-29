using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Resources : Item
{
    public Resources(ScriptableObjects.Resources resourcesReference) : base(resourcesReference)
    {
        ResoucesType = resourcesReference.ResoucesType;
        Amount = resourcesReference.Amount;
    }

    public ResoucesType ResoucesType;
    public int Amount;
}

[Serializable]
public class ResourceViewModel
{
    public int id;
    public int amount;
}