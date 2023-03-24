using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyRotate : MonoBehaviour
{
    public GameObject myPlayer;
    [HideInInspector] public Player_scr myPlayerScript;
    [HideInInspector] public float teta;

    void Awake()
    {
        myPlayerScript = myPlayer.GetComponent<Player_scr>();
    }
    void Update()
    {
        teta = myPlayerScript.teta;

        Vector3 newrot = transform.rotation.eulerAngles;
        newrot.z = (teta * Mathf.Rad2Deg) + 90;
        transform.rotation = Quaternion.Euler(newrot);

    }
}
