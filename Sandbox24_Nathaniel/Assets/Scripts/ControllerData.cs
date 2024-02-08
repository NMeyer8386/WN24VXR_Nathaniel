using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerData : MonoBehaviour
{
    [SerializeField] InputActionProperty angularVelocityProperty;
    [SerializeField] InputActionProperty velocityProperty;

    public Vector3 angularVelocity;
    public Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        angularVelocity = angularVelocityProperty.action.ReadValue<Vector3>();
        Debug.Log("Angular Velocity: " + angularVelocity);

        velocity = velocityProperty.action.ReadValue<Vector3>();
        Debug.Log("Velocity: " + velocity);
    }
}
