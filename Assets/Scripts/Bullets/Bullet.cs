using Extensions;
using Player;
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (damageables.HasLayer(col.gameObject.layer) && !col.isTrigger)
            {
                PlayerEntity.Instance.health.DoDamage();
            }

            if (gameObject.layer != col.gameObject.layer && !col.isTrigger) Destroy(gameObject);
        }

        public virtual void OnObjectSpawn()
        {
            //do nothing, each bullet will know what to do
        }
    }
}