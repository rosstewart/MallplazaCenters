using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapQuad : MonoBehaviour
{
  Material mMaterial;
  MeshRenderer mMeshRenderer;

  float[] mPoints;
  int mHitCount;

  float mDelay;

  public float[] xPoints;
    public float[] zPoints;

    void Start()
  {
    mDelay = 3;

    mMeshRenderer = GetComponent<MeshRenderer>();
    mMaterial = mMeshRenderer.material;

    mPoints = new float[32 * 3]; //32 point 

    if (xPoints.Length <= zPoints.Length) //If xPoints and zPoints are unbalanced, it won't give error
        {
            for (int i = 0; i < xPoints.Length; i++)
            {
                CreateHeat(i);
            }
        }
        else
        {
            for (int i = 0; i < zPoints.Length; i++)
            {
                CreateHeat(i);
            }
        }
    
  }

    void CreateHeat(int i)
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Projectile"));
        go.transform.position = new Vector3(transform.position.x + xPoints[i], transform.position.y + .01f, transform.position.y + zPoints[i]);
    }

  void Update()
  {

  }

  private void OnCollisionEnter(Collision collision)
  {
    foreach(ContactPoint cp in collision.contacts)
    {
      Debug.Log("Contact with object " + cp.otherCollider.gameObject.name);

      Vector3 StartOfRay = cp.point - cp.normal;
      Vector3 RayDir = cp.normal;

      Ray ray = new Ray(StartOfRay, RayDir);
      RaycastHit hit;

      bool hitit = Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("HeatMapLayer"));
            Debug.Log("hitit: " + hitit);
      if (hitit)
      {
        Debug.Log("Hit Object " + hit.collider.gameObject.name);
        Debug.Log("Hit Texture coordinates = " + hit.textureCoord.x + "," + hit.textureCoord.y);
        addHitPoint(hit.textureCoord.x*4-2, hit.textureCoord.y*4-2);
      }
      Destroy(cp.otherCollider.gameObject);
    }
  }

  public void addHitPoint(float xp,float yp)
  {
    mPoints[mHitCount * 3] = xp;
    mPoints[mHitCount * 3 + 1] = yp;
    mPoints[mHitCount * 3 + 2] = Random.Range(1f, 3f);

    mHitCount++;
    mHitCount %= 32;

    mMaterial.SetFloatArray("_Hits", mPoints);
    mMaterial.SetInt("_HitCount", mHitCount);

  }

}
