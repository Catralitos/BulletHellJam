using UnityEngine;

namespace Bullets.Spawners
{
    public class CubeBulletSpawner : MonoBehaviour
    {
        private BulletPooler _bulletPooler;

        private void Start()
        {
            _bulletPooler = BulletPooler.Instance;
            InvokeRepeating(nameof(Spawner), 0.0f, 0.5f);
        }

        private void Spawner()
        {
            _bulletPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        }
    
    }
}
