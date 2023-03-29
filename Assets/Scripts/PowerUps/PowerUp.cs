using Extensions;
using Player;
using UnityEngine;

namespace PowerUps
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class PowerUp : MonoBehaviour
    {
        /// <summary>
        /// The player mask
        /// </summary>
        public LayerMask playerMask;

        /// <summary>
        /// The player
        /// </summary>
        protected PlayerEntity Player = PlayerEntity.Instance;

        /// <summary>
        /// Called when [trigger enter2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!playerMask.HasLayer(other.gameObject.layer)) return;
            ApplyBonus();
            Destroy(gameObject);
        }

        /// <summary>
        /// Applies the bonus.
        /// </summary>
        protected abstract void ApplyBonus();
    }
}