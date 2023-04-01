using Extensions;
using Managers;
using UnityEngine;

namespace Bullets
{
    /// <summary>
    /// Adds a bullet dodge mechanic.
    /// When a player grazes a bullet but isn't hit by them
    /// Time freezes temporarily
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class BulletDodge : MonoBehaviour
    {

        /// <summary>
        /// The enemy bullets layer
        /// </summary>
        public LayerMask bulletsMask;

        /// <summary>
        /// The freeze multiplier
        /// </summary>
        public float freezeMultiplier = 3.5f;

        /// <summary>
        /// How much frozen time is left
        /// </summary>
        private float _timeFreeze;
        
        /// <summary>
        /// Called when [trigger stay2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerStay2D(Collider2D other)
        {
            //For each frame, add that time interval to the frozen time
            if (bulletsMask.HasLayer(other.gameObject.layer)) _timeFreeze += Time.deltaTime;;
        }

        /// <summary>
        /// Called when [trigger exit2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!bulletsMask.HasLayer(other.gameObject.layer)) return;
            //When the player exits the bullet's trigger, time is frozen
            Debug.Log("Trigger exited " + _timeFreeze * freezeMultiplier);
            TimeManager.Instance.FreezeTime(_timeFreeze * freezeMultiplier);
            _timeFreeze = 0f;
        }
    }
}