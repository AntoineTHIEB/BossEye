using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyVariation : MonoBehaviour
{
    public bossShooting_scr bossShootingScript;

    private float time;
    public float timeMax;

    public float maxFireRate;
    public AnimationCurve fireRateCurve;
    public int maxBulletTarget;
    public AnimationCurve bulletNumberTargetCurve;
    public int maxBulletRandom;
    public AnimationCurve bulletNumberRandomCurve;

    void Update()
    {
        bossShootingScript.fireRateBoss = fireRateCurve.Evaluate(time/timeMax) * maxFireRate;
        bossShootingScript.bulletNumberTarget = Mathf.RoundToInt(bulletNumberTargetCurve.Evaluate(time/timeMax) * maxBulletTarget);
        bossShootingScript.bulletNumberRandom = Mathf.RoundToInt(bulletNumberTargetCurve.Evaluate(time/timeMax) * maxBulletRandom);
        time += Time.deltaTime;
    }
}
