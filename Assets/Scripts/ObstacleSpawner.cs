using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Prefabs")]
    public GameObject[] obstaclePrefabs;

    [Header("Spawn Timing")]
    public float spawnInterval = 2.2f;
    private float timer;

    [Header("Spawn Position Range")]
    public float spawnX = 12f;
    public float minY = -2.2f;
    public float maxY = 4.2f;

    [HideInInspector]
    public bool isSpawning = true;

    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomObstacle();
            timer = 0f;
        }
    }

    void SpawnRandomObstacle()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject prefabToSpawn = obstaclePrefabs[randomIndex];

        if (prefabToSpawn == null) return;

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0f);

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
