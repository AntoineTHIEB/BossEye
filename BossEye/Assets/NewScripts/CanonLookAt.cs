using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonLookAt : MonoBehaviour
{
    public Camera myCamera;
    void Update()
    {
        Vector2 dir = Input.mousePosition - myCamera.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        Vector3 newRot = transform.rotation.eulerAngles;
        newRot.z -= 90;
        transform.rotation = Quaternion.Euler(newRot);
    }
}
