using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] GameObject bed;
    [SerializeField] GameObject sleepUI;
    [SerializeField] LayerMask mask;
    Vector3 mousePos;
    Camera cam;
    [SerializeField] GameObject nightSky;
    [SerializeField] GameObject daySky;
    [SerializeField] GameObject darkening;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        GoSleep(mousePos, mask, cam, sleepUI, bed);
    }

    static async Task Sleeping(GameObject Darkening, GameObject NightSky, GameObject DaySky)
    {
        Darkening.SetActive(true);

        await Task.Delay(2000);

        if (NightSky != null)
        {
            NightSky.SetActive(!NightSky.activeSelf);
            DaySky.SetActive(!DaySky.activeSelf);
        }

        await Task.Delay(4000);

        Darkening.SetActive(false);
    }

    private void GoSleep(Vector3 pos, LayerMask mask, Camera cam, GameObject UI, GameObject item)
    {
        pos = Input.mousePosition;
        pos.z = 100f;
        pos = cam.ScreenToWorldPoint(pos);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 4, mask))
        {
            if (hit.collider.gameObject == item)
            {
                UI.SetActive(true);
            }
        }

        else
        {
            UI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, 4, mask))
            {
                if (hit.collider.gameObject == item)
                {
                    // Koodi t�h�n, ett� mit� tapahtuu kun pelaaja painaa E:t�. Mahdollisesti uusi scene, miss� voisi lukea "Day 2, Day3, Day4 yms...

                    Sleeping(darkening, nightSky, daySky);
                }
            }
        }
    }
}
