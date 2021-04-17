using UnityEngine;

namespace Bullets.Spawners
{
    public class CircleBulletSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, 0.2f);
        }

        private void Spawner()
        {
            _bulletPooler.SpawnFromPool("Circles", transform.position, Quaternion.identity);
        }
    }
}
