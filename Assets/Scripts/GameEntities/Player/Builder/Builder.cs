using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Obscurity
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private Material _previewMaterial = null;

        private bool _isBuilds = false;
        private BuildingTemplate _selectedBuildingTemplate;

        public readonly int _ignoreRaycastLayer = 2;

        private Action _onBuildingSuccessed;

        public void Build(BuildingTemplate selectedBuidingTemplate)
        {
            if (!_isBuilds && _playerInventory.CheckResources(selectedBuidingTemplate.RequiredResources))
            {
                _selectedBuildingTemplate = selectedBuidingTemplate;
                StartCoroutine(StartBuild());

                _onBuildingSuccessed = () => _playerInventory.RemoveResources(selectedBuidingTemplate.RequiredResources);
            }
        }

        private IEnumerator StartBuild()
        {
            _isBuilds = true;
            var buildingPreview = CreateBuildingPreview();

            while (true)
            {
                yield return null;

                buildingPreview.transform.position = PlayerCursor.CursorWorldPosition;

                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Build(buildingPreview.transform.position, buildingPreview.transform.eulerAngles);
                    }

                    Destroy(buildingPreview.gameObject);
                    _isBuilds = false;

                    break;
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    buildingPreview.transform.Rotate(Vector3.up, Time.deltaTime * 120);
                }
            }
        }

        private void Build(Vector3 position, Vector3 rotation)
        {
            Instantiate(_selectedBuildingTemplate.GameObject, position, Quaternion.Euler(rotation));

            _onBuildingSuccessed.Invoke();
        }

        private Building CreateBuildingPreview()
        {
            var buildPreview = Instantiate(_selectedBuildingTemplate.GameObject, PlayerCursor.CursorWorldPosition, Quaternion.identity);
            buildPreview.gameObject.layer = _ignoreRaycastLayer;

            buildPreview.GetComponentsInChildren<Collider>()
                .ToList()
                .ForEach(collider =>
                {
                    collider.isTrigger = true;
                });

            buildPreview.GetComponentsInChildren<MeshRenderer>()
                .ToList()
                .ForEach(meshRenderer =>
                {
                    meshRenderer.material = _previewMaterial;
                    meshRenderer.gameObject.layer = _ignoreRaycastLayer;
                });

            return buildPreview;
        }
    }
}