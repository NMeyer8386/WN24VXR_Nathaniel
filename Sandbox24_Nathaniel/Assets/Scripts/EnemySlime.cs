using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyHitTarget
{
    private bool jumping = false;
    public override void Move()
    {
        base.Move();
        if (!jumping)
        {
            InvokeRepeating("Jump", 1f, repeatRate * 2);
            jumping = true;
        }
    }

    private void Jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 50);
        Debug.Log("Jumping");
    }
}
