using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int healthCount;
    public int coinCount;

    private Rigidbody2D rb;
    public AudioClip[] audioClipArr;
    private AudioSource audioSource;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float hVelocity = 0;
        float vVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hVelocity = -moveSpeed;
            transform.localScale = new Vector3(-1, 1, 1);


            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hVelocity = moveSpeed;
            transform.localScale = new Vector3(1, 1, 1);

            animator.SetFloat("xVelocity", Mathf.Abs(hVelocity));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vVelocity = jumpForce;
            animator.SetTrigger("JumpTrigger");
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetFloat("xVelocity", 0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("xVelocity", 0);
        }
        hVelocity = Mathf.Clamp(rb.velocity.x + hVelocity, -5, 5);
        rb.velocity = new Vector2(hVelocity, rb.velocity.y + vVelocity);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int randomAudio = Random.Range(0, audioClipArr.Length);
        if (collision.gameObject.tag == "Mace")
        {
            healthCount -= 10;
            audioSource.PlayOneShot(audioClipArr[randomAudio]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coinCount += 1;
            Destroy(collision.gameObject);
        }
    }
}
