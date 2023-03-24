using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement_scr : MonoBehaviour
{
    public float amplitude;
    public float smoothShakeAmplitude;

    public GameObject player;

    void Update()
    {
        Player_scr playerScript = player.GetComponent<Player_scr>();

        Vector3 newpos = transform.position;
        newpos = player.transform.position.normalized * amplitude;
        //newpos.x += Mathf.Cos(Time.time * 2) * smoothShakeAmplitude;
        //newpos.y += Mathf.Sin(Time.time * 2) * smoothShakeAmplitude;
        newpos.z = -10;
        transform.position = newpos;
        /*
        newpos.x = player.transform.position.x * amplitude / 10;
        newpos.y = player.transform.position.y * amplitude / 10;
        transform.position = newpos;
        */
    }
}
