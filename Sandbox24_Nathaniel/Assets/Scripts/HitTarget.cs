using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitTarget : MonoBehaviour
{
    protected int totalScore = 0;
    [SerializeField] protected int hitScore = 1;
    [SerializeField] protected TextMeshProUGUI scoreGUI;
    private HitTarget hitTarget;

    private void Start()
    {
        if (scoreGUI == null)
        {
            return;
        }
        scoreGUI.text = "";
    }

    //Check to see if the target is being hit
    protected virtual void Update()
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
                    if (gameObject == hitTarget.gameObject)
                    {
                        TakeHit(hitScore);  //...Take a hit and add the score
                    }
                }
            }
        }
    }

    //When a hit is taken, add the hit to the score
    //Function is made virtual so we can override it
    public virtual void TakeHit(int scoreToAdd)
    {
        hitScore = CalcScore(hitScore);

        scoreGUI.text = "+" + hitScore.ToString();

        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        Invoke(nameof(Destroy), 1f);
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    //Add given score to the total
    public virtual int CalcScore(int score)
    {
        totalScore += score;
        return score;
    }

}
