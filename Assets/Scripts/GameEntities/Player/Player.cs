using Obscurity;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Builder _builder;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private PlayerCamera _camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Iteract();
    }

    private void Iteract()
    {
        if (PlayerCursor.CatchedEntity != null)
        {
            var cathedEntity = PlayerCursor.CatchedEntity;

            if (cathedEntity is ItemGameObject item)
                _inventory.AddItem(item.Item);

            if (cathedEntity is StorageBuilding storage)
                _inventory.OpenStorage(storage);

            cathedEntity.Iteract(this);
        }
    }
}