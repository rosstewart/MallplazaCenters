using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingAcController : MonoBehaviour
{
    private float distance;
    private float distanceToAppear = 1.5f;
    private bool isActive = false;
    public GameObject panel;
    private bool isReverse = true;

    void Update()
    {
            distance = (panel.transform.position - Camera.main.transform.position).magnitude;
            if (!panel.activeSelf && distance < distanceToAppear)
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
            }
            if (isActive && Camera.main)
            {
                transform.LookAt(Camera.main.gameObject.transform);
                if (isReverse) transform.forward *= -1;
            
            }
    }
}
