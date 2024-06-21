using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //variáveis de configuração
    public GameObject easyEnemy;
    public float spawnCooldown;
    //variáveis de operação
    private float cd;
    private float ySpawn;
    private float xSpawn;
    private bool evenCheck;
    

    void Start()
    {
        cd = spawnCooldown;
        SpawnEnemy(easyEnemy);
    }

    void FixedUpdate()
    {
        TrySpawn();
    }

    private void SpawnEnemy(GameObject enemy)
    {
        ySpawn = Random.Range(0, 8);

        evenCheck = (ySpawn % 2 == 0);

        if (evenCheck) xSpawn =  12;
        else           xSpawn = -12;

        ySpawn -= 3.5f;

        Instantiate(enemy, new Vector3(xSpawn, ySpawn, 0), Quaternion.identity);
        cd = spawnCooldown;
    }

    private void TrySpawn()
    {
        if (cd <= 0) SpawnEnemy(easyEnemy);
        else cd -= Time.deltaTime;
    }
}
