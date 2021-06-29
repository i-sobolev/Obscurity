using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using API;
using System.Linq;

public class WorldList : MonoBehaviour
{
    [SerializeField] private WorldListElement _worldTemplate;

    private WorldController _apiWorldController;

    private void Awake() => _apiWorldController = new WorldController();

    private void Start() => GetWorlds().Start(this);

    private IEnumerator GetWorlds()
    {
        yield return _apiWorldController.Get();

        ClearWorlds();
        SetWorldList(_apiWorldController.RequestResult);
    }

    private void ClearWorlds() => GetComponentsInChildren<WorldListElement>().ToList().ForEach(world => Destroy(world.gameObject));

    private void SetWorldList(List<WorldViewModel> worlds)
    {
        worlds.ForEach(world =>
        {
            var newWorldListElement = Instantiate(_worldTemplate, transform);
            newWorldListElement.SetWorldReference(world);
            newWorldListElement.OnJoinButtonClicked += (worldId) => JoinWorld(worldId).Start(this);
        });
    }

    private IEnumerator JoinWorld(int worldId)
    {
        var request = new PlayerController();
        yield return request.Put(worldId).Start(this);

        PlayerData.Values.worldId = worldId;
        PlayerDataSaver.Instance.SaveData();

        yield return GetWorlds().Start(this);
    }
}
