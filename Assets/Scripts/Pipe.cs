using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float leftBoundary;

    void Start()
    {
        leftBoundary = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // Set left boundary slightly outside the screen
    }

    void Update()
    {
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject); // Destroy the pipe when it moves off-screen
        }
    }
}
