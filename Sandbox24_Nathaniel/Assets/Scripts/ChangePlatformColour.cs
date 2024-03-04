using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class ChangePlatformColour : MonoBehaviour
{
    Renderer platformRenderer;

    void MakePlatformEmissive()
    {
        platformRenderer = GetComponent<Renderer>();

        if (PlatformJumper.isOnPlatform)
        {
            platformRenderer.material.EnableKeyword("_EMISSION");
        } else
        {
            platformRenderer.material.DisableKeyword("_EMISSION");
        }
    }

    private void OnEnable()
    {
        PlatformJumper.JumperOnPlatform += MakePlatformEmissive;
    }
    private void OnDisable()
    {
        PlatformJumper.JumperOnPlatform -= MakePlatformEmissive;
    }
}
