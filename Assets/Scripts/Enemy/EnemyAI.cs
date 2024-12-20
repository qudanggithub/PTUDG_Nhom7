using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f; // Tốc độ di chuyển của quái vật
    public float chaseRange = 50f; // Khoảng cách để quái vật bắt đầu đuổi theo người chơi

    private Rigidbody2D rb;
    private Transform player; // Tham chiếu đến người chơi
    private Vector2 movementDirection;
    private SpriteRenderer mySpriteRenderer;
    private Health EnemyHealth;
    private Animator myAnimator;


    //Shoot
    public bool isShoot = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float TimeShoot;
    private float FireCoolDown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemyHealth = GetComponent<Health>();
        // Khởi tạo hướng di chuyển ban đầu
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveEnemy();
        FireCoolDown -= Time.deltaTime;
        if (FireCoolDown < 0f)
        {
            FireCoolDown = TimeShoot;
            float distanceFromPlayerToEnemy = Vector2.Distance(transform.position, player.position);

            //Shoot khi player lại gần enemy
            if (isShoot && distanceFromPlayerToEnemy < chaseRange)
            {
                EnemyFireBullet();
            }


        }

        // Kiểm tra khoảng cách giữa quái vật và người chơi
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            // Nếu người chơi ở gần, quái vật sẽ đuổi theo người chơi
            player = FindObjectOfType<PlayerController>().transform;
            Vector2 direction = (player.position - transform.position).normalized;
            movementDirection = direction;
        }

    }

    public void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bulletTmp.GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = FindObjectOfType<PlayerController>().transform;
        }

        Vector3 direction = player.position - transform.position;

        bulletRb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    void MoveEnemy()
    {
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

    public void TakeDamage(int damage, Animator animator = null)
    {
        EnemyHealth.TakeDamage(damage, myAnimator);
    }
}
