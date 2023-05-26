using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)       //ф-я коллизия
    {
        if (coll.gameObject.tag == collisionTag)
        {
            HealthBar healthBar = coll.gameObject.GetComponent<HealthBar>();
            PlayerController playerController = coll.gameObject.GetComponent<PlayerController>();
            //fill = health - Damage


            healthBar.fill = playerController.health / 100;
        }

    }

}