using System.Collections.Generic;
using Enemies.Boss;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Spawns waves of enemies
    /// </summary>
    public class WaveSpawner : MonoBehaviour
    {
        /// <summary>
        /// The spawn obstructions
        /// </summary>
        public LayerMask obstructions;
        /// <summary>
        /// The waves before a new pool of bullets is added to the boss
        /// </summary>
        public int wavesBeforeAddedBossPool = 10;
        /// <summary>
        /// The enemy growth factor
        /// </summary>
        public float enemyGrowthFactor = 2;
        /// <summary>
        /// The maximum number of enemies
        /// </summary>
        public int maxNumberEnemies;
        /// <summary>
        /// The minimum orbiter radius
        /// </summary>
        public int minOrbiterRadius = 7;
        /// <summary>
        /// The maximum orbiter radius
        /// </summary>
        public int maxOrbiterRadius = 15;
        /// <summary>
        /// The circle collider check radius
        /// </summary>
        public float colliderRadius = 0.01f;
        /// <summary>
        /// The turret to orbiter ratio
        /// </summary>
        public float turretToOrbiterRatio = 0.75f;
        /// <summary>
        /// The orbiter prefabs
        /// </summary>
        public List<GameObject> orbiterPrefabs;
        /// <summary>
        /// The turret prefabs
        /// </summary>
        public List<GameObject> turretPrefabs;
        /// <summary>
        /// The turret positions
        /// </summary>
        public List<Transform> turretPositions;

        /// <summary>
        /// The current number of enemies
        /// </summary>
        private int _currentNumEnemies = 2;
        /// <summary>
        /// The current wave
        /// </summary>
        private int _currentWave = 1;
        /// <summary>
        /// The number of orbiter types
        /// </summary>
        private int _numOrbiters;
        /// <summary>
        /// The number of orbiter positions
        /// </summary>
        private int _numOrbiterPositions;
        /// <summary>
        /// The number of turret positions
        /// </summary>
        private int _numTurretPositions;
        /// <summary>
        /// The number of turret types
        /// </summary>
        private int _numTurrets;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            _numOrbiters = orbiterPrefabs.Count;
            _numOrbiterPositions = (maxOrbiterRadius - minOrbiterRadius) - 4;
            _numTurretPositions = turretPositions.Count;
            _numTurrets = turretPrefabs.Count;
        }

        /// <summary>
        /// Spawns the next wave.
        /// </summary>
        public void SpawnNextWave()
        {
            //First we check how many of each enemy we want to spawn
            var turretsToSpawn = Mathf.RoundToInt(turretToOrbiterRatio * _currentNumEnemies);
            var orbitersToSpawn = _currentNumEnemies - turretsToSpawn;

            //For each turret we want to spawn
            for (var i = 0; i < turretsToSpawn; i++)
            {
                //We pick a turret type to spawn
                var toSpawn = turretPrefabs[Random.Range(0, _numTurrets)];
                //Randomly pick one of the available spawn positions
                var randomPoint = turretPositions[Random.Range(0, _numTurretPositions)];
                //And check if there is already an obstacle at that position
                bool overlap = Physics2D.OverlapCircle(randomPoint.position, colliderRadius, obstructions);
                //We also keep a counter to make sure the while can end
                int c = 0;
                //If there is already an obstacle, pick another random point. If all positions have been exhausted, stop.
                while (overlap && c < _numTurretPositions)
                {
                    randomPoint = turretPositions[Random.Range(0, _numTurretPositions)];
                    overlap = Physics2D.OverlapCircle(randomPoint.position, colliderRadius, obstructions);
                    c++;
                }
                
                //If the while ended solely because there was no overlap, spawn the turret
                if (c < _numTurretPositions) Instantiate(toSpawn, randomPoint.position, Quaternion.identity);
            }

            //Orbiter code is identical, except that they can spawn a certain distance away from the boss and orbit around it
            for (var i = 0; i < orbitersToSpawn; i++)
            {
                var toSpawn = orbiterPrefabs[Random.Range(0, _numOrbiters)];
                var randomXRange = Random.Range(minOrbiterRadius, maxOrbiterRadius + 1);
                randomXRange = Random.Range(0, 2) == 1 ? randomXRange : -randomXRange;
                var spawn = Random.Range(0, 2) == 1 ? new Vector3(0, randomXRange, 0) : new Vector3(randomXRange, 0, 0);
                bool overlap = Physics2D.OverlapCircle(spawn, colliderRadius, obstructions);
                var c = 0;
                while (overlap && c < _numOrbiterPositions)
                {
                    randomXRange = Random.Range(minOrbiterRadius, maxOrbiterRadius + 1);
                    randomXRange = Random.Range(0, 2) == 1 ? randomXRange : -randomXRange;
                    spawn = Random.Range(0, 2) == 1 ? new Vector3(0, randomXRange, 0) : new Vector3(randomXRange, 0, 0);
                    overlap = Physics2D.OverlapCircle(spawn, colliderRadius, obstructions);
                    c++;
                }

                if (c < _numOrbiterPositions) Instantiate(toSpawn, spawn, Quaternion.identity);
            }

            _currentWave++;
            //Calculate the number of enemies in the next wave
            float f = Mathf.Pow(_currentWave, 1.0f / enemyGrowthFactor);
            _currentNumEnemies = Mathf.RoundToInt(Mathf.Clamp(f, 1, maxNumberEnemies));
            //If enough waves have passed, increase boss' attacks
            if (_currentWave % wavesBeforeAddedBossPool == 0)
            {
                BossEntity.Instance.boss.IncreaseActivePools();
            }
        }
    }
}