using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer_scr : MonoBehaviour
{
    [HideInInspector] public float bulletSpeed = 0;
    [HideInInspector] public Vector2 dir;
    [HideInInspector] public int damage;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        Vector2 newPos = transform.position;
        newPos += dir * bulletSpeed * Time.deltaTime;
        transform.position = new Vector2(newPos.x, newPos.y);
    }

    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "Enemy")
        {
            BossLife enemyScript = collidedObject.gameObject.GetComponent<BossLife>();
            enemyScript.Damage(damage);
            Destroy(this.gameObject);
        }
    }
    
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
