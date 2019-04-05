using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;

public class HttpController : MonoBehaviour
{

    private string baseUrl = "http://the-life.ir/api/";

    public void Request(string method, object jsonObject, Action<bool,string> callback)
    {
        StartCoroutine(Send(baseUrl + method, JsonUtility.ToJson(jsonObject), callback));
    }

    IEnumerator Send(string url, string json, Action<bool,string> callback)
    {
        string uId = SystemInfo.deviceUniqueIdentifier;
        UnityWebRequest webRequest = UnityWebRequest.Put(url, json);
        webRequest.SetRequestHeader("TLT", uId + "." + Helper.Tlt(SystemInfo.deviceUniqueIdentifier, json));
        yield return webRequest.Send();
        bool responseStatus = false;
        if (!webRequest.isError && webRequest.responseCode == 200)
        {
            string responseTlt = webRequest.GetResponseHeader("TLT");
            if (responseTlt != null)
            {
                string[] TltPart = responseTlt.Split("."[0]);
                if (TltPart.Length == 2)
                {
                    if (TltPart[1] == Helper.Tlt(uId, webRequest.downloadHandler.text))
                    {
                        responseStatus = true;
                    }
                }
            }
        }
        callback(responseStatus, webRequest.downloadHandler.text);
    }

}
