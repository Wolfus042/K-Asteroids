using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSettings", menuName = "ScriptableObjects/WeaponSettings")]
public class WeaponList : ScriptableObject {

    public GameObject bulletPrefab;
    public float bulletFireDelay = 0.3f;


    public GameObject laserPrefab;
    public float laserFireDelay = 1.5f;

}
