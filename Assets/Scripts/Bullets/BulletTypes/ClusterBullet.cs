using UnityEngine;

namespace Bullets.BulletTypes
{
    public class ClusterBullet : Bullet
    {
        private float horizontalForce = 3.0f;
        private float verticalForce = 0.5f;
        public override void OnObjectSpawn()
        {

            float xForce = Mathf.Sin(horizontalForce + Time.deltaTime);
            float yForce = Random.Range(-verticalForce, verticalForce);
            Vector2 force = new Vector2(xForce, yForce);

            GetComponent<Rigidbody2D>().velocity = force;
        }
    }
}
