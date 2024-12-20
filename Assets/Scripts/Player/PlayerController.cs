using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSqeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer mySpriteRenderer;
    private InputSystem inputSystem;
    public Health PlayerHealth;



    public void Start()
    {
        PlayerHealth = GetComponent<Health>();
    }
    //Chạy trước hàm Start()
    private void Awake()
    {
        inputSystem = new InputSystem();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        Move();
        RotateFacePlayer();
    }
    //Di chuyển
    private void PlayerInput()
    {
        movement = inputSystem.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * moveSqeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        PlayerHealth.TakeDamage(damage);
    }
    private void RotateFacePlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        //Chuyển vị trí của player sang tạo độ màn hình
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //Thay đổi hướng di chuyển
        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        PlayerHealth.CurrentHeal = Mathf.Clamp(PlayerHealth.CurrentHeal + amount, 0, PlayerHealth.MaxHeal);
    }


}
