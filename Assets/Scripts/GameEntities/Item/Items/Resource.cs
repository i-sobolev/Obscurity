namespace Obscurity
{
    public enum ResouceType { Metal, Wood }

    public class Resource : Item
    {
        public ResouceType ResourceType;
        public int Amount;
        
        public Resource(ResourcesTemplate resourcesReference) : base(resourcesReference)
        {
            ResourceType = resourcesReference.ResoucesType;
            Amount = resourcesReference.Amount;
        }
    }
}