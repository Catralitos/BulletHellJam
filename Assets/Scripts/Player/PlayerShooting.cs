using UnityEngine;

namespace Player
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class PlayerShooting : MonoBehaviour
    {
        /// <summary>
        /// The plus2
        /// </summary>
        [HideInInspector] public int plus2;
        /// <summary>
        /// The bullet angle
        /// </summary>
        public float bulletAngle = 30.0f;
        /// <summary>
        /// The current fire rate
        /// </summary>
        [HideInInspector] public float currentFireRate;
        /// <summary>
        /// The fire rate
        /// </summary>
        public float fireRate = 1.0f;

        /// <summary>
        /// The bullet prefab
        /// </summary>
        public GameObject bulletPrefab;
        /// <summary>
        /// The fire point
        /// </summary>
        public Transform firePoint;

        /// <summary>
        /// The can shoot
        /// </summary>
        private bool _canShoot = true;
        /// <summary>
        /// The time left
        /// </summary>
        private float _timeLeft;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            currentFireRate = 1 / fireRate;
            plus2 = 0;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update()
        {
            if (_timeLeft < 0) _canShoot = true;
            _timeLeft -= Time.deltaTime;
        }

        /// <summary>
        /// Shoots this instance.
        /// </summary>
        public void Shoot()
        {
            if (!_canShoot) return;
            var gunPosition = firePoint.position;
            Instantiate(bulletPrefab, gunPosition, firePoint.rotation);
            for (var i = 0; i < plus2; i++)
            {
                var angles = firePoint.rotation.eulerAngles;
                var plus = angles + (i + 1) * this.bulletAngle * Vector3.forward;
                var minus = angles - (i + 1) * this.bulletAngle * Vector3.forward;
                Instantiate(bulletPrefab, gunPosition, Quaternion.Euler(plus));
                Instantiate(bulletPrefab, gunPosition, Quaternion.Euler(minus));
            }

            _canShoot = false;
            _timeLeft = currentFireRate;
        }
    }
}