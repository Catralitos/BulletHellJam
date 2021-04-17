using System;
using Extensions;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public LayerMask damagers;

        public int playerHits = 1;
        public int hitsLeft = 1;

        private void Start()
        {
            hitsLeft = playerHits;
        }

        public void DoDamage()
        {
            if (hitsLeft > 1) hitsLeft--;
            else Die();
            //animaçoes etc
        }

        private void Die()
        {
            Destroy(gameObject);
            //tocar animaçoes etc
        }
    }
}