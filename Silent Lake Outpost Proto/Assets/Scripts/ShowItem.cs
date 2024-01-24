using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] Light flash;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip photoClip;

    private bool isLightActive = false;

    private void Start()
    {
        flash.enabled = false;
    }

    private void Update()
    {
        PlayAudio();
        if (!camera.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(true);
        }

        else if (camera.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(false);
        }
    }

    private void PlayAudio()
    {
        if (camera.activeSelf && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            audioSource.PlayOneShot(photoClip);
            ToggleFlash();
        }
    }

    private void ToggleFlash()
    {
        isLightActive = !isLightActive;
        flash.enabled = isLightActive;

        if(isLightActive)
        {
            Invoke("DeactivateFlash", 0.25f);
        }
    }

    private void DeactivateFlash()
    {
        flash.enabled = false;
        isLightActive= false;
    }

}
