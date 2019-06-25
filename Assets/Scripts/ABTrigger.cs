using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABTrigger : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    [Space]
    private bool touchedBottom;
    public LayerMask playerLayer;

    [Header("Collision")]
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset;
    private Color debugCollisionColor = Color.red;

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.collider.name == "Player" && touchedBottom)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void FixedUpdate()
    {
        touchedBottom = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, playerLayer);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);

    }
}
