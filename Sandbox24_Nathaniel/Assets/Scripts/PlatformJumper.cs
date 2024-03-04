using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJumper : MonoBehaviour
{

    static public event Action JumperOnPlatform;
    public static bool isOnPlatform;


    // Update is called once per frame
    void Update()
    {   
        RaycastHit hit;
        Ray jumpRay = new Ray(gameObject.transform.position, Vector3.down * 0.2f);
        if (Physics.Raycast(jumpRay, out hit) && hit.collider.gameObject.name == "Platform" && hit.distance <= 0.2f)
        {
            isOnPlatform = true;
            JumperOnPlatform.Invoke();
        }
        else
        {
            isOnPlatform = false;
            JumperOnPlatform.Invoke();
        }
    }
}
