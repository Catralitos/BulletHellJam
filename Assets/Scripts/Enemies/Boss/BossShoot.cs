using System;
using System.Collections.Generic;
using Audio;
using Bullets.Spawners;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Boss
{
    /// <summary>
    /// The boss shooting state
    /// </summary>
    /// <seealso cref="Enemies.Boss.BossState" />
    public class BossShoot : BossState
    {
        /// <summary>
        /// The cooldown left
        /// </summary>
        private float _cooldownLeft;
        /// <summary>
        /// The current poo list
        /// </summary>
        private List<String> _currentPooList = new List<string>();

        /// <summary>
        /// Creates the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static BossShoot Create(Boss target)
        {
            var state = BossState.Create<BossShoot>(target);
            return state;
        }

        /// <summary>
        /// States the start.
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = target.phaseCooldown;
        }

        /// <summary>
        /// States the update.
        /// </summary>
        public override void StateUpdate()
        {

            var sign = target.clockwise ? -1 : 1;
            transform.Rotate(sign * target.rotateSpeed * Time.deltaTime * Vector3.forward);
            _cooldownLeft -= Time.deltaTime;
        }

        /// <summary>
        /// Switches the boss's attack
        /// He starts spinning in the opposite direction
        /// Selects the active bullet pools
        /// And Attacks
        /// </summary>
        public void BossSwitch()
        {
            target.clockwise = !target.clockwise;
            SetActivePools();
            Attack();
        }

        /// <summary>
        /// Sets the active bullet pools, by creating a shuffled list with the options
        /// </summary>
        private void SetActivePools()
        {
            _currentPooList.Clear();
            int[] poolNumbers = new int[target.bulletPools.Count];

            for (var i = 0; i < poolNumbers.Length; i++)
            {
                poolNumbers[i] = i;
            }

            Reshuffle(poolNumbers);
            for (var i = 0; i < target.numActivePools; i++)
            {
                _currentPooList.Add(target.bulletPools[poolNumbers[i]]);
            }
        }

        /// <summary>
        /// Boss attack
        /// </summary>
        private void Attack()
        {
            AudioManager.Instance.Play("EvilLaugh");
            List<string> pools = target.bulletPools;
            List<Spawner> spawners = target.spawners;
            //For each of the bullet pools
            for (var i = 0; i < target.bulletPools.Count; i++)
            {
                //If it is one of the picked current pools
                //Set the corresponding bullet spawner to active
                if (_currentPooList.Contains(pools[i]))
                {
                    switch (i)
                    {
                        //A switch-case isn't really necessary here
                        //But given that in case 3, we have to set the value of a parameters
                        //We did all of them in a switch-case in case another required something like that
                        case 0:
                            ClusterSpawner clusterSpawner = (ClusterSpawner) spawners[i];
                            clusterSpawner.active = true;
                            break;
                        case 1:
                            RingPatternSpawner2 ringSpawner = (RingPatternSpawner2) spawners[i];
                            ringSpawner.active = true;
                            break;
                        case 2:
                            ShockwaveRingSpawner shockSpawner = (ShockwaveRingSpawner) spawners[i];
                            shockSpawner.active = true;
                            break;
                        case 3:
                            ClockPatternSpawner clockSpawner = (ClockPatternSpawner) spawners[i];
                            clockSpawner.directions = Random.Range(1, 5);
                            clockSpawner.active = true;
                            break;
                        case 4:
                            PiramidalPatternSpawner pyramidSpawner = (PiramidalPatternSpawner) spawners[i];
                            pyramidSpawner.active = true;
                            break;
                    }
                }
                //Else, make them inactive
                else
                {
                    var spawner = spawners[i];
                    spawner.active = false;
                }
            }
        }


        /// <summary>
        /// Reshuffles the specified numbers.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        private static void Reshuffle(IList<int> numbers)
        {
            // Knuth shuffle algorithm :: courtesy of Wikipedia :)
            for (int t = 0; t < numbers.Count; t++)
            {
                int tmp = numbers[t];
                int r = Random.Range(t, numbers.Count);
                numbers[t] = numbers[r];
                numbers[r] = tmp;
            }
        }
    }
}