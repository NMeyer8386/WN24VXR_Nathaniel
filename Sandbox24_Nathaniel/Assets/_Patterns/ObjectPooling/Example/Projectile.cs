//#define OBJECT_POOL
/*  ^^^ This is preprocessing
 *  You can define it at the beginning of the script
 *  and can run code depending on if it is present in the script 
 *  (the code inside #if OBJECT_POOL will not run if #define OBJECT_POOL is commented out)
 *  Can be used to identify platforms (run x code on quest, run y code on PCVR)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// This class is a simple projectile 
/// </summary>
namespace Examples.ObjectPooling
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float _travelSpeed = 5f;

        private Rigidbody _rigidbody = null;

        #if OBJECT_POOL
        private IObjectPool<Projectile> projectilePool;
        public void SetPool(IObjectPool<Projectile>pool)
        {
             projectilePool = pool;
        }
        #endif

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Travel(_rigidbody);
        }

        protected void Travel(Rigidbody rb)
        {
            Vector3 moveOffset = transform.forward * _travelSpeed;
            rb.MovePosition(rb.position + moveOffset);
        }

        private void OnBecameInvisible()
        {
            #if OBJECT_POOL
            projectilePool.Release(this);
            #else
            Destroy(gameObject); //TODO consider Object Pooling here
            #endif
        }
    }
}

