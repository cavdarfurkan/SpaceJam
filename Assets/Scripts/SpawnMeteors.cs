using System.Collections;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    private float minY = -4.50f;
    private float maxY = 4.50f;
    [Range(-4.50f, 4.50f)] public float spawnY = 0f;
    public bool isRandomSpawn = true;

    public GameObject smallMeteor;
    public GameObject largeMeteor;

    public float smallMeteorSpawnSpeed; // in seconds
    public float largeMeteorSpawnSpeed; //in seconds

    private bool isSmallCoroutineExecuting = false;
    private bool isLargeCoroutineExecuting = false;

    void Start()
    {
        smallMeteorSpawnSpeed = 2.0f;
        largeMeteorSpawnSpeed = smallMeteorSpawnSpeed * 3.0f;
    }

    void Update()
    {
        StartCoroutine(SmallMeteorSpawner());
        StartCoroutine(LargeMeteorSpawner());
    }

    IEnumerator SmallMeteorSpawner()
    {
        // If Coroute is not over yet, break the new one until the other is done.
        if (isSmallCoroutineExecuting)
        {
            yield break;
        }

        isSmallCoroutineExecuting = true;
        // Set the Y position of the spawner
        if (isRandomSpawn)
        {
            spawnY = Random.Range(minY, maxY);
        }
        transform.position = new Vector3(transform.position.x, spawnY, transform.position.z);

        // Initiate the meteor from spawner
        Instantiate(smallMeteor, transform.position, Quaternion.identity);

        // Wait for some time
        yield return new WaitForSeconds(smallMeteorSpawnSpeed);
        isSmallCoroutineExecuting = false;
    }

    IEnumerator LargeMeteorSpawner()
    {
        // If Coroute is not over yet, break the new one until the other is done.
        if (isLargeCoroutineExecuting)
        {
            yield break;
        }

        isLargeCoroutineExecuting = true;
        // Set the Y position of the spawner
        if (isRandomSpawn)
        {
            spawnY = Random.Range(minY, maxY);
        }
        transform.position = new Vector3(transform.position.x, spawnY, transform.position.z);

        // Initiate the meteor from spawner
        Instantiate(largeMeteor, transform.position, Quaternion.identity);

        // Wait for some time
        yield return new WaitForSeconds(largeMeteorSpawnSpeed);
        isLargeCoroutineExecuting = false;
    }
}
