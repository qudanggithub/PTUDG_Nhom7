using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HelthABC : MonoBehaviour
{

    public int MaxHeal;
    int CurrentHeal;
    public HealBar healBar;
    public UnityEvent OnDeath;
    // âm thanh trò chơi : 
    public AudioSource audioSource;
    public AudioSource audioSourceDeth;

    void Start()
    {
        CurrentHeal = MaxHeal;
        healBar.UpdateBar(CurrentHeal, MaxHeal);
        if (audioSource != null)
        {
            audioSource.Play();

        }

    }

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Death()
    {
        Destroy(this.gameObject);
        if (this.gameObject == null)
        {

        }
        if (audioSourceDeth != null)
        {
            audioSourceDeth.Play();

        }
    }

    public void TakeDamage(int damage)
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
            Debug.Log("Enemy");
            if (CurrentHeal <= 0)
            {

                CurrentHeal = 0;
                Death();
                audioSourceDeth.Stop();
                audioSource.Stop();
            }
        }
    }
}
