using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIColourScript : MonoBehaviour
{
    public Color startColour = Color.white;
    public Color endColour = Color.white;
    [SerializeField] GameObject[] swatchObjects;
    float lerpScale;
    float initLerp;

    [ContextMenu("ChangeColour")]
    void ChangeColour()
    {
        initLerp = 1f / swatchObjects.Length;
        lerpScale = initLerp;
        foreach (var obj in swatchObjects)
        {
            obj.GetComponent<Image>().color = Color.Lerp(startColour, endColour, lerpScale);
            lerpScale += initLerp;
        }
    }
}
