using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float cooldownTime = 1.5f;

    [SerializeField] private float currentTimer = 0f;

    private void Update()
    {
        // Count down to 0 every second
        if (currentTimer == 0f)
        {
            currentTimer -= Time.deltaTime;
        }

        // Changed from Tab to Space so Unity Editor doesn't steal focus
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnBox();
        }
    }

    public void SpawnBox()
    {
        // Only spawn if the timer has reached 0
        if (currentTimer <= 0f)
        {
            if (boxPrefab != null && spawnPoint != null)
            {
                Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
                currentTimer = cooldownTime; // Reset timer back to 1.5
            }
            else
            {
                Debug.LogWarning("Box Prefab or Spawn Point is missing on " + gameObject.name);
            }
        }
    }
}