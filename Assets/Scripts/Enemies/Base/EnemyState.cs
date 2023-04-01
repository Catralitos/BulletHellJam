using UnityEngine;

namespace Enemies.Base
{
    /// <summary>
    /// A class that defines the state of an enemy
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class EnemyState : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnemyState"/> is initialized.
        /// </summary>
        /// <value>
        ///   <c>true</c> if initialized; otherwise, <c>false</c>.
        /// </value>
        public bool Initialized { get; protected set; }

        /// <summary>
        /// Starts the state.
        /// </summary>
        public virtual void StateStart()
        {
            Initialized = true;
        }

        /// <summary>
        /// Updates the state.
        /// </summary>
        public virtual void StateUpdate()
        {
        }

        /// <summary>
        /// Updates the state at a fixed interval.
        /// </summary>
        public virtual void StateFixedUpdate()
        {
        }
    }

    /// <summary>
    /// Every EnemyState inherits from this class.
    /// This class allows it to easily create the new state
    /// And destroy the old one
    /// </summary>
    /// <typeparam name="TEnemyType">The type of the enemy type.</typeparam>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class EnemyState<TEnemyType> : EnemyState where TEnemyType : EnemyBase<TEnemyType>
    {
        /// <summary>
        /// The target enemy, i.e., the one which the state will be appended to
        /// </summary>
        protected TEnemyType target;

        /// <summary>
        /// Creates the specified state.
        /// </summary>
        /// <typeparam name="T">The state</typeparam>
        /// <param name="target">The target enemy.</param>
        /// <returns></returns>
        protected static T Create<T>(TEnemyType target) where T : EnemyState<TEnemyType>
        {
            T state = target.gameObject.AddComponent<T>();
            state.target = target;
            return state;
        }

        /// <summary>
        /// Sets the state and deletes the old one.
        /// </summary>
        /// <param name="state">The state.</param>
        protected void SetState(EnemyState<TEnemyType> state)
        {
            target.SetState(state);
            Destroy(this);
        }
    }
}