using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip photoClip;
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
        }
    }

    /*private IEnumerator TurnFlashOff() 
    {
        
    }
    */
}
