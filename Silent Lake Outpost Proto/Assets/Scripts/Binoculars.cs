using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binoculars : MonoBehaviour
{
     [SerializeField] GameObject binoculars;
     [SerializeField] int zoomedIn = 25;
     [SerializeField] int zoomedOut = 60;
     [SerializeField] float smoothView = 4.5f;

     private bool isZoomed;

     [SerializeField] Texture2D binocImage;
    

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    
    private void Update()
    {
         CheckZoom();    
    }

    void CheckZoom()
    {
        if(binoculars.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomedIn, Time.deltaTime * smoothView);
            isZoomed = true;
        }

       /* else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomedOut, Time.deltaTime * smoothView);
            isZoomed = false;
        }
        */
    }

    void OnGUI()
    {
        if(isZoomed)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), binocImage);
        } 
    }
}
