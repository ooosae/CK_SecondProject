using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int numberOfEnemies = 20;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        Vector3 planeSize = GetComponent<Renderer>().bounds.size;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 randomPoint = RandomPointOnPlane(planeSize);
            Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
        }
    }

    Vector3 RandomPointOnPlane(Vector3 planeSize)
    {
        float randomX = Random.Range(-planeSize.x / 2f, planeSize.x / 2f);
        float randomZ = Random.Range(-planeSize.z / 2f, planeSize.z / 2f);

        Vector3 randomPoint = transform.position + new Vector3(randomX, 0f, randomZ);

        return randomPoint;
    }
}
