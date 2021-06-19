using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using API;

public class World : MonoBehaviour
{
    public static World Instance { private set; get; }

    public ScriptableObjects.BuildingTemlates BuildingTemlates;

    private BuildingController _apiBuildingController;

    private void Awake()
    {
        Instance = this;
        _apiBuildingController = new BuildingController();

        BuildingTemlates.Buildings.ForEach(x => x.BuildingTemplate.TypeId = BuildingTemlates.Buildings.IndexOf(x));

        StartCoroutine(GetBuildings());
    }

    private IEnumerator GetBuildings()
    {
        yield return _apiBuildingController.Get().Start(this);
        WorldBuildingsInstantiate(_apiBuildingController.RequestResult);
    }

    public void SaveBuilding(Building building)
    {
        var newBuilding = new BuildingViewModel()
        {
            owner = building.Owner,
            xPosition = building.transform.position.x,
            yPosition = building.transform.position.y,
            zPosition = building.transform.position.z,
            typeId = building.TypeId,
            lightning = building is LightningBuilding l ? new LightningViewModel() { Fuel = l.Fuel } : new LightningViewModel() { Id = -1 },
            storage = building is StorageBuilding s ? new StorageViewModel() { isLocked = s.IsLocked } : new StorageViewModel() { id = -1 }
        };

        _apiBuildingController.Post(newBuilding).Start(this);
    }

    private void WorldBuildingsInstantiate(List<BuildingViewModel> worldBuildings)
    {
        worldBuildings.ForEach(building =>
        {
            var wolrdPosition = new Vector3(building.xPosition, building.yPosition, building.zPosition);

            var newBuilding = Instantiate(BuildingTemlates.Buildings[building.typeId].BuildingTemplate, wolrdPosition, Quaternion.identity);

            newBuilding.Owner = building.owner;

            if (newBuilding is LightningBuilding lightning)
                lightning.Fuel = building.lightning.Fuel;

            if (newBuilding is StorageBuilding storage)
                storage.IsLocked = building.storage.isLocked;
        });
    }
}