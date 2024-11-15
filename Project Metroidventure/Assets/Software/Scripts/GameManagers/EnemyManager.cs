using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    float sayac;
    void Start()
    {
        
    }

    void Update()
    {
        sayac -= Time.deltaTime;

        if(sayac < 0)
        {
            Vector3 SpawnTransform = new Vector3(Random.Range(12, -12), Random.Range(7, -7), 0);
            Instantiate(enemyPrefab, SpawnTransform, Quaternion.identity, null);
            sayac = 2;
        }
    }
}
