using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    // Reference to the goal prefab
    public GameObject goalPrefab;

    // Define the spawn area (e.g., within these boundaries)
    public float minX = -10f;  // Minimum x position for the spawn
    public float maxX = 10f;   // Maximum x position for the spawn
    public float minY = -5f;   // Minimum y position for the spawn
    public float maxY = 5f;    // Maximum y position for the spawn

    // Start is called before the first frame update
    void Start()
    {
        // Call SpawnGoal to spawn the goal when the scene starts
        SpawnGoal();
    }

    // Function to spawn the goal at a random position
    void SpawnGoal()
    {
        // Randomly generate a position within the defined range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Create a new goal at the random position
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Instantiate the goal prefab at the random position with no rotation
        Instantiate(goalPrefab, spawnPosition, Quaternion.identity);
    }
}