using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;
    public Animator anim;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
    public HealthBase healthBase;
    public float timeDestroyEnemy = 3f;
    public AudioSource AudioSourceKill;


    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.onKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.onKill -= OnEnemyKill;
        DeathEnemy();
        if (AudioSourceKill != null) AudioSourceKill.Play();
        Destroy(gameObject, timeDestroyEnemy);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayerAttackAnimation();
        }
    }

    private void PlayerAttackAnimation()
    {
        anim.SetTrigger(triggerAttack);
    }

    private void DeathEnemy()
    {
        anim.SetTrigger(triggerDeath);
    }


    public void Damage(int damage)
    {
        healthBase.Damage(damage);
    }
}
