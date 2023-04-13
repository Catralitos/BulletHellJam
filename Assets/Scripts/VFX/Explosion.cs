using UnityEngine;

namespace VFX
{
    /// <summary>
    /// An explosion that spawns when projectiles hit
    /// </summary>
    public class Explosion : MonoBehaviour
    {
        /// <summary>
        /// The time active
        /// </summary>
        public float timeActive;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            //The explosion has a default animation that plays when it's spawned.
            //So all we have to do is destroy the object after a while
            Invoke(nameof(Terminate), timeActive);
        }

        /// <summary>
        /// Terminates this instance.
        /// </summary>
        private void Terminate()
        {
            Destroy(gameObject);
        }
    }
}
