using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    [SerializeField] GameObject camera;

    private void Update()
    {
        if (!camera.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(true);
        }

        else if (camera.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(false);
        }
    }
}
