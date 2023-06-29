// NOT IN USE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedAvailableText : MonoBehaviour
{
    private bool isReverse = true;

    void Update()
    {
        if (Camera.main)
        {
            transform.LookAt(Camera.main.gameObject.transform);
            if (isReverse) transform.forward *= -1;
        }
    }
}
