using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public int playerHealth = 5;


    public void playerTakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);

        //you lose screen.
    }
}
