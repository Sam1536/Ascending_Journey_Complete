using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBulletBase: MonoBehaviour
{
    public float bulletSpeed;
    public float timeDestroyProjectile = 3f;
    public Vector3 direction;
    public float side = 1f;
    public int damageAmount;


    private void Awake()
    {
        Destroy(gameObject, timeDestroyProjectile);
    }

    private void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime * side);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
