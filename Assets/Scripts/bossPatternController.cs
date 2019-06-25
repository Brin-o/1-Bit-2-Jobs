using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class bossPatternController : MonoBehaviour
{
    public float shootInterval = 3f;
    public float timeToShoot = 4f;

    [Header("Phase 1 Values")]
    public float phase1TTS = 3f;


    [Header ("Phase 2 Values")]
    public float phase2TTS = 2f;

    [Header("Phase 3 Values")]
    public float phase3TTS = 0.35f;

    private enemy boss;

    private void Start()
    {
        boss = gameObject.GetComponent<enemy>();
    }
    public enum boss_state {first, second, third, invalid};

    void Update()
    {
        timeToShoot -= Time.deltaTime;

        if (timeToShoot <0)
        {
            BulletHell();
            timeToShoot = shootInterval;

            switch (getState())
            {
                case boss_state.first:
                    shootInterval = phase1TTS;
                    timeToShoot = phase1TTS;
                    break;
                case boss_state.second:
                    shootInterval = phase2TTS;
                    timeToShoot = phase2TTS;
                    break;
                case boss_state.third:
                    shootInterval = phase3TTS;
                    timeToShoot = phase3TTS;
                    break;
            }

        }
        Debug.Log(boss.getHealth());

    }

    private boss_state getState()
    {
        int health = boss.getHealth();
        if (Enumerable.Range(1, 3).Contains(health))
            return boss_state.third;
        else if (Enumerable.Range(3, 7).Contains(health))
            return boss_state.second;
        else if (Enumerable.Range(7, 10).Contains(health))
            return boss_state.first;
        else
            return boss_state.invalid;
        
         
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
