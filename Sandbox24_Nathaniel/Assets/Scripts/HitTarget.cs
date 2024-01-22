using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitTarget : MonoBehaviour
{
    protected int totalScore = 0;
    [SerializeField] protected int hitScore = 1;
    [SerializeField] protected TextMeshProUGUI scoreGUI;

    private void Start()
    {
        if (scoreGUI == null)
        {
            return;
        }
        scoreGUI.text = "";
    }

    //When a hit is taken, add the hit to the score
    //Function is made virtual so we can override it
    public virtual void TakeHit()
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
