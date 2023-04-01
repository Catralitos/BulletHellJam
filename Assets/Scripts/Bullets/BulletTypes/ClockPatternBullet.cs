using UnityEngine;

namespace Bullets.BulletTypes
{
    /// <summary>
    /// A class to set the Clock pattern enemies bullets' trajectory
    /// </summary>
    /// <seealso cref="Bullets.Bullet" />
    public class ClockPatternBullet : Bullet
    {
        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        /// <param name="angle">The angle.</param>
        public override void OnObjectSpawn(float angle)
        {

            float xForce = bulletSpeed * Mathf.Cos(angle);
            float yForce = bulletSpeed * Mathf.Sin(angle);
            Vector2 force = new Vector2(xForce, yForce);

            GetComponent<Rigidbody2D>().velocity = force;
        }
    }
}
