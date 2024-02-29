using System;
using UnityEditor;
using UnityEngine;


public class StoneSocketTwo : MonoBehaviour
{
    [Tooltip("Drag one of the three spiritual stones in here")] //This allows us to display some text when hovering over the variable name in the editor.
    [SerializeField] private GameObject stoneReference;

    static int stoneCount;
    static public event Action OnAllStonesPlaced;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} gameobject entered the trigger");
        stoneCount++;

        if (stoneCount == 3)
        {
            OnAllStonesPlaced.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.gameObject.name} gameobject exited the trigger");
        stoneCount--;
    }

}