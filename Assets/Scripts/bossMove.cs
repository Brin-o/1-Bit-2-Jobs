using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    public float bossSpeed = 1;

    public Transform target;
    //public Vector2 moveVector;
    public Rigidbody2D rb;

    public bool canTurn = true;




    // Update is called once per frame
    void FixedUpdate()
    {
        GoRight();
        GoLeft();
        TurnReset();


        BossMoves();

    }

    private void GoRight()
    {
        if (rb.position.x > 5 & canTurn)
        {
            TurnOppositeDirection();
        }
    }
    private void GoLeft()
    {
        if (rb.position.x < -5 & canTurn)
        {
            TurnOppositeDirection();
        }
    }

    private void TurnOppositeDirection()
    {
        gameObject.transform.Rotate(0, 180, 0);
        canTurn = false;
    }

    private void TurnReset()
    {
        if (rb.position.x < 1 && rb.position.x > -1 && !canTurn)
        {
            canTurn = true;
            return;
        }
    }




    private void BossMoves()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, bossSpeed * Time.deltaTime);
    }
}


