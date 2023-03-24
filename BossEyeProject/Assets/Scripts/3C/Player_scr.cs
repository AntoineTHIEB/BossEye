using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_scr : MonoBehaviour
{
    public float rayon;
    public float speed;
    [HideInInspector] public float teta;
    [HideInInspector] private float directionModification = 1;
    [HideInInspector] private bool directionInputWasPressedLastFrame;

    public float xRatio;
    public float yRatio;

    public float dashSpeedMultiplicator;
    public float dashDuration;
    [HideInInspector] public float currentDashDuration;
    [HideInInspector] public bool inDash;
    public float dashCooldown;
    [HideInInspector] public float currentDashCooldown;
    [HideInInspector] public bool inDashCooldown;

    [HideInInspector] public Transform playerTransform;

    void Awake()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        teta = Mathf.PI * 1.5f;
    }

    void Update()
    {
        //DASH - On check si on est en dash ou non. Si oui, on augmente la vitesse et on lance le temps de durée du dash
        if (inDashCooldown == true)
        {
            if (currentDashCooldown >= dashCooldown)
            {
                inDashCooldown = false;
                currentDashCooldown = 0;
            }
            else currentDashCooldown += Time.deltaTime;
        }
        else if (inDash == true)
        {
            if (currentDashDuration >= dashDuration)
            {
                inDash = false;
                currentDashDuration = 0;
                inDashCooldown = true;
            }
            else currentDashDuration += Time.deltaTime;
        }
        if (Input.GetAxis("Dash") == 1 && inDash == false && inDashCooldown == false) inDash = true;

        //On update la direction dans laquelle on va en fonction de si on est dans la partie haute ou basse du cercle AU MOMENT où on ajoute un nouvel input
        if (directionInputWasPressedLastFrame == false && Input.GetAxis("Horizontal") != 0) updateDirectionModification();
        if (Input.GetAxis("Horizontal") != 0) directionInputWasPressedLastFrame = true;
        else directionInputWasPressedLastFrame = false;

        //POSITION - Calcul de la nouvelle position sur le cercle
        teta = teta % (2 * Mathf.PI);
        if (inDash == true) teta += Input.GetAxis("Horizontal") * speed * dashSpeedMultiplicator * Time.deltaTime;// * directionModification;
        teta += Input.GetAxis("Horizontal") * speed * Time.deltaTime;// * directionModification;

        //POSITION - Application de la nouvelle position sur le cercle
        float myPosX = Mathf.Cos(teta) * rayon * xRatio;
        float myPosY = Mathf.Sin(teta) * rayon * yRatio;
        playerTransform.position = new Vector3(myPosX,myPosY,0);
    }   

    //Fonction qui permet d'update la direction dans laquelle on va en fonction de si on est dans la partie haute ou basse du cercle
    void updateDirectionModification()
    {
        directionModification = -Mathf.Sign(transform.position.y);
    }
}
