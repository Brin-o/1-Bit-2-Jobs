using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPatternController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float projectileSpeed;
    public GameObject BossProjectile;

    [Space]
    public float timeToShoot = 3f;
    public int numberOfProjectiles;


    [Header("Private Variables")]
    private Vector2 startPoint;
    private const float raidus = 1f;


   

    void Update()
    {
        timeToShoot -= Time.deltaTime;

        if (timeToShoot <0)
        {
            BulletHell();
            timeToShoot = 2f; //Random.Range(1f,6f);
            numberOfProjectiles = 6; //Random.Range(12, 24);
        }

    }

    private void BulletHell ()
    {
        startPoint = transform.position;
        SpawnProjectile(numberOfProjectiles);
    }

    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles -1; i++)
        {
            // Direction Calculations
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI / 180) * raidus);
            float projectileDirYPosition = startPoint.x + Mathf.Cos((angle * Mathf.PI / 180) * raidus);

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(BossProjectile, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;


        }
        return;
    }
}
