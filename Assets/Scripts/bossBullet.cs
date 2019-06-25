using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        Object.Destroy(gameObject, 3.0f);
    }
}
