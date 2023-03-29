using UnityEngine;

namespace Bullets.BulletTypes
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Bullets.Bullet" />
    public class ClusterBullet : Bullet
    {
        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="maxAngleStep">The maximum angle step.</param>
        public override void OnObjectSpawn(float angle, float maxAngleStep)
        {

            float xForce = bulletSpeed * Mathf.Cos(Random.Range(angle - maxAngleStep, angle + maxAngleStep));
            float yForce = bulletSpeed * Mathf.Sin(Random.Range(angle - maxAngleStep, angle + maxAngleStep));
            Vector2 force = new Vector2(xForce, yForce);

            GetComponent<Rigidbody2D>().velocity = force;
        }
    }
}
