using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public float speed = 5f;
    public int bossDamage = 1;
    public Rigidbody2D rb;

    void Start()
    {
        Object.Destroy(gameObject, 3.0f);
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHP player = hitInfo.GetComponent<playerHP>();
        {
            print("player takes dmg");
            // playerHP.playerTakeDamage(bossDamage);
        }
    }
}
