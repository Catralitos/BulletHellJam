using System;
using Extensions;
using Managers;
using Player;
using UnityEngine;

namespace Bullets
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class BulletDodge : MonoBehaviour
    {
        //isto pode implicar comparar a vida inicial com a final e 
        //nao congelar o tempo se ele recebeu um hit.
        //vou assumir por agora que só tens um hit
        /// <summary>
        /// The bullets mask
        /// </summary>
        public LayerMask bulletsMask;

        /// <summary>
        /// The freeze multiplier
        /// </summary>
        public float freezeMultiplier = 3.5f;

        /// <summary>
        /// The time freeze
        /// </summary>
        private float _timeFreeze;

        /// <summary>
        /// Called when [trigger enter2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (bulletsMask.HasLayer(other.gameObject.layer)) Debug.Log("Trigger enter");        
        }

        /// <summary>
        /// Called when [trigger stay2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerStay2D(Collider2D other)
        {
            if (bulletsMask.HasLayer(other.gameObject.layer)) _timeFreeze += Time.deltaTime;;
        }

        /// <summary>
        /// Called when [trigger exit2 d].
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!bulletsMask.HasLayer(other.gameObject.layer)) return;
            Debug.Log("Trigger exited " + _timeFreeze * freezeMultiplier);
            TimeManager.Instance.FreezeTime(_timeFreeze * freezeMultiplier);
            _timeFreeze = 0f;
        }
    }
}