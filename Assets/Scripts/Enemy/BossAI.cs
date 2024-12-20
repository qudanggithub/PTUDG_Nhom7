using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float moveSpeed = 8f; // Tốc độ di chuyển của quái vật
    public float chaseRange = 50f; // Khoảng cách để quái vật bắt đầu đuổi theo người chơi

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private Transform player; // Tham chiếu đến người chơi
    private Vector2 movementDirection;
    private SpriteRenderer mySpriteRenderer;
    public Sprite advanceSprite;
    public Health EnemyHealth;
    private Animator animator;
    private PlayerController playerController;
    public GameObject currentObject; // Reference to the current GameObject
    public GameObject newObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemyHealth = GetComponent<Health>();
        // Khởi tạo hướng di chuyển ban đầu
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerController>().transform;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < chaseRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movementDirection = direction;
        }


        if (distanceToPlayer < 4)
        {
            animator.ResetTrigger("Run");
            moveSpeed = 0f;
            animator.SetBool("Attack", true);
        }
        else
        {
            moveSpeed = 8.0f;
            MoveEnemy();
        }

        if (EnemyHealth.CurrentHeal < 400)
        {
            animator.ResetTrigger("Run");
            animator.SetBool("Ability", true);
        }


    }

    void MoveEnemy()
    {
        animator.SetTrigger("Run");
        animator.SetBool("Attack", false);
        // Di chuyển quái vật
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);

        player = FindObjectOfType<PlayerController>().transform;
        if (player.position.x < transform.position.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }


    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //    if (other.CompareTag("Player"))
    //    {
    //        playerController = other.GetComponent<PlayerController>();

    //        if (playerController != null)
    //        {
    //            playerController.TakeDamage(50);
    //        }
    //    }

    //}

    public void ChangePhase()
    {
        Instantiate(newObject, transform.position, transform.rotation); ;
        // Destroy the current GameObject
        Destroy(gameObject);

    }

    public void BossAttackEnd()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.TakeDamage(30);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Boss hp " + EnemyHealth.CurrentHeal);
        EnemyHealth.TakeDamage(damage, animator);
    }

}
