using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] Light flash;
    [SerializeField] GameObject flashLight;
    [SerializeField] Light flashLightSpotLight;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip photoClip;

    private bool isLightActive = false;
    private bool toggleFlashLightLight = false;

    private void Start()
    {
        flash.enabled = false;
        flashLightSpotLight.enabled = false;
    }

    private void Update()
    {
        PlayAudio();
        FlashLightOn();

        if (!camera.activeSelf && !flashLight.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(true);
        }

        else if (!camera.activeSelf && flashLight.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(true);
            flashLight.SetActive(false);
        }

        else if (camera.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(false);
        }

        if(!flashLight.activeSelf && !camera.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(true);
        }

        else if (!flashLight.activeSelf && camera.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            camera.SetActive(false);
            flashLight.SetActive(true);
        }

        else if(flashLight.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(false);
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
        isLightActive = false;
    }

    void FlashLightOn()
    {
        if (flashLight.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            flashLightSpotLight.enabled = true;
            toggleFlashLightLight = !toggleFlashLightLight;
        }

        else if(toggleFlashLightLight)
        {
            flashLightSpotLight.enabled = false;
        }
    }
}
