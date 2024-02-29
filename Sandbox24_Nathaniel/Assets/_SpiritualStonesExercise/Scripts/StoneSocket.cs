using System;
using UnityEditor;
using UnityEngine;


public class StoneSocket : MonoBehaviour
{
    [Tooltip("Drag one of the three spiritual stones in here")] //This allows us to display some text when hovering over the variable name in the editor.
    [SerializeField] private GameObject stoneReference;

    static int stoneCount;
    static public event Action OnAllStonesPlaced;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} gameobject entered the trigger");

        string stoneName = other.gameObject.name;
        string socketName = gameObject.name;

        //Cut string at -
        string socketCheck = GetBeginningOfString(socketName);

        //Use string.startswith to see if they're the same
        if (stoneName.StartsWith(socketCheck))
        {
            //Increment stone count if its the right socket
            stoneCount++;
        }

        //If all the stones are placed, invoke an event
        if (stoneCount == 3)
        {
            OnAllStonesPlaced.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.gameObject.name} gameobject exited the trigger");
        //Decrement the stonecount if a gem is removed
        stoneCount--;
    }

    string GetBeginningOfString(string originalString)
    {
        //Declare new string to be returned, delimiter to cut the original string at, and an index that will be set later
        string newString;
        char charToCut = '-';
        int charIndex;

        //Get the index of the - in the original string
        charIndex = originalString.IndexOf(charToCut);
        
        //Cut that shit from start to the index
        newString = originalString.Substring(0, charIndex);

        return newString;
    }
}
