using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitTarget : HitTarget
{
    [SerializeField] private int hitsToDestroy = 1;
    [SerializeField] Transform playerTarget;
    [SerializeField] private float moveSpeed = 0.001f;
    [SerializeField] protected float repeatRate = 1f;
 
    private int currentHits = 0;

    void Update()
    {
        Move();
    }

    //When a hit is taken, add the hit to the score
    //Overriding functions yippee
    public override void TakeHit()
    {
        currentHits++;
        if (currentHits == hitsToDestroy)
        {
            totalScore = CalcScore(hitScore);
            Debug.Log("This is an overridden function");

            scoreGUI.text = "+" + hitScore.ToString();

            Invoke(nameof(Destroy), 1f);
        }

    }

    public virtual void Move()
    {
        if (playerTarget == null) { return; }

        var step = moveSpeed + Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);

    }

    private void Attack()
    {
        Debug.Log(gameObject.name + " is attacking Player", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InvokeRepeating("Attack", 1f, repeatRate);
        }
    }

    //Add given score to the total
    public override int CalcScore(int score)
    {
        int scoreGain = hitsToDestroy * score;
        Debug.Log("Gained Score " + scoreGain);
        return scoreGain;
    }

}
