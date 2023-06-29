using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanelController : MonoBehaviour
{
    private float distance;
    private float distanceToAppear = 1.5f;
    private bool isActive = false;
    public GameObject panel;
    private int lockedState = 0; // 0 = none, 1 = lockedOff, 2 = lockedOn

    void Start()
    {
        //Debug.Log("player position: "+Camera.main.transform.position);
    }
    
    void Update()
    {
        //Debug.Log("player position: " + Camera.main.transform.position);

        if (lockedState != 2)
        {
            distance = (panel.transform.position - Camera.main.transform.position).magnitude;
            if (!panel.activeSelf && distance < distanceToAppear && lockedState == 0)
            {
                // Turns on if player is close enough
                isActive = true;
                panel.SetActive(true);
            }
            else if (distance > distanceToAppear)
            {
                // Turns off if player is too far
                isActive = false;
                panel.SetActive(false);
                lockedState = 0; // Once player gets out of distance, panel is no longer locked off
            }
        }
    }
    
    public void OnOff()
    {
        isActive = !isActive;
        panel.SetActive(isActive);
        if (isActive)
        {
            lockedState = 2; // Panel is locked on until clicked again
        }
        else
        {
            lockedState = 1;
        }
    }
}
