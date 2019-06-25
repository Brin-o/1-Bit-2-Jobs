using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPatternController : MonoBehaviour
{
    public float shootInterval = 3f;
    private float timeToShoot = 4f;
    void Update()
    {
        timeToShoot -= Time.deltaTime;

        if (timeToShoot <0)
        {
            BulletHell();
            timeToShoot = shootInterval;
            //timeToShoot = Random.Range(1f,6f);
            //numberOfProjectiles = 12;//Random.Range(12, 24);
        }

    }

    private void BulletHell ()
    {
        Fire();
    }

    [SerializeField]
    private float bulletsAmount = 12;//Random.Range(12, 24);

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;



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
