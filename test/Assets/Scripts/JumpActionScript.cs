using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpActionScript : MonoBehaviour
{
    [SerializeField] InputActionReference jump;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rBody;

    private void Awake()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        jump.action.started += OnJump;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (OnGround())
        {
            rBody.AddForce(Vector3.up * jumpForce);
            print("Jumping");
        }
        else
        {
            print("not jumping");
        }

    }

    private bool OnGround()
    {
        return Physics.Raycast(gameObject.transform.position, Vector3.down * 2);
    }
}
