using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting_scr : MonoBehaviour
{
    public GameObject player;
    public GameObject basicBullet;
    public GameObject bonusBullet;

    public int bulletNumberTarget;
    public int bulletNumberRandom;
    public int bulletNumberBonus;
    public float fireRateBoss;
    private float currentRate;

    public float bulletSpeedMax;
    public float bulletSpeedMin;
    public AnimationCurve bulletSpeedCurve;

    void Update()
    {
        if (currentRate > 1 / fireRateBoss)
        {
            Shoot();
            currentRate = 0;
        }
        else currentRate += Time.deltaTime;
    }

    void Shoot()
    {
        for (int i = 0; i < bulletNumberTarget; i++)
        {
            //On instantie la bullet et on lui donne une direction
            Vector2 positionToInstantiateTarget = this.transform.position;
            GameObject newBullet = Instantiate(basicBullet, new Vector2(positionToInstantiateTarget.x, positionToInstantiateTarget.y), Quaternion.identity);
            BasicBulletBoss_scr bulletScript = newBullet.GetComponent<BasicBulletBoss_scr>();
            bulletScript.bulletSpeedMax = bulletSpeedMax;
            bulletScript.bulletSpeedMin = bulletSpeedMin;
            bulletScript.bulletSpeedCurve = bulletSpeedCurve;
            //Bullet vers le player
            bulletScript.dir = new Vector2(player.transform.position.x + Random.Range(-1f, 1f), player.transform.position.y + Random.Range(-1f, 1f)).normalized;
        }
        for (int i = 0; i < bulletNumberRandom; i++)
        {
            //On instantie la bullet et on lui donne une direction
            Vector2 positionToInstantiateTarget = this.transform.position;
            GameObject newBullet = Instantiate(basicBullet, new Vector2(positionToInstantiateTarget.x, positionToInstantiateTarget.y), Quaternion.identity);
            BasicBulletBoss_scr bulletScript = newBullet.GetComponent<BasicBulletBoss_scr>();
            bulletScript.bulletSpeedMax = bulletSpeedMax;
            bulletScript.bulletSpeedMin = bulletSpeedMin;
            bulletScript.bulletSpeedCurve = bulletSpeedCurve;
            //Bullet direction random
            bulletScript.dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
        for (int i = 0; i < bulletNumberBonus; i++)
        {
            //On instantie la bullet et on lui donne une direction
            Vector2 positionToInstantiateRandom = this.transform.position;
            GameObject newBullet = Instantiate(bonusBullet, new Vector2(positionToInstantiateRandom.x, positionToInstantiateRandom.y), Quaternion.identity);
            BonusBulletBoss_scr bulletScript = newBullet.GetComponent<BonusBulletBoss_scr>();
            bulletScript.bulletSpeedMax = bulletSpeedMax;
            bulletScript.bulletSpeedMin = bulletSpeedMin;
            bulletScript.bulletSpeedCurve = bulletSpeedCurve;
            //Bullet direction random
            bulletScript.dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}
