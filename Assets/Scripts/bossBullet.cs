using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public float speed = 3f;
    public int bossDamage = 1;
    private Vector2 moveDirection;
    public float timeToKill = 5;

    //private bossPatternController instance;
    private enemy boss;
    //public static bossBullet instance;


    private void Start()
    {
        boss = gameObject.GetComponent<enemy>();
    }

    private void OnEnable()
    {
        Invoke("Destroy", timeToKill);
    }    

    void Update()
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
    
    public void setSpeed(float set_speed)
    {
        speed = set_speed;
    }
    
    public float getSpeed()
    {
        return speed;
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

    public void setBulletSpeed(enemy boss)
    {
        int health = boss.getHealth();
        if (Enumerable.Range(1, 3).Contains(health))
            speed = 11f;
        else if (Enumerable.Range(3, 7).Contains(health))
            speed = 6f;
        else if (Enumerable.Range(7, 10).Contains(health))
            speed = 2f;
    }
}
