using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=4;
    public float distance=0.5f;
    public int damage;
    public LayerMask layerMask;
    private Vector3 firstPos;

    void Start()
    {
        firstPos = transform.position;
    }

    void Update()
    { 
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, layerMask);
        if (hitInfo.collider != null)
        { Debug.Log("abraKadabra");
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
            }
            Destroy(gameObject);
            
        }

        if (Vector3.Distance(firstPos, transform.position) > 5) 
        {
            Destroy(gameObject);
        }


        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

}
