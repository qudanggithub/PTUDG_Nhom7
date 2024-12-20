using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int MaxHeal;
    public int CurrentHeal;
    public HealBar healBar;
    public UnityEvent OnDeath;
    // âm thanh

    public AudioSource audioSource;
    public AudioSource audioSourceDeth;

    void Start()
    {
        CurrentHeal = MaxHeal;
        if (healBar != null)
        {
            healBar.UpdateBar(CurrentHeal, MaxHeal);
        }
        if (audioSource != null)
        {
            audioSource.Play();

        }
    }

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }
    public void Death()
    {
        Destroy(this.gameObject);
        if (audioSourceDeth != null)
        {
            audioSourceDeth.Play();

        }
    }

    public void DeathWithAnimation(Animator animator)
    {
        animator.SetBool("Death", true);
    }
    public void TakeDamage(int damage, Animator animator = null)
    {


        if (this.gameObject.tag == "Player")
        {
            CurrentHeal -= damage;
            if (CurrentHeal <= 0)
            {
                CurrentHeal = 0;
                Death();
                audioSource.Stop();
                SceneManager.LoadScene(0);
            }
            healBar.UpdateBar(CurrentHeal, MaxHeal);
        }

        if (this.gameObject.tag == "Enemy")
        {
            CurrentHeal -= damage;
            if (CurrentHeal <= 0)
            {

                CurrentHeal = 0;
                if (animator != null)
                {
                    //Debug.Log("Nghiêm Hồng");
                    DeathWithAnimation(animator);
                }
                else
                {
                    Death();
                    audioSource.Stop();
                }
            }
        }

        if (this.gameObject.tag == "EnemyLv3")
        {
            CurrentHeal -= damage;
            if (CurrentHeal <= 0)
            {

                CurrentHeal = 0;
                Death();
            }
        }

        if (this.gameObject.tag == "Boss")
        {
            CurrentHeal -= damage;
            if (CurrentHeal <= 0)
            {

                CurrentHeal = 0;
                if (animator != null)
                {
                    DeathWithAnimation(animator);
                }
                else
                {
                    Death();
                }
            }
        }

    }


}
