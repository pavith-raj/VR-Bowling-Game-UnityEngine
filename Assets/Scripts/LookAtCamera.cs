using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main != null)
        {
            Vector3 dir = Camera.main.transform.position - transform.position;
            dir.y = 0; // remove up/down effect

            transform.rotation = Quaternion.LookRotation(dir);
            transform.Rotate(0, 180f, 0);
        }
    }
}
