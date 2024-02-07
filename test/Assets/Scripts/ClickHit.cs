using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHit : MonoBehaviour
{

    //Check to see if the target is being hit
    void Update()
    {
        TestHitTarget();
    }

    //If the mouse clicks the target, add the hit to the point total
    void TestHitTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast creation from mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))  //If the ray collides with something...
            {
                if (hit.collider.gameObject.TryGetComponent(out HitTarget hitTarget))  //...and that something is our target...
                {
                        hitTarget.TakeHit();  //...Take a hit and add the score
                }
            }
        }
    }
}
