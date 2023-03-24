using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    private Camera myCamera;
    public Color initialColor;
    void Start()
    {
        myCamera = GetComponent<Camera>();
        initialColor = myCamera.backgroundColor;
    }

    
    void Update()
    {
        Color currentColor = myCamera.backgroundColor;
        if (currentColor != initialColor)
        {
            myCamera.backgroundColor = Color.Lerp(currentColor, initialColor, 0.02f);
        }
    }
}
