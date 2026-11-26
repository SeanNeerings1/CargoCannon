using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject boxPrefab;
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
            if (boxPrefab != null && spawnPoint != null)
            {
                Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
                currentTimer = cooldownTime;
            }
        }
    }
}