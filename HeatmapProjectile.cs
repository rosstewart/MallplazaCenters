using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapProjectile : MonoBehaviour
{
  void Update()
  {
    transform.position = transform.position + new Vector3(0f, -1f, 0f) * Time.deltaTime;
  }
}
