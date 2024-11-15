using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeele : MonoBehaviour
{
    GameObject playerObj;
    float speed = 5f;
    void Start()
    {
        playerObj = playerObj == null ? GameObject.FindGameObjectWithTag("Player").gameObject : playerObj;
    }

    
    void Update()
    {
        if(playerObj != null)
        {
            // Vector3 direction = (playerObj.transform.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, speed * Time.deltaTime);
        }
    }
}
