using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJumper : MonoBehaviour
{
    /*  
     *  In this script, we have to make two static properties: 
     *  One boolean that tracks if the "jumper" is on the platform
     *  and One event action that is broadcast when we determine something is on the platform
     *  We also need a raycast to determine if the jumper is above/on something
     */

    static public event Action JumperOnPlatform;
    public static bool isOnPlatform;

    private void Update()
    {
        RaycastHit hit;
        Ray jumpRay = new Ray(gameObject.transform.position, Vector3.down);
        if (Physics.Raycast(jumpRay, out hit) && hit.collider.gameObject.CompareTag("Platform") && hit.distance <= 0.2f)
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
