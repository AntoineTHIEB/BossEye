using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public int bossLife;
    [HideInInspector] public bossShooting_scr bossShootingScript;
    [HideInInspector] public Animator bossAnimator;
    [HideInInspector] public bool isDead;

    public BossWhiteFlash bossWhiteFlashScript;

    void Awake()
    {
        bossShootingScript = GetComponent<bossShooting_scr>();
        bossAnimator = GetComponent<Animator>();
    }

    public void Damage(int damageValue)
    {
        bossLife -= damageValue;

        bossWhiteFlashScript.SetAlpha();
        if (bossLife <= 0)
        {
            isDead = true;
            bossAnimator.SetBool("IsDead", true);
            bossShootingScript.fireRateBoss = 0;
        }
    }
}
