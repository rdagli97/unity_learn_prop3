using UnityEngine;

public class MoveObs : MonoBehaviour
{
    public float speed;
    private PlayerController playerController;
    private float leftBound = -15f;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.isGameOver == false)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
