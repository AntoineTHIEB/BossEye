using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletBoss_scr : MonoBehaviour
{
    [HideInInspector] public float bulletSpeedMax;
    [HideInInspector] public float bulletSpeedMin;
    [HideInInspector] public AnimationCurve bulletSpeedCurve;

    [HideInInspector] public GameObject timeManager;
    [HideInInspector] public TimerManager_scr timeManagerScr;
    private float bulletSpeed;
    private float time = 0;
    public float timeBeforeDestroyed;

    [HideInInspector] public Vector2 dir;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
        bulletSpeed = bulletSpeedMax;
        timeManager = GameObject.Find("GameManager");
        timeManagerScr = timeManager.GetComponent<TimerManager_scr>();
    }

    void Update()
    {
        Vector2 newPos = this.transform.position;
        newPos += dir * bulletSpeed * Time.deltaTime;
        this.transform.position = new Vector2(newPos.x, newPos.y);
        bulletSpeed = bulletSpeedCurve.Evaluate(time) * (bulletSpeedMax-bulletSpeedMin);
        time += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "Player")
        {
            timeManagerScr.Damage();
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeBeforeDestroyed);
        Destroy(this.gameObject);
    }
}
