using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  Enemy Slime
 *  
 *  This script uses Inheritance to create a Slime Enemy type
 *  This enemy type can jump, and breaks into two smaller slimes when destroyed
 */

public class EnemySlime : EnemyHitTarget
{
    [SerializeField] private GameObject babySlime;
    Coroutine jumping;
    [SerializeField] int jumpRate = 2;

    //Get the playerlocation and begin the jump coroutine
    public override void Start()
    {
        base.Start();
        playerTarget = GameObject.Find("/Main Camera/PlayerLocation").transform;
        jumping = StartCoroutine(Jump());
        Move();
    }

    //Runs every 2 seconds and makes the thing jump by adding force so long as its on the ground
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(jumpRate);
        while (true)
        {
            if (gameObject.transform.position.y <= .4f)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 50);
                Debug.Log("Jumping");
            }
            yield return new WaitForSeconds(jumpRate);
        }
    }

    //If its the main slime, make two baby slimes and spawn them next to the main slime, otherwise destroy regularly
    public override void Destroy()
    {
        if (!gameObject.CompareTag("Baby Slime"))
        {
            Instantiate(babySlime, gameObject.transform.position + new Vector3(0.5f, 0.1f, 0f), Quaternion.identity);
            Instantiate(babySlime, gameObject.transform.position + new Vector3(-0.5f, 0.1f, 0f), Quaternion.identity);
        }
        StopCoroutine(jumping);
        base.Destroy();
    }
}
