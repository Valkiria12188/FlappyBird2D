using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject pipeNormal;
    [SerializeField] private GameObject pipeMoving;
    [SerializeField] private GameObject doublePipe;

    [SerializeField] private float delayTime;
    [SerializeField] private float spawnTime = 2f;
    private GameObject gameContainer;
    [SerializeField] private GameManager gameManager;
    int scoreing = 0;

    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        gameContainer = GameObject.Find("GameElements");
    }

    private void Update()
    {
        scoreing = gameManager.score;
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnManager), delayTime, spawnTime);
    }
    private void SpawnManager()
    {
        if (scoreing != 0 && scoreing % 2 == 0)
        {
            SpawnPipe(pipeMoving);
        }
        else if (scoreing != 0 && scoreing % 5 == 0)
        {
            SpawnPipe(doublePipe);
        }
        else
        {
            SpawnPipe(pipeNormal);
        }
    }

    private void SpawnPipe(GameObject pipe)
    {
        float randomIndex = Random.Range(-5, 1);
        Vector3 spawnIndex = new Vector3(spawnPoint.position.x, randomIndex, 0);
        Instantiate(pipe, spawnIndex, Quaternion.identity, gameContainer.transform);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnManager));
    }

}
