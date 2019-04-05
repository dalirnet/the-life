using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : InstanceBuild
{
    private float quitAfterSeconds = 3f;
    private bool callQuit = false;

    void Start()
    {
        //MessageCS.Show("hi ;)", true);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ApplicationQuit());
        }
    }


    IEnumerator ApplicationQuit()
    {
        if (callQuit)
        {
            MessageCS.AndroidToastCancel();
            Application.Quit();
        }
        else
        {
            callQuit = true;
            MessageCS.Show("tap again for exit!");
        }
        yield return new WaitForSeconds(quitAfterSeconds);
        callQuit = false;
    }
}
