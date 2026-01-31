using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCanvas : MonoBehaviour
{
    private void OnEnable()
    {
        Canvas myCanvas = GetComponent<Canvas>();

        GameObject vrifCam = GameObject.Find("CameraCaster");


        if (myCanvas != null && vrifCam != null)
        {
            myCanvas.worldCamera = vrifCam.GetComponent<Camera>();
        }
    }
    //void LateUpdate()
    //{
    //    if (Camera.main != null)
    //    {
    //        transform.LookAt(Camera.main.transform);
    //        transform.Rotate(0, 180f, 0);
    //    }
    //}
}
