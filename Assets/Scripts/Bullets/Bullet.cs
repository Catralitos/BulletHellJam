using Extensions;
using Player;
using UnityEngine;

namespace Bullets
{
    public class Bullet : MonoBehaviour, IPooledObject
    {
        //o script inimigo deteta balas do player para receber dano
        //logo este OnTrigger enter só é para magoar o player e desturi balas nas paredes
        //se calhar podia ser tudo aqui, mas usaria muitos get components/ifs
        //se calhar era mais simples mas agora nao sei como
        public LayerMask playerLayer;
        public LayerMask walls;
        
        public float bulletSpeed = 20.0f;
        public int bulletDamage = 1;

        protected Rigidbody2D Body;

        private void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
        }

        //so para balas inimigas
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (playerLayer.HasLayer(col.gameObject.layer) && !col.isTrigger)
            {
                PlayerEntity.Instance.health.DoDamage();
            }

            if (walls.HasLayer(col.gameObject.layer) && !col.isTrigger) gameObject.SetActive(false);
        }

        public virtual void OnObjectSpawn()
        {
            //do nothing, each bullet will know what to do
        }
    }
}