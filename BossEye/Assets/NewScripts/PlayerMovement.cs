using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform myTransform;
    public float speed;
    void Start()
    {
        myTransform = transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        myTransform.Rotate(new Vector3(0, 0, speed * Input.GetAxis("Horizontal") * -50 * Time.deltaTime));
    }
}
