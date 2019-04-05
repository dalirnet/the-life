using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class test : InstanceBuild
{


    void Start()
    {
        StartCoroutine(ok());



        /* 
        TempDB.Set("playerName", "Hadi Malek");
        TempDB.SetToDefault("playerName");
        TempDB.Get("playerName");
        
        Joreq_setPlayer joreq_setPlayerObject = new Joreq_setPlayer();
        joreq_setPlayerObject.name = "amir";
        HttpControllerScript.Request("setPlayer", joreq_setPlayerObject, Jores_setPlayer.callback);
        */

    }

    IEnumerator ok()
    {
        MessageCS.Show("امیر رضا دلیر / زندگی دیجیتال");
        yield return new WaitForSeconds(5f);
        MessageCS.Show("name");

    }

    void Update()
    {
		
    }
        
}
