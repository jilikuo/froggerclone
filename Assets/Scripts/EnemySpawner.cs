using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject easyEnemy;

    void Start()
    {
        SpawnEnemy(easyEnemy);
    }

    void FixedUpdate()
    {
        
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(6, 0, 0), Quaternion.identity);
    }

}
