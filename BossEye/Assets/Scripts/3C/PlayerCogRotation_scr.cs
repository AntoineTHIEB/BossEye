using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCogRotation_scr : MonoBehaviour
{
    public GameObject myPlayer;
    [HideInInspector] public Player_scr myPlayerScript;

    public bool isLeftCog;
    public float cogRotationSpeed;

    [HideInInspector] public Transform myTransform;
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (isLeftCog) myTransform.Rotate(0, 0, -cogRotationSpeed * Mathf.Sign(Input.GetAxis("Horizontal")));
            else myTransform.Rotate(0, 0, -cogRotationSpeed * Mathf.Sign(Input.GetAxis("Horizontal")));
        }
    }
}
