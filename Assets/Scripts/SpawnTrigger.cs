using UnityEngine;

public class SpawnTrigger : Base
{
    [SerializeField] Collider[] spawnAreas;

    bool hasSpawned = false;

    // Spawn enemy wave on trigger
    public override void OnTriggerHandler()
    {
        if (!hasSpawned)
        {
            SpawnEnemyWave();
            hasSpawned = true;
        }
    }

    // Spawn enemies in each spawn area
    void SpawnEnemyWave()
    {
        for (int i = 0; i < spawnAreas.Length; i++)
        {
            GameObject pooledEnemy = SpawnManager.Instance.GetPooledObject();

            if (pooledEnemy != null)
            {
                pooledEnemy.SetActive(true);
                pooledEnemy.transform.position = GetSpawnPos(spawnAreas[i]);
            }
        }
    }

    // Get a random spawn position in the given area
    Vector3 GetSpawnPos(Collider area)
    {
        float xPos = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float zPos = Random.Range(area.bounds.min.z, area.bounds.max.z);

        return new Vector3(xPos, area.transform.position.y + 0.5f, zPos);
    }
}
