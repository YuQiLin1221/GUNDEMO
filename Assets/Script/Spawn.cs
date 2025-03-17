using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int yPos;
    public int EnemyCount;
    public int EnemyMax = 10;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < EnemyMax)
        {
            xPos = Random.Range(-16, -42);
            zPos = Random.Range(7, 20);
            yPos = Random.Range(6, 8);
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            EnemyCount += 1;
        }
    }
}
