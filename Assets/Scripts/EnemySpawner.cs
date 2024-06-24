using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //variáveis de configuração
    public GameObject easyEnemy;
    public float spawnCooldown;

    //variáveis de operação
    private float[] laneCooldown;
    private float cd;
    private float ySpawn;
    private float xSpawn;
    private bool evenCheck;

    void Start()
    {
        // Inicia o cooldown de tds as lanes zerados
        laneCooldown = new float[8];
        for (int i = 0; i < laneCooldown.Length; i++)
        { 
            laneCooldown[i] = 0f;
        }

        // Inicia o cooldown geral
        cd = spawnCooldown;

        // Inicia a corrotina para atualizar os cooldowns
        StartCoroutine(UpdateLanesCooldown());
    }

    void FixedUpdate()
    {
        TrySpawn();
    }

    private void SpawnEnemy(GameObject enemy)
    {
        int yIndex = 0;

        //sorteia e verifica se a lane está em cooldown, se estiver, encontra a próxima lane livre
        ySpawn = Random.Range(0, 8);
        yIndex = (int)ySpawn;
        do
        {
            yIndex++;
            if (yIndex >= 8) yIndex = 0; //se não houver lane livre, volta para a primeira e reinicia o processo

        } while (laneCooldown[yIndex] > 0);

        //se outra lane tiver sido selecionada, redefine a posição de spawn para a nova, caso contrário nada acontece;
        ySpawn = yIndex;

        //aplica o cooldown para a lane atual
        laneCooldown[yIndex] = spawnCooldown * 2;


        //se o numero da posição da lane for par, posiciona o inimigo a direita, se impar, a esquerda
        evenCheck = (ySpawn % 2 == 0);
        xSpawn = evenCheck ? 12 : -12;

        //diminui o valor da posição, para converter o número da lane em uma posição y centralizada. 
        ySpawn -= 3.5f;

        //spawna o inimigo e aciona o cooldown geral
        Instantiate(enemy, new Vector3(xSpawn, ySpawn, 0), Quaternion.identity);
        cd = spawnCooldown;
    }

    
    private void TrySpawn()
    {
        // se o cooldown estiver zerado, spawna um inimigo, se não, diminui o tempo do cooldown
        if (cd <= 0) SpawnEnemy(easyEnemy);
        else cd -= Time.deltaTime;
    }

    private IEnumerator UpdateLanesCooldown()
    {
        //diminui em paralelo o tempo de cooldown de cada lane que não estiver zerada.
        while (true)
        {
            for (int i = 0; i < laneCooldown.Length; i++)
            {
                if (laneCooldown[i] > 0) laneCooldown[i] -= Time.deltaTime;
            }
            yield return null;
        }
    }
}
