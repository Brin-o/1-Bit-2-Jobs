using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPatternController : MonoBehaviour
{
    /*
    [Header("Projectile Settings")]
    public float projectileSpeed;
    public GameObject BossProjectile;

    [Space]
    public float timeToShoot = 3f;
    public int numberOfProjectiles;


    [Header("Private Variables")]
    private Vector2 startPoint;
    private const float raidus = 1f;


   
    */

    public float timeToShoot = 3f;
    void Update()
    {
        timeToShoot -= Time.deltaTime;

        if (timeToShoot <0)
        {
            BulletHell();
            timeToShoot = Random.Range(1f,6f);
            //numberOfProjectiles = 12;//Random.Range(12, 24);
        }

    }

    private void BulletHell ()
    {
        //startPoint = transform.position;
        //SpawnProjectile(numberOfProjectiles);
        Fire();
    }


     /*
    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 90f;
        Debug.Log(numberOfProjectiles);

        for (int i = 0; i <= _numberOfProjectiles -1; i++)
        {
            // Direction Calculations
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI )/ 180 * raidus);
            float projectileDirYPosition = startPoint.x + Mathf.Cos((angle * Mathf.PI )/ 180 * raidus);

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(BossProjectile, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;

        }
        return;
    }
    */
    [SerializeField]
    private float bulletsAmount = 12;//Random.Range(12, 24);

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    /*
    private void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }*/

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.getBullet();
            if (bul == null)
            {
                Debug.Log("NULULULUUU");
                return;
            }
            else
            {
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<bossBullet>().setMoveDirection(bulDir);
            }

            

            angle += angleStep;
        }
    }
}
