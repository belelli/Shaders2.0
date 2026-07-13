using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Bullet Prefabs")]
    [SerializeField] private GameObject bulletType1;
    [SerializeField] private GameObject bulletType2;

    [Header("Spawn Point")]
    [SerializeField] private Transform bulletOrigin;
    
    [Header("Fire")]
    [SerializeField] private float fireCooldown = 0.25f;
    
    private float nextFireTime;

    private int currentBulletType = 1;

    private void Update()
    {
        HandleWeaponSwitch();
        HandleShoot();
    }

    private void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBulletType = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBulletType = 2;
        }
    }

    private void HandleShoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    private void Shoot()
    {
        GameObject bulletPrefab = null;

        switch (currentBulletType)
        {
            case 1:
                bulletPrefab = bulletType1;
                break;

            case 2:
                bulletPrefab = bulletType2;
                break;
        }

        if (bulletPrefab != null && bulletOrigin != null)
        {
            Instantiate(
                bulletPrefab,
                bulletOrigin.position,
                bulletOrigin.rotation
            );
        }
    }
}
