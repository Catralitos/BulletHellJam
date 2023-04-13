using UnityEngine;

namespace Player
{
    /// <summary>
    /// The class that handles firing projectiles
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class PlayerShooting : MonoBehaviour
    {
        /// <summary>
        /// The number of extra bullets powerups the player has
        /// </summary>
        [HideInInspector] public int plus2;
        /// <summary>
        /// The angle of the new bullet streams added with powerups
        /// </summary>
        public float bulletAngle = 30.0f;
        /// <summary>
        /// The number of fire rate powerups the player has
        /// </summary>
        [HideInInspector] public float currentFireRate;
        /// <summary>
        /// The current fire rate
        /// </summary>
        public float fireRate = 1.0f;

        /// <summary>
        /// The bullet prefab
        /// </summary>
        public GameObject bulletPrefab;
        /// <summary>
        /// The point where the bullets spawn
        /// </summary>
        public Transform firePoint;

        /// <summary>
        /// If the player can shoot
        /// </summary>
        private bool _canShoot = true;
        /// <summary>
        /// The time left until the player can shoot
        /// </summary>
        private float _timeLeft;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            //Sets the powerups to their initial values
            currentFireRate = 1 / fireRate;
            plus2 = 0;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update()
        {
            //Check if the player can shoot
            if (_timeLeft < 0) _canShoot = true;
            _timeLeft -= Time.deltaTime;
        }

        /// <summary>
        /// Shoots bullets
        /// </summary>
        public void Shoot()
        {
            if (!_canShoot) return;
            //If the player can shoot, we spawn a bullet
            Vector3 gunPosition = firePoint.position;
            Instantiate(bulletPrefab, gunPosition, firePoint.rotation);
            //If the player has powerups, we need to spawn 2 more bullets per powerup, in increments of bulletAngle
            for (var i = 0; i < plus2; i++)
            {
                var angles = firePoint.rotation.eulerAngles;
                var plus = angles + (i + 1) * this.bulletAngle * Vector3.forward;
                var minus = angles - (i + 1) * this.bulletAngle * Vector3.forward;
                Instantiate(bulletPrefab, gunPosition, Quaternion.Euler(plus));
                Instantiate(bulletPrefab, gunPosition, Quaternion.Euler(minus));
            }
            //Reset the cooldown
            _canShoot = false;
            _timeLeft = currentFireRate;
        }
    }
}