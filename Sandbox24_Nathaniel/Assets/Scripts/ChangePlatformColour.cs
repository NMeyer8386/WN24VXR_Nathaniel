using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlatformColour : MonoBehaviour
{
    /*  
     *  In this script, we have to subscribe to an event that will be broadcast by another script,
     *  As well as get the renderer component of the platform object so we can change its properties
     */

    Renderer platformRenderer;

    private void Start()
    {
        platformRenderer = GetComponent<Renderer>();
    }

    void MakePlatformEmissive()
    {
        if (PlatformJumper.isOnPlatform)
        {
            platformRenderer.material.EnableKeyword("_EMISSION");
        }
        else
        {
            platformRenderer.material.DisableKeyword("_EMISSION");
        }

    }

    private void OnEnable()
    {
        //Make event listener for platform
        PlatformJumper.JumperOnPlatform += MakePlatformEmissive;
    }

    private void OnDisable()
    {
        PlatformJumper.JumperOnPlatform -= MakePlatformEmissive;
    }
}
