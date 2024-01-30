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
    [SerializeField] GameObject binocs;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource flashLightSource;

    [SerializeField] AudioClip flashLightClip;
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
        CameraShow();
        FLashLightShow();
        BinocularsShow();
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
            flashLightSource.PlayOneShot(flashLightClip);
        }

        else if(toggleFlashLightLight)
        {
            flashLightSpotLight.enabled = false;
        }
    }

    void CameraShow()
    {
        if (!camera.activeSelf && !flashLight.activeSelf && !binocs.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(true);
        }

        else if (!camera.activeSelf && flashLight.activeSelf || binocs.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(true);
            flashLight.SetActive(false);
            binocs.SetActive(false);
        }

        else if (camera.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            camera.SetActive(false);
        }
    }

    void FLashLightShow()
    {
        if (!flashLight.activeSelf && !camera.activeSelf && !binocs.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(true);
        }

        else if (!flashLight.activeSelf && camera.activeSelf || binocs.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            camera.SetActive(false);
            flashLight.SetActive(true);
            binocs.SetActive(false);
        }

        else if (flashLight.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(false);
        }
    }

    void BinocularsShow()
    {
        if(!binocs.activeSelf && !camera.activeSelf && !flashLight.activeSelf && Input.GetKeyDown(KeyCode.B))
        {
            binocs.SetActive(true);
        }

        else if (!binocs.activeSelf && camera.activeSelf || flashLight.activeSelf && Input.GetKeyDown(KeyCode.B))
        {
            camera.SetActive(false);
            flashLight.SetActive(false);
            binocs.SetActive(true);
        }

        else if(binocs.activeSelf && Input.GetKeyDown(KeyCode.B))
        {
            binocs.SetActive(false);
        }
    }
}
