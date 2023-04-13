using Extensions;
using Player;
using UnityEngine;

namespace PowerUps
{
    /// <summary>
    /// A class for powerups
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class PowerUp : MonoBehaviour
    {
        /// <summary>
        /// The player layer, for detecting collision
        /// </summary>
        public LayerMask playerMask;
        
        /// <summary>
        /// Called when [trigger enter2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            //If the player enters the powerup, apply the bonus and destroy the bonus
            if (!playerMask.HasLayer(other.gameObject.layer)) return;
            ApplyBonus();
            Destroy(gameObject);
        }

        /// <summary>
        /// Applies the bonus. Each powerup class will implement this differentl
        /// </summary>
        protected abstract void ApplyBonus();
    }
}