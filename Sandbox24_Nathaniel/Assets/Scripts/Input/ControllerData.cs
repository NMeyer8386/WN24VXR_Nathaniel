using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerData : MonoBehaviour
{
    [SerializeField] InputActionProperty angularVelocityProperty;
    [SerializeField] InputActionProperty velocityProperty;


    [SerializeField] private Vector3 angVel;
    [SerializeField] private Vector3 vel;

    public Vector3 AngularVelocity { private set {  } get {  return angVel; } }
    public Vector3 Velocity { private set {  } get { return vel; } }

    // Update is called once per frame
    void Update()
    {
        angVel = angularVelocityProperty.action.ReadValue<Vector3>();
        //Debug.Log("Angular Velocity: " + AngularVelocity);

        vel = velocityProperty.action.ReadValue<Vector3>();
        //Debug.Log("Velocity: " + Velocity);
    }
}
