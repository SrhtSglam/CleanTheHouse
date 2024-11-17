using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] GameObject _Scripts;

    private void CollectItem(GameObject collectible)
    {
        // Destroy(collectible);
        // collectible.transform.position = new Vector3(1.767528f, -0.8742792f, 12.3567f);
        // collectible.transform.parent = null;
        collectible.transform.localPosition = collectible.GetComponent<ObjectLocation>().startPos;
        collectible.transform.rotation = Quaternion.Euler(collectible.GetComponent<ObjectLocation>().startRot);
        collectible.tag = "Untagged";
        // collectible.transform.localRotation = quaternion.EulerXYZ(0, -90, 0);
        var count = _Scripts.GetComponent<UIManager>().CollectibleItemsCount--;
        _Scripts.GetComponent<UIManager>().currentFurniture.text = "Current Furniture: " + count.ToString();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Collectible");
        for(int i = 0; i < objectsWithTag.Count(); i++){
            Debug.Log(objectsWithTag[i]);
        }
        if(count <= 1){
            try{
                int timerCount = (int)_Scripts.GetComponent<UIManager>().timerCount;
                int bestCount = PlayerPrefs.GetInt("TimeValue");
                if(timerCount > bestCount){
                    PlayerPrefs.SetInt("TimeValue", timerCount);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(0);
                }
                else{
                    SceneManager.LoadScene(0);
                }
            }
            catch(Exception ex){
                Debug.Log(ex.ToString());
            } 
        }
    }
}
