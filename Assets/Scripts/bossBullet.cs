using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public float speed = 3f;
    public int bossDamage = 1;
    private Vector2 moveDirection;
    public float timeToKill = 5;


    private void OnEnable()
    {
        Invoke("Destroy", timeToKill);
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
