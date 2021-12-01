using System;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private ObjectPool<Bullet> bulletPool;

    [SerializeField] 
    private GameObject bulletPrefab;

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet);
    }

    private Bullet CreateBullet()
    {
        var createdBullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        return createdBullet;
    }

    public Bullet RequestBullet()
    {
        return bulletPool.GetObjectFromPool();
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        bulletPool.ReturnObjectToPool(bullet);
    }
}