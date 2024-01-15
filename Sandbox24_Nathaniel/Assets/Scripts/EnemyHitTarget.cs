using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitTarget : HitTarget
{
    private EnemyHitTarget hitTarget;
    [SerializeField] private int hitsToDestroy = 1;

    //When a hit is taken, add the hit to the score
    //Overriding functions yippee
    public override void TakeHit(int scoreToAdd)
    {
        base.totalScore = CalcScore(scoreToAdd);
        Debug.Log("This is an overridden function");
    }

    //Add given score to the total
    public override int CalcScore(int score)
    {
        int scoreGain = hitsToDestroy * score;
        Debug.Log("Gained Score " + scoreGain);
        return scoreGain;
    }

}
