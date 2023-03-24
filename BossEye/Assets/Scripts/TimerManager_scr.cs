using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager_scr : MonoBehaviour
{
    public Camera myCamera;
    public Color damageColor;
    public Color bonusColor;
    public GameObject myObjectMask;
    public float startTimeMask; //temps à partir duquel le mask commence à rétrécir
    public float minMask; //taille minimum du mask, lorsqu'elle est atteinte c'est game over
    private float initialMaskSize;

    public float lifeTimer;
    public Text lifeTimerText;

    public bool canTakeDamage;
    public float damageValue;
    public float bonusTimeValue;

    public BossLife bossLifeScr;

    void Start()
    {
        initialMaskSize = myObjectMask.transform.localScale.x;
        myObjectMask.transform.localScale = new Vector3(initialMaskSize, initialMaskSize);
    }

    void Update()
    {
        //déclenchement du game over
        if (lifeTimer <= 0) GameOver();

        //on fait avancer le temps, et donc on prend des dégâts
        if (bossLifeScr.isDead == false) lifeTimer -= Time.deltaTime;

        //update de la UI de timer
        lifeTimerText.text = ("Life : " + Mathf.FloorToInt(lifeTimer).ToString() + "." + (Mathf.Floor((lifeTimer - Mathf.FloorToInt(lifeTimer))*10)).ToString() + " sec"); 

        //update de la taille du masque de bord d'écran, qui permet de visualiser qu'on arrive à la fin du timer
        if (lifeTimer < startTimeMask)
        {
            float myObjectMaskNewSize = Mathf.Lerp(initialMaskSize, minMask, (startTimeMask - lifeTimer)/ startTimeMask);
            myObjectMask.transform.localScale = new Vector3(myObjectMaskNewSize, myObjectMaskNewSize);
        }
        else myObjectMask.transform.localScale = new Vector3(initialMaskSize, initialMaskSize);
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Damage()
    {
        if (canTakeDamage)
        {
            myCamera.backgroundColor = damageColor;
            lifeTimer -= damageValue;
        }
    }

    public void BonusTime()
    {
        if (canTakeDamage)
        {
            myCamera.backgroundColor = bonusColor;
            lifeTimer += bonusTimeValue;
        }
    }
}
