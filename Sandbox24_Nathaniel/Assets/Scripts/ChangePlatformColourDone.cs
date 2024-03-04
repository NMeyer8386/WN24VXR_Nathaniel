using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class ChangePlatformColourDone : MonoBehaviour
{
    Renderer platformRenderer;

    void MakePlatformEmissive()
    {
        platformRenderer = GetComponent<Renderer>();

        if (PlatformJumperDone.isOnPlatform)
        {
            platformRenderer.material.EnableKeyword("_EMISSION");
        } else
        {
            platformRenderer.material.DisableKeyword("_EMISSION");
        }
    }

    private void OnEnable()
    {
        PlatformJumperDone.JumperOnPlatform += MakePlatformEmissive;
    }
    private void OnDisable()
    {
        PlatformJumperDone.JumperOnPlatform -= MakePlatformEmissive;
    }
}
