using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    //public float speed = 5f;
    public float speed;
    public int bossDamage = 1;
    //public Rigidbody2D rb;
    private Vector2 moveDirection;

    /*
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
    */

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    

    private void Start()
    {
        speed = 5f;
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void setMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    

    private void OnDisable()
    {
        CancelInvoke();
    }
}
