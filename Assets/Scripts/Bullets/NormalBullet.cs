using UnityEngine;

namespace Bullets
{
    public class NormalBullet : Bullet
    {
        private void Start()
        {
            OnObjectSpawn();
        }

        public override void OnObjectSpawn()
        {
            Body.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}