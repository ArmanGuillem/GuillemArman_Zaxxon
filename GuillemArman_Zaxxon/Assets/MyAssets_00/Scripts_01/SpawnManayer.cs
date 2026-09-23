using System.Collections;
using UnityEngine;

public class SpawnManayer : MonoBehaviour
{
    float spawnRate = 2f;
    [SerializeField] GameObject[] enemyPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
        {
        while (true)
        {
            for(int n= 0; n < 4; n++)
            {
                Release();
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Release()
    {
        float spawnPosX = Random.Range(-9.5f, 9.5f);
        float spawnPosY = Random.Range(0.5f, 5.5f);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 90f);
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPos, Quaternion.identity);
        
    }
}
