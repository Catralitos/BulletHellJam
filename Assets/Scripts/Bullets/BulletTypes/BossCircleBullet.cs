using UnityEngine;

namespace Bullets.BulletTypes
{
    public class BossCircleBullet : Bullet
    {
        
        private float angleStep = 0.1f;

        private float horizontalForce = 5.0f;
        private float verticalForce = 5.0f;
        private float angle = 0.0f;
        public override void OnObjectSpawn(float angle)
        { 

            float xForce = horizontalForce*Mathf.Cos(angle);
            float yForce = verticalForce*Mathf.Sin(angle);
            Vector2 force = new Vector2(xForce, yForce);

            //Update angle for next spawn
            angle = (angle + angleStep) % 360.0f;
            Debug.Log("Angle: " + angle.ToString());

            GetComponent<Rigidbody2D>().velocity = force;
        }
    }
}
