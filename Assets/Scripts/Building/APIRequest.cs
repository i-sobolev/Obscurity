using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{
    public class BuildingController
    {
        public List<BuildingViewModel> RequestResult { get; private set; }
        
        private readonly string _apiUri = "http://ovz6.burnfeniks.m61kn.vps.myjino.ru/Building";

        public IEnumerator Get()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(_apiUri);
            webRequest.SetRequestHeader("Content-type", "application/json");

            yield return webRequest.SendWebRequest();

            while (!webRequest.isDone)
                yield return null;

            byte[] result = webRequest.downloadHandler.data;

            if (result != null)
            {
                string json = Encoding.UTF8.GetString(result);

                JsonHelper.FixJson(ref json);
                //Debug.Log(json);
                RequestResult = JsonHelper.FromJson<BuildingViewModel>(json).ToList();
            }
        }

        public IEnumerator Post(BuildingViewModel building)
        {
            string json = JsonUtility.ToJson(building);
            var webRequest = new UnityWebRequest(_apiUri, "POST");

            //Debug.Log(json);
            var post = Encoding.UTF8.GetBytes(json);

            webRequest.uploadHandler = new UploadHandlerRaw(post);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-type", "application/json");

            yield return webRequest.SendWebRequest();
        }
    }
}