using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; 
    private Vector2 targetDirection;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void SetDirection(Vector2 direction)
    {
        targetDirection = direction.normalized;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
