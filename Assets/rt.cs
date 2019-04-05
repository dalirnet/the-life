using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rt : MonoBehaviour
{

    private bool move = false;
    private Vector3 ds;

    void Start()
    {
        //newPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ds = new Vector3(ray.origin.x, 0, -10);
        }

        if (move)
        {
            transform.position = Vector3.Lerp(transform.position, ds, Time.deltaTime);
            if (transform.position == ds)
            {
                move = false;
            }
        }

    }
}
