using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Utilities.DataAPI
{
    public struct GraphqlQuery
    {
        public string Query;
        public object Variables;
    }
    
    public class GraphqlUtils
    {
        private const string URL = "http://localhost:4000/graphql";
        private const string RequestName = "Content-Type";
        private const string RequestType = "application/json";
        
        private JObject GetData(JObject data) => data == null ? null : JObject.Parse(data["data"].ToString());
        
        public async UniTask<T> GetModel<T>(GraphqlQuery query, string queryName,  CancellationToken token)
        {
            T modelData = default;
            
            var webRequest = new UnityWebRequest(URL, UnityWebRequest.kHttpVerbPOST);
            var json = JsonConvert.SerializeObject(query);
            var payload = Encoding.UTF8.GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(payload);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader(RequestName, RequestType);
            await webRequest.SendWebRequest().WithCancellation(token).AsUniTask();

            if (webRequest.result != UnityWebRequest.Result.Success) return modelData;
            
            var data = JObject.Parse(webRequest.downloadHandler.text);
            modelData = JsonUtility.FromJson<T>(GetData(data)[queryName]?.ToString());
            
            return modelData;
        }
    }
}