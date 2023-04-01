using Extensions;
using Player;
using Unity.Mathematics;
using UnityEngine;

namespace Bullets
{
    /// <summary>
    /// A class for projectile behavior
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="Bullets.IPooledObject" />
    public class Bullet : MonoBehaviour, IPooledObject
    {
        
        /// <summary>
        /// The player layer
        /// </summary>
        public LayerMask playerLayer;
        /// <summary>
        /// The walls layer
        /// </summary>
        public LayerMask wallsLayer;

        /// <summary>
        /// The explosion prefab
        /// </summary>
        public GameObject explosionPrefab;

        /// <summary>
        /// If this projectile destroys itself on impact
        /// </summary>
        public bool destroy;
        /// <summary>
        /// The bullet damage
        /// </summary>
        public int bulletDamage = 1;
        /// <summary>
        /// The bullet speed
        /// </summary>
        public float bulletSpeed = 20.0f;

        /// <summary>
        /// The rigidbody
        /// </summary>
        protected Rigidbody2D body;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Called when [trigger enter2 d].
        /// </summary>
        /// <param name="col">The col.</param>
        private void OnTriggerEnter2D(Collider2D col)
        {
            //If the bullet touches the player, do damage
            //Layer 6 is the player bullets, so the player can't be hurt by their own bullets
            if (playerLayer.HasLayer(col.gameObject.layer) && !col.isTrigger && gameObject.layer != 6)
            {
                PlayerEntity.Instance.health.DoDamage();
            }

            //If it doesn't hit a wall, return
            if (!(wallsLayer.HasLayer(col.gameObject.layer) && !col.isTrigger)) return;
            //If it's set to destroy when it touches a wall, destroy it, otherwise, set inactive.
            if (!destroy) gameObject.SetActive(false);
            else Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, quaternion.identity);
        }

        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        public virtual void OnObjectSpawn()
        {
            //do nothing, each bullet will know what to do
        }

        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        /// <param name="angle">The angle.</param>
        public virtual void OnObjectSpawn(float angle)
        {
            //do nothing, each bullet will know what to do
        }

        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="maxAngleStep">The maximum angle step.</param>
        public virtual void OnObjectSpawn(float angle, float maxAngleStep)
        {
            //do nothing, each bullet will know what to do
        }
    }
}