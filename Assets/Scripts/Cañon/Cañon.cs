using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class Cañon : MonoBehaviour
{
    [SerializeField] private Bala proyectilePrefab;
    [SerializeField] private float proyectileSize = 1f;
    [SerializeField] private float fireRate = 2f;

    private float timer;

    private ObjectPool<Bala> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bala>(CreateNewBullet, GetBullet, ReleaseBullet);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    private void Shoot()
    {
        Bala bullet = bulletPool.Get();

        
        bullet.Shoot(transform.forward);
    }

    private Bala CreateNewBullet()
    {
        Bala copy = Instantiate(proyectilePrefab, transform.position, transform.rotation);
        copy.transform.localScale = Vector3.one * proyectileSize;
        copy.MyPool = bulletPool;
        return copy;
    }

    private void GetBullet(Bala bulletToGet)
    {
        bulletToGet.gameObject.SetActive(true);
        bulletToGet.transform.position = transform.position;
    }

    private void ReleaseBullet(Bala bulletToRelease)
    {
        bulletToRelease.gameObject.SetActive(false);
    }
}
