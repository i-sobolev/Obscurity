using UnityEngine;

[System.Serializable]
public class Building : MonoBehaviour, IIteractable
{
    public int TypeId;
    public string Owner;

    public virtual void Iteract(Player player) { }
}

[System.Serializable]
public class BuildingViewModel
{
    public int id;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public string owner;
    public int typeId;

    public LightningViewModel lightning;
    public StorageViewModel storage;

    public float rotation;

    public int worldId;
}