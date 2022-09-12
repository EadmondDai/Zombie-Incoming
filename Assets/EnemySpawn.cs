using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] int enemyLeft;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyHolder;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartToSpawnEnemy());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartToSpawnEnemy()
    {
        yield return new WaitForSeconds(5);

        while(enemyLeft > 0)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            newEnemy.transform.parent = enemyHolder;
            enemyLeft--;

            yield return new WaitForSeconds(.2f);
        }
    }
}
