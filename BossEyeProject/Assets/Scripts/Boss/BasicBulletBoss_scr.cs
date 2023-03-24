using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletBoss_scr : MonoBehaviour
{
    public bool isDamageBullet;

    [HideInInspector] public float bulletTime;
    [HideInInspector] public AnimationCurve bulletForwardCurve;

    [HideInInspector] public GameObject timeManager;
    [HideInInspector] public TimerManager_scr timeManagerScr;
    private float time;

    [HideInInspector] public Vector2 dir;

    void Start()
    {
        timeManager = GameObject.Find("GameManager");
        timeManagerScr = timeManager.GetComponent<TimerManager_scr>();
    }

    void Update()
    {

        Vector2 newPos = dir * bulletForwardCurve.Evaluate(time / bulletTime) * 14; // On fait *14 car 14 est le rayon du cercle
        transform.position = new Vector2(newPos.x, newPos.y);
        time += Time.deltaTime;

        //On détruit la bullet si sa durée de vie est dépassée. Sa durée de vie est *1.2 car on veut qu'elle aille un peu plus loin que la limite du cercle
        if (time >= bulletTime * 1.2f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "Player")
        {
            if (isDamageBullet == true) timeManagerScr.Damage();
            if (isDamageBullet == false) timeManagerScr.BonusTime();
            Destroy(this.gameObject);
        }
    }
}
