using UnityEngine;

namespace Bullets.BulletTypes
{
    public class BossCircleBullet : Bullet
    {
        [SerializeField]
        public float angleStep = 5.0f;

        public float horizontalForce = 5.0f;
        public float verticalForce = 5.0f;
        private float angle = 0.0f;
        public override void OnObjectSpawn()
        { 

            float xForce = Mathf.Cos(horizontalForce + Time.deltaTime);
            float yForce = Mathf.Sin(-verticalForce, verticalForce);
            Vector2 force = new Vector2(xForce, yForce);

            GetComponent<Rigidbody2D>().velocity = force;
        }
    }
}
