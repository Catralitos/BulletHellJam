using Audio;
using UnityEngine;

namespace Bullets.BulletTypes
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Bullets.Bullet" />
    public class NormalBullet : Bullet
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            OnObjectSpawn();
        }

        /// <summary>
        /// Called when [object spawn].
        /// </summary>
        public override void OnObjectSpawn()
        {
            Body.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
            AudioManager.Instance.Play("PlayerFire");
        }
    }
}