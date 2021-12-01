using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] 
    private float shootingDelay;

    private BulletManager bulletManager;

    private Coroutine shootingCoroutine;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        if (bulletManager == null)
        {
            Debug.Log("Bullet Manager not found!");
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10.0f, Color.red);
    }

    public void StartShooting()
    {
        StopShooting();
        
        shootingCoroutine = StartCoroutine(ShootCoroutine());
    }

    public void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootingDelay);
        }
    }


    private void Shoot()
    {
        Bullet bullet = bulletManager.RequestBullet();
        bullet.transform.position = transform.position;
        bullet.transform.LookAt(transform.position + transform.forward * 10.0f);
        bullet.OnEndLifetime = () => { ReturnBulletToPool(bullet); };
    }

    private void ReturnBulletToPool(Bullet bullet)
    {
        bulletManager.ReturnBulletToPool(bullet);
    }
}