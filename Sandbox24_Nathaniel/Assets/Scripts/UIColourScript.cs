using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

[ExecuteInEditMode]
public class UIColourScript : MonoBehaviour
{
    //Declare the two colours
    public Color startColour = Color.white;
    public Color endColour = Color.white;
    //Make array for gameobjects to change the colour
    private Image[] swatchObjects;
    [SerializeField] GameObject swatchParent;
    //Declare initial lerp and lerpscale to lerp the colours
    float lerpScale;
    float initLerp;

    [Button]
    void ChangeColour()
    {
        swatchObjects = swatchParent.GetComponentsInChildren<Image>();

        //set initial lerp value
        initLerp = 1f / (swatchObjects.Length - 1);
        lerpScale = 0;

        //Iterate through each object in the array
        foreach (var obj in swatchObjects)
        {
            //Get the colour of the thing and change it based on which object it is
            obj.color = Color.Lerp(startColour, endColour, lerpScale);
            //Increment the lerp scale so the gradient changes
            lerpScale += initLerp;
            
        }
    }
}
