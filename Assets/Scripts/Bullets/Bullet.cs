using Extensions;
using Player;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour, IPooledObject
    {
        public LayerMask damageables;
        public LayerMask walls;
        
        public float bulletSpeed = 20.0f;
        public int bulletDamage = 1;

        protected Rigidbody2D Body;

        private void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            /*if (damageables.HasLayer(col.gameObject.layer) && !col.isTrigger)
            {
                PlayerEntity.Instance.health.DoDamage();
            }*/

            if (walls.HasLayer(col.gameObject.layer) && !col.isTrigger) Destroy(gameObject);
        }

        public virtual void OnObjectSpawn()
        {
            //do nothing, each bullet will know what to do
        }
    }
}