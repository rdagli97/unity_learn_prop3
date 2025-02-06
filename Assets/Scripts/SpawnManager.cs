using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    public float startDelay = 2f;
    public float repeatRate = 1f;

    private PlayerController playerController;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacle()
    {
        if (!playerController.isGameOver)
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
