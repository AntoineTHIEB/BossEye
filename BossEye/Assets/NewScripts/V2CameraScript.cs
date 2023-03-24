using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2CameraScript : MonoBehaviour
{
    public Transform myTransform;
    public Transform bossTransform;
    public Transform playerTransform;
    public float cameraDistance;
    public float myCameraLerp;
    void Start()
    {
        myTransform = transform;
    }

    void Update()
    {
        float posX;
        float posY;
        posX = Mathf.Lerp(bossTransform.position.x, playerTransform.position.x, cameraDistance);
        posY = Mathf.Lerp(bossTransform.position.y, playerTransform.position.y, cameraDistance);
        myTransform.position = new Vector3(Mathf.Lerp(myTransform.position.x,posX, myCameraLerp), Mathf.Lerp(myTransform.position.y,posY,myCameraLerp), myTransform.position.z);
    }
}
