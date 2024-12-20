using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 5;
    private PlayerController player;

    public Health health;



    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Hủy đạn khi va chạm
            player = collision.GetComponent<PlayerController>();
            //Gây sát thương nhiều lần khi collider của enemy ở trong player=> với quái đánh gần
            //InvokeRepeating("DamagePlayer", 0, 0.1f);

            DamagePlayer();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    public void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        player.TakeDamage(damage);
    }
}
