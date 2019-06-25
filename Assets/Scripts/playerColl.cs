using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColl : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;
    public LayerMask attackBoxLayer;

    [Space]

    public bool onGround;
    public bool headBump;

    [Header("Collision")]
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, topOffset;
    private Color debugCollisionColor = Color.red;

    // Update is called once per frame
    void Update()
        {
            onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
            headBump = Physics2D.OverlapCircle((Vector2)transform.position + topOffset, collisionRadius, attackBoxLayer);
        }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var position = new Vector2[] { bottomOffset, topOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + topOffset, collisionRadius);

    }
}
