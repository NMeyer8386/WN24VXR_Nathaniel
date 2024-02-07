using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitTarget : HitTarget
{
    [SerializeField] private int hitsToDestroy = 1;
    public Transform playerTarget;
    [SerializeField] private float moveSpeed = .5f;
    [SerializeField] protected float repeatRate = 1f;
 
    private int currentHits = 0;

    //Moves the thing
    void FixedUpdate()
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

            Invoke(nameof(Destroy), .5f);
        }

    }

    //If theres a player target set, move it by movespeed * time.deltatime
    public virtual void Move()
    {
        if (playerTarget == null) { return; }

        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);  //MoveTowards(CurrentPos, TargetPos, Speed)
    }

    //This is where attack code will go
    private void Attack()
    {
        Debug.Log(gameObject.name + " is attacking Player", gameObject);
    }

    //If thing hits the player, run the attack function every second
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InvokeRepeating("Attack", 1f, repeatRate);
        }
    }

    //Add passed score to the total
    public override int CalcScore(int score)
    {
        int scoreGain = hitsToDestroy * score;
        Debug.Log("Gained Score " + scoreGain);
        return scoreGain;
    }

}
