using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABTrigger : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Update is called once per frame
    //void Update()
    //    {
    //    //if collision with player start shoot
    //    if (Input.GetButtonDown("Fire1"))
    //        {
    //            Shoot();
    //        }
    //    }

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.collider.name == "Player")
        {
            Shoot();
        }
    }

    void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

}
