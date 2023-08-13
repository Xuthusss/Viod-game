using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawning : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;
    BoxCollider bc;
    [SerializeField] private float yPos = 0.78f;
    [SerializeField] private float powerUpAmount = 4.0f;

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
    public void NewWave()
    {
        Debug.Log("Spawning powerups");
        // Destroys all current powerups
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i < powerUpAmount; i++)
        {
            SpawnPowerUp();
        }
    }
    void SpawnPowerUp()
    {
        GameObject powerUp = Instantiate(powerUpPrefab, GetRandomPosition(), Quaternion.identity);
        powerUp.transform.parent = gameObject.transform;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), yPos, Random.Range(-cubeSize.z / 2, cubeSize.z / 2));

        return cubeCenter + randomPosition;
    }
}
