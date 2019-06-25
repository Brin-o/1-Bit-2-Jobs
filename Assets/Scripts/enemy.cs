using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 10;
    

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);

        //play victory screen or something
    }

    public int getHealth()
    {
        return health;
    }
}
