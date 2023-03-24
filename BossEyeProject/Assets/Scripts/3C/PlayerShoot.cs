using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject myBullet;
    public GameObject canon;
    public Transform canonMouth;

    public int bulletDamage;
    public float bulletSpeed;
    public float fireRate;
    private float currentRate;

    private float currentPositionY;
    private float currentScaleX;
    private float baseScaleX;

    void Start()
    {
        baseScaleX = canon.transform.localScale.x;
    }

    void Update()
    {
        if (currentRate > 1/fireRate)
        {
            Shoot();
            CanonRecul();
            currentRate = 0;
        }
        else currentRate += Time.deltaTime;

        //on revient petit à petit à la position normale après le recul du canon
        canon.transform.localPosition = new Vector2(0, currentPositionY);
        if (currentPositionY < 0) currentPositionY += 0.04f;
        //on revient petit à petit au scaling normal après le recul du canon
        canon.transform.localScale = new Vector2(currentScaleX, canon.transform.localScale.y);
        if (currentScaleX > baseScaleX) currentScaleX -= 0.1f;
    }

    
    void Shoot()
    {
        Vector3 bulletWorldPosition = canonMouth.transform.TransformPoint(Vector3.right);
        GameObject bullet = Instantiate(myBullet, canonMouth.position, canonMouth.rotation);
        BulletPlayer_scr bulletScript = bullet.GetComponent<BulletPlayer_scr>();
        bulletScript.dir = transform.up;
        bulletScript.bulletSpeed = bulletSpeed;
        bulletScript.damage = bulletDamage;
    }

    void CanonRecul()
    {
        currentPositionY = -0.9f;
        currentScaleX = 3;
    }
}
