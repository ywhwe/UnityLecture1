using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager instance;
    
    [Header("-Food")]
    public GameObject foodPrefab;
    public float foodRate;
    private float foodTimer;
    private WaitForSeconds foodTime;
    public int initialFoodAmount;
    public TextMeshProUGUI foodAmountText;
    
    [Header("-Dove")]
    public GameObject dovePrefab;
    public int initialDoveAmount;
    public TextMeshProUGUI doveAmountText;
    public int doveCount;
    
    [Header("-Hawk")]
    public GameObject hawkPrefab;
    public int initialHawkAmount;
    public TextMeshProUGUI hawkAmountText;
    public int hawkCount;
    
    [Header("-ETC")]
    public GameObject controlPanel;
    
    [HideInInspector]
    public float mapSize = 23f;
    public Slider timeSlider;
    
    public TextMeshProUGUI timeScaleText;
    
    private void Awake()
    {
        instance = this;
        foodTime = new WaitForSeconds(foodRate);

        //StartSimulation();
    }

    private void Update()
    {
        Time.timeScale = timeSlider.value;
        SetTimeScaleText(timeSlider.value);
        
       
    }

    public void StartSimulation()
    {
        for (int i = 0; i < initialFoodAmount; i++)
        {
            SpawnFood();
        }
        for (int i = 0; i < initialDoveAmount; i++)
        {
            SpawnPrefabRandomPos(dovePrefab);
            doveCount++;
        }
        for (int i = 0; i < initialHawkAmount; i++)
        {
            SpawnPrefabRandomPos(hawkPrefab);
            hawkCount++;
        }
        
        controlPanel.SetActive(false);
        
        StartCoroutine(SpawningFood());
        
    }

    public void SpawnPrefabRandomPos(GameObject prefab)
    {
        var posX = Random.Range(-mapSize, mapSize);
        var posY = Random.Range(-mapSize, mapSize);

        var prefabPos = new Vector3(posX, 0f, posY);
        Instantiate(prefab, prefabPos, Quaternion.identity);
    }
    
    public void SpawnFood()
    {
        SpawnPrefabRandomPos(foodPrefab);
    }

    private IEnumerator SpawningFood()
    {
        while (true)
        {
            yield return foodTime;
        }
    }

    public void SetTimeScaleText(float value)
    {
        timeScaleText.text = "x " + value.ToString("N2");
    }
    
    public void SetFoodAmount(bool inc)
    {
        initialFoodAmount += inc ? 1 : -1;
        if (initialFoodAmount <= 0)
            initialFoodAmount = 0;

        foodAmountText.text = initialFoodAmount.ToString();
    }
    
    public void SetDoveAmount(bool inc)
    {
        initialDoveAmount += inc ? 1 : -1;
        if (initialDoveAmount <= 0)
            initialDoveAmount = 0;

        doveAmountText.text = initialDoveAmount.ToString();
    }
    
    public void SetHawkAmount(bool inc)
    {
        initialHawkAmount += inc ? 1 : -1;
        if (initialHawkAmount <= 0)
            initialHawkAmount = 0;

        hawkAmountText.text = initialHawkAmount.ToString();
    }
}
