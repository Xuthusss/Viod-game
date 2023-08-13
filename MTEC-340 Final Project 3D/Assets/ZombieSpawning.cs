using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] PowerUpSpawning powerUpScript;

    BoxCollider bc;
    [SerializeField] private float yPos = 0.78f;

    private float zombiesSpawned = 3;
    private float totalZombiesSpawned = 0;
    private bool canSpawnWave = true;

    Vector3 cubeSize;
    Vector3 cubeCenter;

    private void Awake()
    {
        bc = GetComponent<BoxCollider>();

        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;
        cubeSize.z = cubeTrans.localScale.z * bc.size.z;
    }
    private void Start()
    {
        StartCoroutine(SpawnZombieWave());
    }

    private IEnumerator SpawnZombieWave()
    {
        canSpawnWave = false;
        zombiesSpawned += 2;
        totalZombiesSpawned += zombiesSpawned;
        yield return new WaitForSeconds(5.0f);

        Debug.Log($"Spawning {zombiesSpawned} zombies!");

        for(int i = 0; i < zombiesSpawned; i++)
        {
            SpawnZombie();
        }
        GameBehavior.Instance.NewWave();
        powerUpScript.NewWave();
        canSpawnWave = true;
    }
    private void Update()
    {
        if(GameBehavior.Instance.zombiesKilled == totalZombiesSpawned && canSpawnWave)
        {
            StartCoroutine(SpawnZombieWave());
        }
    }

    private void SpawnZombie()
    {
        GameObject zombie = Instantiate(zombiePrefab, GetRandomPosition(), Quaternion.identity);
        zombie.transform.parent = gameObject.transform;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), yPos, Random.Range(-cubeSize.z, cubeSize.z));

        return cubeCenter + randomPosition;
    }
}
