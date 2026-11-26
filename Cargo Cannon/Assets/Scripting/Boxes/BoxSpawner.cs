using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject boxPrefab1;
    [SerializeField] private GameObject boxPrefab2;
    [SerializeField] private GameObject boxPrefab3;
    [SerializeField] private GameObject boxPrefab4;
    [SerializeField] private GameObject boxPrefab5;
    [SerializeField] private GameObject boxPrefab6;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float cooldownTime = 2f;
    [SerializeField] private float currentTimer = 0f;

    private void Update()
    {
        if (currentTimer != 0f)
        {
            if (currentTimer < 0f)
            {
                currentTimer = 0f;
            }
            else
            {
                currentTimer -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnBox();
        }
    }

    public void SpawnBox()
    {
        if (currentTimer <= 0f)
        {
            if (spawnPoint != null)
            {
                Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
                currentTimer = cooldownTime;
            }
        }
    }
    private GameObject boxPrefab
    {
        get
        {
            int randomIndex = Random.Range(0, 3);   //Change the range to the amount of different boxes you want to be able to spawn
            switch (randomIndex)
            {
                case 0:
                    boxPrefab1.name = boxPrefab1.GetComponent<BoxInfo>().Name + "#" + Random.Range(1, 1000); // Assign a random name to the box
                    return boxPrefab1;
                case 1: 
                    boxPrefab2.name = boxPrefab2.GetComponent<BoxInfo>().Name + "#" + Random.Range(1, 1000); // Assign a random name to the box
                    return boxPrefab2;
                case 2:    
                    boxPrefab3.name = boxPrefab3.GetComponent<BoxInfo>().Name + "#" + Random.Range(1, 1000); // Assign a random name to the box
                    return boxPrefab3;
                default:
                    //To change something about boxInfo, write boxPrefab#.GetComponent<BoxInfo>().WhatYouWantToChange = "NewValue";
                    return null;
            }
        }
    }
}