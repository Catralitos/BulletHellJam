using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        public List<GameObject> bulletPrefabs;
        public Transform firePoint;
        
        private int _currentBullet = 0;
        public void Shoot()
        { 
            //a força mais vale meter on awake em cada bala, para padroes diferentes
            Instantiate(bulletPrefabs[_currentBullet], firePoint.position, firePoint.rotation);
        }
    }
}