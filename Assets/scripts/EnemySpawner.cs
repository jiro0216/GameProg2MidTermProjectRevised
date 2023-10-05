using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemySpawn;
    public int xPos;
    public int zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

   IEnumerator EnemyDrop() 
    {
        while (enemyCount < 1) 
        {
            xPos = Random.Range(90, 60);
            zPos = Random.Range(90, 60);
            Instantiate(EnemySpawn, new Vector3(xPos, 0.3f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            enemyCount += 1;
        }
    }
}
