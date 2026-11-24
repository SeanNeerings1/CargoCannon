using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject boxPrefab;
    public Transform spawnPoint;

    public void SpawnBox()
    {
        if (boxPrefab != null && spawnPoint != null)
        {
            Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Box Prefab or Spawn Point is missing in the Inspector!");
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnBox();
        }
    }
}