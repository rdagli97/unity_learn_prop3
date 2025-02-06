using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator anim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatterParticle;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            dirtSplatterParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGameOver)
        {
            isOnGround = true;
            dirtSplatterParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            dirtSplatterParticle.Stop();
            explosionParticle.Play();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over!");
        }
    }
}
