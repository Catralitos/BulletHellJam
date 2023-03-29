using UnityEngine;

namespace Enemies.Boss
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class BossEntity : MonoBehaviour
    {
        /// <summary>
        /// The boss
        /// </summary>
        [HideInInspector] public Boss boss;

        #region SingleTon

        /// <summary>
        /// The instance
        /// </summary>
        public static BossEntity Instance;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            Instance = this;
            boss = GetComponent<Boss>();
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