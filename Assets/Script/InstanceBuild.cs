using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBuild : MonoBehaviour
{

    protected GameObject ScriptControllerGameObject;
    protected HttpController HttpCS;
    protected MessageController MessageCS;


    void Awake()
    {
        ScriptControllerGameObject = GameObject.Find("ScriptController");
        HttpCS = ScriptControllerGameObject.GetComponent<HttpController>();
        MessageCS = ScriptControllerGameObject.GetComponent<MessageController>();

    }

}
