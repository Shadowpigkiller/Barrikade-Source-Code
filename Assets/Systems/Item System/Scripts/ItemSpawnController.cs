using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnController : MonoBehaviour
{
    [SerializeField] public GameObject[] items = new GameObject[4];
    [HideInInspector] public HashSet<GameObject> spawnedItems = new HashSet<GameObject>();
    [HideInInspector] private int spawnLocations;
    [SerializeField] private float maxSpawnTimer;
    private float spawnTimerIncrement;
    [HideInInspector]public bool[] noRepeat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimerIncrement = maxSpawnTimer;
        spawnLocations = gameObject.transform.childCount;
        noRepeat = new bool[spawnLocations];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawnTimerIncrement);
        //Check if all area have an item in them
        if (!noRepeat.Contains(false))
        {
            //DO nothing
        }
        else
        {
            if (UpdateSpawnTimer() <= 0)
            {
                ChooseLocation();
                spawnTimerIncrement = maxSpawnTimer;
            }   
        }
        
    }

    float UpdateSpawnTimer()
    {
        spawnTimerIncrement -= Time.deltaTime;
        return spawnTimerIncrement;
    }

    private void ChooseLocation()
    {
        if (spawnedItems.Count < 4)
        {
            int chosenAreaNum = Random.Range(0, spawnLocations);
            while (noRepeat[chosenAreaNum])
            {
                chosenAreaNum = Random.Range(0, spawnLocations);
            }
            noRepeat[chosenAreaNum] = true;
            GameObject chosenArea = gameObject.transform.GetChild(chosenAreaNum).gameObject;
            chosenArea.GetComponent<SpawnItem>().LoadItem(ChooseItem());
        }
        
    }

    private GameObject ChooseItem()
    {
        int chosenItem = Random.Range(0, 4);
        while (spawnedItems.Contains(items[chosenItem]))
        {
            chosenItem = Random.Range(0, 4);
        }
        spawnedItems.Add(items[chosenItem]);
        return items[chosenItem];  
    }
}
