using UnityEngine;

namespace Bullets
{
    public class NormalBullet : Bullet
    {
        private void Start()
        {
            Body.AddForce(transform.up * BulletSpeed, ForceMode2D.Impulse);
        }
    }
}