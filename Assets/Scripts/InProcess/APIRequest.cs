//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;
//using UnityEngine.Networking;

//namespace API
//{
//    public class BuildingController
//    {
//        public List<BuildingModel> RequestResult { get; private set; }
        
//        private readonly string _apiUri = "";

//        public IEnumerator Get(int worldId)
//        {
//            UnityWebRequest webRequest = UnityWebRequest.Get(_apiUri + $"?worldId={worldId}");
//            webRequest.SetRequestHeader("Content-type", "application/json");

//            yield return webRequest.SendWebRequest();

//            while (!webRequest.isDone)
//                yield return null;

//            byte[] result = webRequest.downloadHandler.data;

//            if (result != null)
//            {
//                string json = Encoding.UTF8.GetString(result);

//                JsonHelper.FixJson(ref json);
//                RequestResult = JsonHelper.FromJson<BuildingModel>(json).ToList();
//            }
//        }

//        public IEnumerator Post(BuildingModel building)
//        {
//            string json = JsonUtility.ToJson(building);
//            var webRequest = new UnityWebRequest(_apiUri, "POST");

//            var post = Encoding.UTF8.GetBytes(json);

//            webRequest.uploadHandler = new UploadHandlerRaw(post);
//            webRequest.downloadHandler = new DownloadHandlerBuffer();
//            webRequest.SetRequestHeader("Content-type", "application/json");

//            yield return webRequest.SendWebRequest();
//        }
//    }

//    public class WorldController
//    {
//        private readonly string _apiUri = "";

//        public List<WorldViewModel> RequestResult { get; private set; }

//        public IEnumerator Get()
//        {
//            UnityWebRequest webRequest = UnityWebRequest.Get(_apiUri);
//            webRequest.SetRequestHeader("Content-type", "application/json");

//            yield return webRequest.SendWebRequest();

//            while (!webRequest.isDone)
//                yield return null;

//            byte[] result = webRequest.downloadHandler.data;

//            if (result != null)
//            {
//                string json = Encoding.UTF8.GetString(result);

//                JsonHelper.FixJson(ref json);
                
//                RequestResult = JsonHelper.FromJson<WorldViewModel>(json).ToList();
//            }
//        }

//        public IEnumerator Post(string worldName)
//        {
//            var webRequest = new UnityWebRequest(_apiUri + $"?name={worldName}", "POST");
//            yield return webRequest.SendWebRequest();
//        }
//    }

//    public class PlayerController
//    {
//        private readonly string _apiUri = "";

//        public PlayerViewModel RequestResult { get; private set; }

//        public IEnumerator Post(string playerName)
//        {
//            var webRequest = new UnityWebRequest(_apiUri + $"?name={playerName}", "POST");
//            webRequest.SetRequestHeader("Content-type", "application/json");

//            webRequest.downloadHandler = new DownloadHandlerBuffer();

//            yield return webRequest.SendWebRequest();

//            while (!webRequest.isDone)
//                yield return null;

//            byte[] result = webRequest.downloadHandler.data;

//            if (result != null)
//            {
//                string json = Encoding.UTF8.GetString(result);
//                RequestResult = JsonUtility.FromJson<PlayerViewModel>(json);
//            }
//        }

//        public IEnumerator Put(string newNickname)
//        {
//            var webRequest = new UnityWebRequest(_apiUri + $"?playerId={PlayerData.Values.id}&name={newNickname}", "PUT");
//            yield return webRequest.SendWebRequest();
//        }

//        public IEnumerator Put(int worldId)
//        {
//            var webRequest = new UnityWebRequest(_apiUri + $"World?playerId={PlayerData.Values.id}&worldId={worldId}", "PUT");
//            yield return webRequest.SendWebRequest();
//        }
//    }

//    public class ItemController
//    {
//        private readonly string _apiUri = "";
//        public List<ItemViewModel> RequestResult { get; private set; }

//        public IEnumerator Get(int storageId)
//        {
//            UnityWebRequest webRequest = UnityWebRequest.Get(_apiUri + $"?storageId={storageId}");
//            webRequest.SetRequestHeader("Content-type", "application/json");

//            yield return webRequest.SendWebRequest();

//            while (!webRequest.isDone)
//                yield return null;

//            byte[] result = webRequest.downloadHandler.data;

//            if (result != null)
//            {
//                string json = Encoding.UTF8.GetString(result);
                
//                if (json != string.Empty)
//                {
//                    JsonHelper.FixJson(ref json);
//                    RequestResult = JsonHelper.FromJson<ItemViewModel>(json).ToList();
//                }
//            }
//        }

//        public IEnumerator Post(ItemViewModel item)
//        {
//            string json = JsonUtility.ToJson(item);

//            var webRequest = new UnityWebRequest(_apiUri, "POST");

//            var post = Encoding.UTF8.GetBytes(json);

//            webRequest.uploadHandler = new UploadHandlerRaw(post);
//            webRequest.downloadHandler = new DownloadHandlerBuffer();
//            webRequest.SetRequestHeader("Content-type", "application/json");

//            yield return webRequest.SendWebRequest();
//        }

//        public IEnumerator Put(int itemId)
//        {
//            var webRequest = new UnityWebRequest(_apiUri + $"?itemId={itemId}", "DELETE");
//            yield return webRequest.SendWebRequest();
//        }
//    }
//}