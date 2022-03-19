using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem 
{
    private GameObject bulletPrefab;
    private float bulletFireDelay = 0.3f;
    private float laserFireDelay = 1.5f;

    private GameObject laserPrefab;

    private Player origin;

    private bool bulletButton = false;
    private bool laserButton = false;
    private float currentBulletFireDelay = 0f;
    private float currentLaserFireDelay = 0f;

    private float laserCurrentRecharge = 0f;


    public WeaponSystem(WeaponList settings, Player origin) {
        this.bulletPrefab = settings.bulletPrefab;
        this.bulletFireDelay = settings.bulletFireDelay;
        
        this.laserPrefab = settings.laserPrefab;
        this.laserFireDelay = settings.laserFireDelay;

        this.origin = origin;
        laserCurrentRecharge = Settings.current.laserRechargeTime;

    }

    public void WeaponShooting() {
        currentBulletFireDelay -= Time.deltaTime;
        currentLaserFireDelay -= Time.deltaTime;
        if ( (bulletButton) && (currentBulletFireDelay <= 0) ) {
            origin.SpawnProjectile(bulletPrefab, true);
            currentBulletFireDelay = bulletFireDelay;
        }
        if ( (laserButton) && (currentLaserFireDelay <= 0) ) {
            if (Settings.current.laserChargesLeft > 0) {
                origin.SpawnProjectile(laserPrefab, false);
                currentLaserFireDelay = laserFireDelay;
                Settings.current.laserChargesLeft -= 1;
            }
        }
    }

    public void LaserCharge() {
        if (Settings.current.laserChargesLeft != Settings.current.laserMaxCharges) {
            laserCurrentRecharge -= Time.deltaTime;
        } else {
            laserCurrentRecharge = Settings.current.laserRechargeTime;  
        }
        if (laserCurrentRecharge <= 0 ) {
            if (Settings.current.laserChargesLeft < Settings.current.laserMaxCharges) {
                Settings.current.laserChargesLeft++;
                laserCurrentRecharge = Settings.current.laserRechargeTime;
            }
        }
        Settings.current.laserCurrentRecharge = laserCurrentRecharge;
    }

    public void BulletButton(bool isPressed) {
        bulletButton = isPressed;
    }
    public void LaserButton(bool isPressed) {
        laserButton = isPressed;
    }
    

}
