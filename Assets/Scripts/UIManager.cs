using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject houseEnvironments;
    [SerializeField] public TextMeshProUGUI currentFurniture;
    [SerializeField] public TextMeshProUGUI time;
    public float timerCount;
    public int CollectibleItemsCount;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Collectible");
        CollectibleItemsCount = objectsWithTag.Count();
        currentFurniture.text = "Current Furniture: " + CollectibleItemsCount.ToString();
    }

    void Update()
    {
        timerCount += Time.deltaTime;
        time.text = "Time: " + Convert.ToInt32(timerCount).ToString();
    }
}
