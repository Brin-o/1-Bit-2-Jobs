using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Stats")]

    public float speed = 10;
    public float jumpForce = 5;
    [Space]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Collison checking")]
    public bool onGround;
    public LayerMask groundLayer;
    private float collisionRadius = 0.25f;
    public Vector2 bottomOffset;
    private Color debugCollisionColor = Color.red;

    //call unity components
    public Rigidbody2D rb;

    void Start()
        {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 dir = GetLocation();

        BetterJump();

        Walk(dir);

        GroundDetection();

        if (Input.GetButtonDown("Jump") && onGround)
        {
            Jump(dir);
        }

    }


    private static Vector2 GetLocation()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        return dir;
    }      // get's current location

    private void BetterJump()
        {
            if (rb.velocity.y < 0)
                {
                    rb.gravityScale = fallMultiplier;
                }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                {
                    rb.gravityScale = lowJumpMultiplier;
                }
            else
                {
                    rb.gravityScale = 1f;
                }
        }                 // ensures falling takes longer than jumping

    private void Walk(Vector2 dir)
        {
            rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
        }            // walking

    private void GroundDetection()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
    }            // check if touching ground

    private void Jump(Vector2 dir)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;
        }            //jump if on ground

    private void OnDrawGizmos()                  // draw ground detection gizmos
        {
            Gizmos.color = Color.red;

            var position = new Vector2[] { bottomOffset };

            Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        }
}
