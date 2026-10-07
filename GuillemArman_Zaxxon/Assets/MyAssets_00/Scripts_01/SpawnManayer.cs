using System.Collections;
using UnityEngine;

public class SpawnManayer : MonoBehaviour
{
    float spawnRate = 0.5f;
    [SerializeField] GameObject[] enemyPrefabs;

    // Numero de enemigos por oleada
    [SerializeField] int minEnemies = 1;
    [SerializeField] int maxEnemies = 5;

    //Limites de spawn
    [SerializeField] float xMin = -20f, xMax = 20f, yMin = -15, yMax = 15;

  

    // Numero de naves
    [SerializeField] int waves = 5;

    // Enemigos intermedios
    [SerializeField] float firstEnemieDistance;
    [SerializeField] float distanceBetweemEnemies;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstEnemieDistance = 300f;
        distanceBetweemEnemies = 20f;
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            // Llama a la funcion para generar la oleada actual
            MidEnemies();

            // Espera el tiempo de spawnRate (0.5s) antes de la siguiente oleada
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MidEnemies()
    {
        // Genera entre minEnemies (1) y maxEnemies (5)
        int enemigosEnEstaOleada = Random.Range(minEnemies, maxEnemies + 1);

        for (int i = 0; i < enemigosEnEstaOleada; i++)
        {
            Release(0f);
        }
    }

    void Release(float distanceRelease)
    {
        // Se calcula una posicion X e Y aleatoria en cada llamada para que salgan esparcidos
        float spawnPosX = Random.Range(xMin, xMax);
        float spawnPosY = Random.Range(yMin, yMax);

        Vector3 despl = new Vector3(spawnPosX, spawnPosY, distanceRelease);
        Vector3 instPos = transform.position + despl;

        int k = Random.Range(0, enemyPrefabs.Length);

        // Guardamos la referencia de la instancia creada
        GameObject newEnemie = Instantiate(enemyPrefabs[k], instPos, Quaternion.identity);
        



    }
}










