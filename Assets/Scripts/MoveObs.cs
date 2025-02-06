using UnityEngine;

public class MoveObs : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
