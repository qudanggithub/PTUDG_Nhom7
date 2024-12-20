using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDamage = 5;
    public int maxDamage = 8;
    private EnemyAI enemyAI;
    private BossAI bossAI; //Quanng
    private AdvanceBossAI advanceBossAI; //Quang
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyAI = collision.GetComponent<EnemyAI>();
            Destroy(gameObject); // Hủy đạn khi va chạm
            DamageEnemy();
        }

        if (collision.CompareTag("EnemyLv3"))
        {
            enemyAI = collision.GetComponent<EnemyAI>();
            Destroy(gameObject); // Hủy đạn khi va chạm
            DamageEnemy();
        }

        if (collision.CompareTag("Boss")) //Quang
        {
            if (collision.GetComponent<BossAI>() != null)
            {
                bossAI = collision.GetComponent<BossAI>();
            }
            else if (collision.GetComponent<AdvanceBossAI>() != null)
            {
                advanceBossAI = collision.GetComponent<AdvanceBossAI>();
            }
            Destroy(gameObject);
            DamageBoss();
        }

    }

    public void DamageEnemy()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        enemyAI.TakeDamage(damage);
    }

    public void DamageBoss()
    {
        if (bossAI != null)
        {
            bossAI.TakeDamage(20);
        }
        if (advanceBossAI != null)
        {
            advanceBossAI.TakeDamage(20);
        }
    }

}
