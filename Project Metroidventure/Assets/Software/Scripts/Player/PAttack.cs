using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    void Shoot()
    {        
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (targetPosition - (Vector2)firePoint.position).normalized;

        projectile.GetComponent<Projectile>().SetDirection(direction);
    }
}
