using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 10);
    }
}
