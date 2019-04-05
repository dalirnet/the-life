using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;


public class Jores_setPlayer : JsonObjectResponse
{

    public static void callback(bool status, string serverResponse)
    {
        Jores_setPlayer jores_setPlayerObject = JsonUtility.FromJson<Jores_setPlayer>(serverResponse);
        if (status)
        {
            Debug.Log(status + "--->" + jores_setPlayerObject.actionStatus);
        }
        else
        {
            Debug.Log(status + "--->" + jores_setPlayerObject.actionStatus);
        }
    }
}
