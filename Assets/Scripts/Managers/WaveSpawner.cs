using System.Collections.Generic;
using Enemies.Boss;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class WaveSpawner : MonoBehaviour
    {
        /// <summary>
        /// The obstructions
        /// </summary>
        public LayerMask obstructions;
        /// <summary>
        /// The waves before added boss pool
        /// </summary>
        public int wavesBeforeAddedBossPool = 10;
        /// <summary>
        /// The enemy growth factor
        /// </summary>
        public float enemyGrowthFactor = 2;
        /// <summary>
        /// The maximum number enemies
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
        /// The circle width
        /// </summary>
        public float circleWidth = 0.01f;
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
        /// The current number enemies
        /// </summary>
        private int _currentNumEnemies = 2;
        /// <summary>
        /// The current wave
        /// </summary>
        private int _currentWave = 1;
        /// <summary>
        /// The number orbiters
        /// </summary>
        private int _numOrbiters;
        /// <summary>
        /// The number orbiter positions
        /// </summary>
        private int _numOrbiterPositions;
        /// <summary>
        /// The number turret positions
        /// </summary>
        private int _numTurretPositions;
        /// <summary>
        /// The number turrets
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
            var turretsToSpawn = Mathf.RoundToInt(turretToOrbiterRatio * _currentNumEnemies);
            var orbitersToSpawn = _currentNumEnemies - turretsToSpawn;

            for (var i = 0; i < turretsToSpawn; i++)
            {
                var toSpawn = turretPrefabs[Random.Range(0, _numTurrets)];
                var randomPoint = turretPositions[Random.Range(0, _numTurretPositions)];
                bool overlap = Physics2D.OverlapCircle(randomPoint.position, circleWidth, obstructions);
                var c = 0;
                while (overlap && c < _numTurretPositions)
                {
                    randomPoint = turretPositions[Random.Range(0, _numTurretPositions)];
                    overlap = Physics2D.OverlapCircle(randomPoint.position, circleWidth, obstructions);
                    c++;
                }

                if (c < _numTurretPositions) Instantiate(toSpawn, randomPoint.position, Quaternion.identity);
            }

            for (var i = 0; i < orbitersToSpawn; i++)
            {
                var toSpawn = orbiterPrefabs[Random.Range(0, _numOrbiters)];
                var randomXRange = Random.Range(minOrbiterRadius, maxOrbiterRadius + 1);
                randomXRange = Random.Range(0, 2) == 1 ? randomXRange : -randomXRange;
                var spawn = Random.Range(0, 2) == 1 ? new Vector3(0, randomXRange, 0) : new Vector3(randomXRange, 0, 0);
                bool overlap = Physics2D.OverlapCircle(spawn, circleWidth, obstructions);
                var c = 0;
                while (overlap && c < _numOrbiterPositions)
                {
                    randomXRange = Random.Range(minOrbiterRadius, maxOrbiterRadius + 1);
                    randomXRange = Random.Range(0, 2) == 1 ? randomXRange : -randomXRange;
                    spawn = Random.Range(0, 2) == 1 ? new Vector3(0, randomXRange, 0) : new Vector3(randomXRange, 0, 0);
                    overlap = Physics2D.OverlapCircle(spawn, circleWidth, obstructions);
                    c++;
                }

                if (c < _numOrbiterPositions) Instantiate(toSpawn, spawn, Quaternion.identity);
            }

            _currentWave++;
            var f = Mathf.Pow(_currentWave, 1.0f / enemyGrowthFactor);
            _currentNumEnemies = Mathf.RoundToInt(Mathf.Clamp(f, 1, maxNumberEnemies));
            if (_currentWave % wavesBeforeAddedBossPool == 0)
            {
                BossEntity.Instance.boss.IncreaseActivePools();
            }
        }
    }
}