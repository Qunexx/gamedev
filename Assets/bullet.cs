using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=10;
    public float lifespeed;
    public float distance=0.5f;
    public int damage=10;
    public LayerMask whatIsSolid = 0;

    private void Update()
    { Debug.DrawRay(transform.position,transform.up,Color.red);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        { Debug.Log("abraKadabra");
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

}
