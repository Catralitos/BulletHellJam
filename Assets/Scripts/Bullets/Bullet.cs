using Extensions;
using Player;
using Unity.Mathematics;
using UnityEngine;

namespace Bullets
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="Bullets.IPooledObject" />
    public class Bullet : MonoBehaviour, IPooledObject
    {
        //o script inimigo deteta balas do player para receber dano
        //logo este OnTrigger enter só é para magoar o player e destruir balas nas paredes
        //se calhar podia ser tudo aqui, mas usaria muitos get components/ifs
        //se calhar era mais simples mas agora nao sei como
        /// <summary>
        /// The player layer
        /// </summary>
        public LayerMask playerLayer;
        /// <summary>
        /// The walls
        /// </summary>
        public LayerMask walls;

        /// <summary>
        /// The explosion prefab
        /// </summary>
        public GameObject explosionPrefab;

        /// <summary>
        /// The destroy
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
        /// The body
        /// </summary>
        protected Rigidbody2D Body;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
        }

        //so para balas inimigas
        /// <summary>
        /// Called when [trigger enter2 d].
        /// </summary>
        /// <param name="col">The col.</param>
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (playerLayer.HasLayer(col.gameObject.layer) && !col.isTrigger && gameObject.layer != 6)
            {
                PlayerEntity.Instance.health.DoDamage();
            }

            if (!(walls.HasLayer(col.gameObject.layer) && !col.isTrigger)) return;
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