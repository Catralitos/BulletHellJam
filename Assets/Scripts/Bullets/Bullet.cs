using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour, IPooledObject
    {
        public LayerMask damageables;
        
        public float bulletSpeed = 20.0f;
        public int bulletDamage = 1;
        
        protected Rigidbody2D Body;

        private void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (damageables.value == other.gameObject.layer)
            {
                //do damage
            }
            
            Destroy(gameObject);
        }

        public virtual void OnObjectSpawn()
        {
            //do nothing, each bullet will know what to do
        }
    }
}