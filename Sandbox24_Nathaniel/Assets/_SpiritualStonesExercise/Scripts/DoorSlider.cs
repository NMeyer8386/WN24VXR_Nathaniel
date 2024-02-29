using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class DoorSlider : MonoBehaviour
{
    [SerializeField] private Transform openDoor;
    [SerializeField] private Transform closeDoor;
    [SerializeField] private AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [Tooltip("Slide movement duration in seconds")]
    [SerializeField] private float slideDuration = 5.0f;

    private Coroutine doorSlideCoroutine;

    void Start()
    {
        Close();
    }

    private void OnEnable()
    {
        StoneSocket.OnAllStonesPlaced += Open;
    }

    private void OnDisable()
    {
        StoneSocket.OnAllStonesPlaced -= Open;
    }

    IEnumerator SlideDoor(Vector3 endPosition)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < slideDuration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / slideDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
            yield return null;
        }
        transform.position = endPosition; // Ensure the exact target position is reached
    }

    [ContextMenu("Open")] // This allows running the function from the Editor to test it (dotStack Menu next to Component Name). Only works for functions with no parameters.
    public void Open()
    {
        StopDoorSlideCoroutine(); // Stop any existing coroutine to avoid conflicts
        doorSlideCoroutine = StartCoroutine(SlideDoor(openDoor.position));
    }

    [ContextMenu("Close")]
    public void Close()
    {
        StopDoorSlideCoroutine();
        doorSlideCoroutine = StartCoroutine(SlideDoor(closeDoor.position));
    }

    void StopDoorSlideCoroutine()
    {
        if (doorSlideCoroutine != null)
        {
            StopCoroutine(doorSlideCoroutine);
            doorSlideCoroutine = null;
        }
    }
}


