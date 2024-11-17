using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Assign the asteroid prefab in the Inspector
    public float spawnRate = 2f; // Time interval between spawns
    public int asteroidsPerSpawn = 3; // Number of asteroids to spawn at once
    public float spawnRadius = 5f; // Radius for spawning asteroids around a central point
    private float timer = 0;

    void Update()
    {
        // Increase the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // If the timer has exceeded the spawn rate, spawn new asteroids
        if (timer >= spawnRate)
        {
            SpawnAsteroids();
            timer = 0; // Reset the timer
        }
    }

    void SpawnAsteroids()
    {
        // Get the width of the screen in world units
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // Get the top of the screen in world units
        float topOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // Spawn multiple asteroids in random positions
        for (int i = 0; i < asteroidsPerSpawn; i++)
        {
            // Randomly choose an x position between the edges of the screen
            float randomX = Random.Range(-screenWidth, screenWidth);

            // Optionally, vary the spawn height slightly if you want a spread of asteroids on the screen
            float randomY = Random.Range(topOfScreen, topOfScreen + spawnRadius);

            // Set the spawn position above the screen
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            // Instantiate the asteroid at the spawn position with no rotation
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            // Optionally: You can add asteroid movement or speed here
            // If your asteroid prefab has a Rigidbody2D, you can add a velocity in the downward direction

            Rigidbody2D asteroidRb = asteroid.GetComponent<Rigidbody2D>();

            if (asteroidRb != null)
            {
                // Set a random downward speed to make each asteroid fall at a different rate
                asteroidRb.velocity = new Vector2(0, Random.Range(-5f, -10f));
            }
        }
    }
}