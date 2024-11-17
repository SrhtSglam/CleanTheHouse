using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CrossairRaycast : MonoBehaviour
{
    public RectTransform crosshair; 
    public Camera playerCamera;   
    public float rayDistance = 100f;  
    
    private GameObject lastHitObject = null; 
    private Color lastHitObjectColor; 

    private void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(crosshair.position);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            
            if (renderer != null)
            {
                if (lastHitObject != hit.collider.gameObject && hit.collider.CompareTag("Collectible"))
                {
                    ResetLastHitObjectColor();

                    lastHitObject = hit.collider.gameObject;
                    lastHitObjectColor = renderer.material.color;
                    renderer.material.color = Color.blue;
                }
            }

            if (Input.GetMouseButtonDown(0)) // Sol tıklama
            {
                if (hit.collider.CompareTag("Collectible"))
                {
                    CollectItem(hit.collider.gameObject);
                }
            }
        }
        else
        {
            ResetLastHitObjectColor();
        }
    }

    private void ResetLastHitObjectColor()
    {
        if (lastHitObject != null)
        {
            Renderer lastRenderer = lastHitObject.GetComponent<Renderer>();
            if (lastRenderer != null)
            {
                lastRenderer.material.color = lastHitObjectColor;
            }
            lastHitObject = null;
        }
    }

    private void CollectItem(GameObject collectible)
    {
        // Destroy(collectible);
        // collectible.transform.position = new Vector3(1.767528f, -0.8742792f, 12.3567f);
        // collectible.transform.parent = null;
        collectible.transform.localPosition = collectible.GetComponent<ObjectLocation>().startPos;
        collectible.transform.rotation = Quaternion.Euler(collectible.GetComponent<ObjectLocation>().startRot);
        collectible.tag = "Untagged";
        // collectible.transform.localRotation = quaternion.EulerXYZ(0, -90, 0);
        
        Debug.Log("Eşya toplandı: " + collectible.name);
    }
}
