using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    protected int totalScore = 0;
    [SerializeField] protected int hitScore = 1;
    private HitTarget hitTarget;

    //Check to see if the target is being hit
    protected void Update()
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
                if (hit.collider.gameObject.TryGetComponent<HitTarget>(out hitTarget))  //...and that something is our target...
                {
                    TakeHit(hitScore);  //...Take a hit and add the score
                }
            }
        }
    }

    //When a hit is taken, add the hit to the score
    //Function is made virtual so we can override it
    public virtual void TakeHit(int scoreToAdd)
    {
        CalcScore(hitScore);
    }

    //Add given score to the total
    public virtual int CalcScore(int score)
    {
        totalScore += score;
        Debug.Log("Gained " + score + " Total " + totalScore);
        return score;
    }

}
