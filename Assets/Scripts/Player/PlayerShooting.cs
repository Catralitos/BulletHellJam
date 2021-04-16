using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        public float fireRate = 1.0f;
        public float timeLeft = 0.0f;

        public List<GameObject> bulletPrefabs;
        public Transform firePoint;

        private bool _canShoot = true;
        private int _currentBullet = 0;

        private void Update()
        {
            if (timeLeft < 0) _canShoot = true;
            timeLeft -= Time.deltaTime;
        }


        public void Shoot()
        {
            if (!_canShoot) return;
            Instantiate(bulletPrefabs[_currentBullet], firePoint.position, firePoint.rotation);
            _canShoot = false;
            timeLeft = fireRate;
        }
    }
}