using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        public LayerMask Damageables;
        
        public float BulletSpeed = 20.0f;
        public int BulletDamage = 1;
        
        protected Rigidbody2D Body;

        private void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (Damageables.value == other.gameObject.layer)
            {
                //do damage
            }
            
            Destroy(gameObject);
        }
    }
}