using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunBase : MonoBehaviour
{
    public ProjectileBulletBase projectileBulletPrefab;
    public Transform pointShoot;
    public float timeBetweenShoot = .3f;
    private Coroutine _currentCoroutine;
    public Transform playerSideReference;
    public AudioSource ProjectileBullet;



    private void Awake()
    {
        playerSideReference = GameObject.FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_currentCoroutine != null) 
                StopCoroutine(_currentCoroutine);
        }
    }
      

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        ProjectileBullet.Play();
        var projectile = Instantiate(projectileBulletPrefab);
        projectile.transform.position = pointShoot.transform.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
