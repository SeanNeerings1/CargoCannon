using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject boxPrefab;      // Drag your box prefab here
    public Transform spawnPoint;      // Drag your empty object here

    // Call this function whenever the player accepts an order
    public void SpawnBox()
    {
        if (boxPrefab != null && spawnPoint != null)
        {
            // Spawns the box at the empty object's exact position and rotation
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
