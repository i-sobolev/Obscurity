using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCursor))]
[RequireComponent(typeof(Builder))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerCursor Cursor { get; private set; }
    public Builder Builder { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public PlayerMover Mover { get; private set; } 


    private void Awake()
    {
        Instance = this;

        InitializePlayerComponents();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Iteract();

        Mover.Move();
        Mover.LookAt(Cursor.CursorWorldPosition);
    }

    public void Build(ScriptableObjects.Building selectedBuilding)
    {
        if (CheckResources(selectedBuilding))
            Builder.Build(selectedBuilding);

        else
            ActionsLogger.Instance.Log("No resources");
    }

    private bool CheckResources(ScriptableObjects.Building selectedBuilding)
    {
        foreach (var requiredResources in selectedBuilding.RequiredResources)
            if (!Inventory.CheckResouces(requiredResources.ResoucesType, requiredResources.Amount))
                return false;

        return true;
    }

    private void Iteract()
    {
        if (Cursor.CatchedEntity != null)
            Cursor.CatchedEntity.Iteract(this);
    }

    private void InitializePlayerComponents()
    {
        Cursor = GetComponent<PlayerCursor>();
        Builder = GetComponent<Builder>();
        Inventory = GetComponent<PlayerInventory>();
        Mover = GetComponent<PlayerMover>();
    }
}