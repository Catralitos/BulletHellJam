using UnityEngine;

namespace Enemies.Boss
{
    /// <summary>
    /// A singleton so the Boss (and future related classes) can be easily accessible
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class BossEntity : MonoBehaviour
    {
        /// <summary>
        /// The boss class
        /// </summary>
        [HideInInspector] public Boss boss;

        #region SingleTon

        /// <summary>
        /// Returns the sole instance
        /// </summary>
        public static BossEntity Instance { get; private set; }

        /// <summary>
        /// Awakes this instance (if none exist already).
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                boss = GetComponent<Boss>();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        /// <summary>
        /// Called when [destroy].
        /// </summary>
        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}