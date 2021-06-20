using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Material _previewMaterial = null;

    private bool _isBuilds = false;
    private ScriptableObjects.Building _selectedBuilding;

    public void Build(ScriptableObjects.Building selectedBuiding)
    {
        if (!_isBuilds)
        {
            _selectedBuilding = selectedBuiding;
            StartCoroutine(StartBuild());
        }
    }

    private IEnumerator StartBuild()
    {
        _isBuilds = true;
        var buildPreview = CreatePreview();

        while (true)
        {
            yield return null;

            buildPreview.transform.position = Player.Instance.Cursor.CursorWorldPosition;

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                if (Input.GetButtonDown("Fire1"))
                    Build(buildPreview.transform.position);
                
                Destroy(buildPreview.gameObject);
                _isBuilds = false;

                break;
            }
        }
    }

    private void Build(Vector3 position)
    {
        var newBuilding = Instantiate(_selectedBuilding.BuildingTemplate, position, Quaternion.identity);
        var buildingComponent = newBuilding.GetComponent<Building>();

        buildingComponent.GetComponent<Building>().Owner = "TestOwner";
        World.Instance.SaveBuilding(buildingComponent);

        Player.Instance.Inventory.RemoveResouces(_selectedBuilding.RequiredResources);

        ActionsLogger.Instance.Log("Building builded!");//
    }

    private Building CreatePreview()
    {
        const int ignoreRaycastLayer = 2;
        
        var buildPreview = Instantiate(_selectedBuilding.BuildingTemplate, Player.Instance.Cursor.CursorWorldPosition, Quaternion.identity);
        buildPreview.gameObject.layer = ignoreRaycastLayer;

        buildPreview.GetComponentsInChildren<Collider>().ToList().ForEach(collider => collider.isTrigger = true);
        buildPreview.GetComponentsInChildren<MeshRenderer>().ToList().ForEach(meshRenderer => 
        {
            meshRenderer.material = _previewMaterial;
            meshRenderer.gameObject.layer = ignoreRaycastLayer;
        });

        return buildPreview;
    }
}