using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("background")]
    [SerializeField] private Transform background;
    [SerializeField] private float moveSpeed = -5f;

    [Header("pipe")]
    [SerializeField] private Pipe pipePrefab;
    [SerializeField] private float lastPipePosition = 2f;
    [SerializeField] private float pipePositionHorizontalOffset = 1.2f;
    [SerializeField] private float pipePositionOffsetLow = -5f;
    [SerializeField] private float pipePositionOffsetHigh = -3f;
    [SerializeField] private float pipeVertOffsetLow = 7.8f;
    [SerializeField] private float pipeVertOffsetHigh = 9.2f;
    [SerializeField] private float timeBetweenSpawn = 1.6f;
    public float pipePositionVert;
    public float pipeUpOffset;
    private Pipe spawnedPipeUp;
    private Pipe spawnedPipeDown;

    private void Start()
    {
        StartCoroutine(SpawnPipeAfterTime());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

    }

    private IEnumerator SpawnPipeAfterTime()
    {
        while (true) // Infinite loop to keep spawning
        {
            GeneratePipes();
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    private void GeneratePipes()
    {

        pipePositionVert = Random.Range(pipePositionOffsetLow, pipePositionOffsetHigh);
        pipeUpOffset = Random.Range(pipeVertOffsetLow, pipeVertOffsetHigh);

        Vector2 spawnPosDown = new Vector2(lastPipePosition + pipePositionHorizontalOffset, pipePositionVert);
        Vector2 spawnPosUp = new Vector2(lastPipePosition + pipePositionHorizontalOffset, pipePositionVert + pipeUpOffset);

        spawnedPipeDown = Instantiate(pipePrefab, spawnPosDown, Quaternion.identity, background);
        spawnedPipeUp = Instantiate(pipePrefab, spawnPosUp, Quaternion.identity, background);
        spawnedPipeUp.transform.localScale = new Vector3(1f, 1f, 1f);
        spawnedPipeDown.transform.localScale = new Vector3(1f, 1f, 1f);
        lastPipePosition = spawnedPipeDown.transform.position.x;
    }
}
