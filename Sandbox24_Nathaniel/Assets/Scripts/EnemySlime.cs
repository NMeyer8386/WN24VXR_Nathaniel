using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyHitTarget
{
    [SerializeField] private GameObject babySlime;
    Coroutine jumping;

    public override void Start()
    {
        base.Start();
        playerTarget = GameObject.Find("PlayerLocation").transform;
        jumping = StartCoroutine(Jump());
        Move();
    }

    public override void Move()
    {
        base.Move();
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (gameObject.transform.position.y <= .4f)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 50);
                Debug.Log("Jumping");
            }
            yield return new WaitForSeconds(2f);
        }
    }

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
