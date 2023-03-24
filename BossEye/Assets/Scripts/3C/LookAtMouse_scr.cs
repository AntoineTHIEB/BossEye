using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse_scr : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector3 newRot = transform.rotation.eulerAngles;
        newRot.z -= 90;
        transform.rotation = Quaternion.Euler(newRot);
    }
}
