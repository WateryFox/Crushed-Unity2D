using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;
    public float platformSpawnTimer = 2f;
    private float currentPlatformSpawnTimer;
    public int platformSpawnCount;
    public float minX = -2f, maxX = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPlatform();
    }

    void spawnPlatform()
    {
        // print("spawn1");
        currentPlatformSpawnTimer += Time.deltaTime;
        if (currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            // print(currentPlatformSpawnTimer);
            platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = UnityEngine.Random.Range(minX, maxX);
            GameObject newPlatform = null;
            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platformSpawnCount == 2)
            {
                if (UnityEngine.Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[UnityEngine.Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 3)
            {
                if (UnityEngine.Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (UnityEngine.Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }
                platformSpawnCount = 0;
            }
            newPlatform.transform.parent = transform;
            currentPlatformSpawnTimer = 0f;
        }
    }
}
