using UnityEngine;

namespace Enemies.Base
{
    /// <summary>
    /// 
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
        /// States the start.
        /// </summary>
        public virtual void StateStart()
        {
            Initialized = true;
        }

        /// <summary>
        /// States the update.
        /// </summary>
        public virtual void StateUpdate()
        {
        }

        /// <summary>
        /// States the fixed update.
        /// </summary>
        public virtual void StateFixedUpdate()
        {
        }

        /// <summary>
        /// Called when [get hit].
        /// </summary>
        public virtual void OnGetHit()
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEnemyType">The type of the enemy type.</typeparam>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class EnemyState<TEnemyType> : EnemyState where TEnemyType : EnemyBase<TEnemyType>
    {
        /// <summary>
        /// The target
        /// </summary>
        protected TEnemyType Target;

        /// <summary>
        /// Creates the specified target.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        protected static T Create<T>(TEnemyType target) where T : EnemyState<TEnemyType>
        {
            T state = target.gameObject.AddComponent<T>();
            state.Target = target;
            return state;
        }

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="state">The state.</param>
        protected void SetState(EnemyState<TEnemyType> state)
        {
            Target.SetState(state);
            Destroy(this);
        }
    }
}