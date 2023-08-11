using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacleSpawnPoint;
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject stepText;

    private bool playerInCollider;
    private bool spawnObstacle;
    private bool isSpawned;

    private GameObject currentObstacle;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInCollider) spawnObstacle = true;

        if (spawnObstacle && !isSpawned)
        {
            interactText.SetActive(false);
            stepText.SetActive(true);

            if (!playerInCollider)
            {
                SpawnObstacle();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!spawnObstacle) interactText.SetActive(true);
        playerInCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!spawnObstacle) interactText.SetActive(false);
        playerInCollider = false;
    }

    private void SpawnObstacle()
    {
        currentObstacle = Instantiate(obstaclePrefab, obstacleSpawnPoint.transform.position, Quaternion.identity);
        stepText.SetActive(false);
        meshRenderer.enabled = false;
        isSpawned = true;

        StartCoroutine(CO_Destroy());
    }

    private void ResetObstacle()
    {
        Destroy(currentObstacle);

        meshRenderer.enabled = true;
        spawnObstacle = false;
        isSpawned = false;
    }

    private IEnumerator CO_Destroy()
    {
        yield return new WaitForSeconds(5f);
        ResetObstacle();
    }
}