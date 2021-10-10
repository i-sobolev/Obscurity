//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using API;

//public class World : MonoBehaviour
//{
//    public static World Instance { private set; get; }

//    public ScriptableObjects.BuildingTemlates BuildingTemlates;
    
//    private BuildingController _apiBuildingController;

//    public ScriptableObjects.ItemTemplates ItemTemplates;

//    private void Awake()
//    {
//        Instance = this;
//        _apiBuildingController = new BuildingController();

//        BuildingTemlates.Buildings.ForEach(x => x.BuildingTemplate.TypeId = BuildingTemlates.Buildings.IndexOf(x));

//        StartCoroutine(GetBuildings());
//    }

//    private IEnumerator GetBuildings()
//    {
//        yield return _apiBuildingController.Get(PlayerData.Values.worldId).Start(this);
//        WorldBuildingsInstantiate(_apiBuildingController.RequestResult);
//    }

//    public void SaveBuilding(Building building)
//    {
//        var newBuilding = new BuildingModel()
//        {
//            owner = PlayerData.Values.name,
//            xPosition = building.transform.position.x,
//            yPosition = building.transform.position.y,
//            zPosition = building.transform.position.z,
//            rotation = building.transform.rotation.eulerAngles.y,
//            typeId = building.TypeId,
//            lightning = building is LightningBuilding l ? new LightningModel() { Fuel = l.Fuel } : new LightningModel() { Id = -1 },
//            storage = building is StorageBuilding s ? new StorageModel() { isLocked = s.IsLocked } : new StorageModel() { id = -1 },
//            worldId = PlayerData.Values.worldId
//        };

//        _apiBuildingController.Post(newBuilding).Start(this);
//    }

//    private void WorldBuildingsInstantiate(List<BuildingModel> worldBuildings)
//    {
//        worldBuildings.ForEach(building =>
//        {
//            var wolrdPosition = new Vector3(building.xPosition, building.yPosition, building.zPosition);

//            var newBuilding = Instantiate
//            (
//                BuildingTemlates.Buildings[building.typeId].BuildingTemplate, 
//                wolrdPosition,
//                Quaternion.Euler(0, building.rotation, 0)
//            );

//            newBuilding.Owner = building.owner == string.Empty ? "unknown" : building.owner;

//            if (newBuilding is LightningBuilding lightning)
//            {
//                lightning.Fuel = building.lightning.Fuel;
//            }

//            if (newBuilding is StorageBuilding storage)
//            {
//                storage.IsLocked = building.storage.isLocked;
//                storage.StorageId = building.id;

//                storage.SetBuildedByPlayerState();
//            }
//        });
//    }
//}