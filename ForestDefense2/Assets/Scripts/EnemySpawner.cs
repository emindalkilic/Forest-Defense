using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public Wave[] waves;
    public float timeBetweenWaves = 5f;
    public float timeAfterWaveComplete = 3f;

    private int currentWaveIndex = 0;
    private bool spawningWave = false;
    private float waveCountdown;
    private int enemiesAlive = 0;

    public WaveIndicator waveIndicator;

    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemyPrefabs;
        public int[] enemyCounts;
        public float spawnInterval = 1f;
    }

    void Start()
    {
        waveCountdown = timeBetweenWaves;

        if (waveIndicator != null)
        {
            waveIndicator.UpdateWaveText(1);
        }
    }

    void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            return;
        }

        if (!spawningWave && enemiesAlive == 0)
        {
            if (waveCountdown <= 0)
            {
                StartCoroutine(SpawnWave(waves[currentWaveIndex]));
                currentWaveIndex++;
                waveCountdown = timeAfterWaveComplete;
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        spawningWave = true;

        if (waveIndicator != null)
        {
            waveIndicator.UpdateWaveText(currentWaveIndex + 1);
        }

        for (int i = 0; i < wave.enemyPrefabs.Length; i++)
        {
            if (i >= wave.enemyPrefabs.Length || i >= wave.enemyCounts.Length)
            {
                continue;
            }

            for (int j = 0; j < wave.enemyCounts[i]; j++)
            {
                SpawnEnemy(wave.enemyPrefabs[i]);
                enemiesAlive++;
                yield return new WaitForSeconds(wave.spawnInterval);
            }
        }

        spawningWave = false;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            Path path = spawnPoint.GetComponent<Path>();
            if (path != null && path.waypoints != null && path.waypoints.Length > 0)
            {
                enemyMovement.SetPath(path.waypoints);
            }
        }

        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.OnDeath += () => {
                enemiesAlive--;
                Debug.Log("Enemy is dead. Remaining living enemy:: " + enemiesAlive);
            };
        }
    }
}