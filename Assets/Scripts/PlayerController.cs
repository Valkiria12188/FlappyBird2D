using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float force;
    private Rigidbody2D rb;
    private Animation anim;
    private AudioManager audioManager;

    private bool isPlayerActive;
    private bool flag = true;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    void Start()
    {
        isPlayerActive = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (isPlayerActive)
        {
            Movement();
        }
    }
    private void Movement()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            audioManager.OnPlayerTapToFly();
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * 5f);
    }

    public void MiniJump(int direction)
    {
        rb.velocity = new Vector2(rb.velocity.x, force * direction * 2);
    }

    public void Die()
    {
        if (flag)
        {
            isPlayerActive = false;
            if (anim.isPlaying)
            {
                anim.Stop();
            }
            MiniJump(1);
            flag = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject != null)
        {
            if (other.gameObject.CompareTag("ScoringPlace"))
            {
                FindObjectOfType<GameManager>().IncreaseScore();
            }
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Die();
                FindObjectOfType<GameManager>().DelayGameOver();
            }
            if (other.gameObject.CompareTag("BoundariesUp"))
            {
                MiniJump(-1);
            }
            if (other.gameObject.CompareTag("BoundariesDown"))
            {
                MiniJump(1);
            }
        }
    }
}


