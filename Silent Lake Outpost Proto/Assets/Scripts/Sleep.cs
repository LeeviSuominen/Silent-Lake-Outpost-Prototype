using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] GameObject bed;
    [SerializeField] GameObject sleepUI;
    [SerializeField] LayerMask mask;
    Vector3 mousePos;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        GoSleep(mousePos, mask, cam, sleepUI, bed);
    }

    private void GoSleep (Vector3 pos, LayerMask mask, Camera cam, GameObject UI, GameObject item)
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
            if (Physics.Raycast(ray, out hit, 2, mask))
            {
                if (hit.collider.gameObject == item)
                {
                    // Koodi tähän, että mitä tapahtuu kun pelaaja painaa E:tä. Mahdollisesti uusi scene, missä voisi lukea "Day 2, Day3, Day4 yms...
                }
            }
        }
    }
}
