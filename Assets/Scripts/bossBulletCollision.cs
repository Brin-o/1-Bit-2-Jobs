using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBulletCollision : MonoBehaviour
{
    public int bossBulletDMG = 1;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
            plyaerHit(hitInfo);
        else if (hitInfo.gameObject.tag == "Enviorment")             //ne dela???
        {
            print("Hit the ground or something");
            Destroy(gameObject);
        }
    }

    private void plyaerHit(Collider2D hitInfo)
    {
        playerHP playerhp = hitInfo.GetComponent<playerHP>();
        playerhp.playerTakeDamage(bossBulletDMG);
        Destroy(gameObject);
        //if it hits a player do DMG
    }
}
