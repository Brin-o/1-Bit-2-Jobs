using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public int maxPlayerHealth = 5;
    public int playerHealth;
    public float HPprct;               


    public void playerTakeDamage(int damage)
    {
        playerHealth -= damage;
        float HPprct = (float)maxPlayerHealth / (float)playerHealth;

        if (playerHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
        print("You have lost");
        //you lose screen.
    }
}