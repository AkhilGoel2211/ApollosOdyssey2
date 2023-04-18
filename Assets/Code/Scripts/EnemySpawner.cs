using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // The enemy prefab to spawn
    [SerializeField] private float spawnInterval = 1f; // The time between each enemy spawn
    [SerializeField] private int enemiesPerWave = 6; // The number of enemies to spawn in each wave -> can be made increasing
    [SerializeField] private int numberOfWaves = 10; // The total number of waves to spawn
    [SerializeField] private float waveInterval = 15f; // The time between each wave
    [SerializeField] private Terrain landscape;
    [SerializeField] private Transform player;

    private PopupMessage messageScript;

    private int currentWave = 0; // The current wave number
    private int enemiesSpawned = 0; // The number of enemies spawned in the current wave
    private bool isSpawning = false; // Whether enemies are currently being spawned

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
        messageScript = GameObject.Find("Popup").GetComponent<PopupMessage>();
    }

    private IEnumerator SpawnEnemies()
    {
        // Wait for the wave interval before starting the first wave
        yield return new WaitForSeconds(waveInterval);

        // Loop through all the waves
        for (int i = 0; i < numberOfWaves; i++)
        {
            currentWave++; // Increment the wave number
            enemiesSpawned = 0; // Reset the number of enemies spawned in the wave
            enemiesPerWave += 10;
            messageScript.AddToQueue("New Wave Incoming! BEWARE!!");

            // Loop through all the enemies in the wave
            while (enemiesSpawned < enemiesPerWave)
            {
                // Spawn an enemy
                var randomSpawnPoint = (Vector3)Random.insideUnitCircle * 50;
                if (randomSpawnPoint.z <= 140.1222 && randomSpawnPoint.z >= -106.3778 && randomSpawnPoint.x <= 144.5722 && randomSpawnPoint.x >= -102.7278)
                {
                    randomSpawnPoint = randomSpawnPoint;
                    randomSpawnPoint += player.position;
                }
                else
                {
                    randomSpawnPoint = landscape.transform.position;
                }
                // Vector3 randomSpawnPoint = new Vector3(Random.Range(-4f, 8f), 0f, Random.Range(0f, 4f));
                randomSpawnPoint.y = landscape.SampleHeight(randomSpawnPoint) + landscape.transform.position.y;
                GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
                enemiesSpawned++;

                // Wait for the spawn interval before spawning the next enemy
                yield return new WaitForSeconds(spawnInterval);
            }

            // Wait for the wave interval before starting the next wave
            yield return new WaitForSeconds(waveInterval);
        }

        // All waves have been spawned
        isSpawning = false;
    }
}


