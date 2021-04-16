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

        private int _currentBullet = 0;
        private bool _canShoot = true;

        private void Update()
        {
            if (timeLeft < 0) _canShoot = true;
            timeLeft -= Time.deltaTime;
        }


        public void Shoot()
        {
            //Debug.Log("Shoot chamado");
            //a força mais vale meter on awake em cada bala, para padroes diferentes
            if (!_canShoot) return;
            Instantiate(bulletPrefabs[_currentBullet], firePoint.position, firePoint.rotation);
            _canShoot = false;
            timeLeft = fireRate;
        }
    }
}