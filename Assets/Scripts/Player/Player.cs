using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public MovementSettings movementSettings;
    public WeaponList weaponSettings;
    
    private MovementInput moveinput;
    private WeaponSystem weaponSystem;

    public Transform ship;
    public Transform shootingOrigin;
    public Transform projectileContainer;

    private void Start() {
        moveinput = new MovementInput(ship, movementSettings);
        weaponSystem = new WeaponSystem(weaponSettings, this);
        Settings.current.TurnOffEndscreen();
    }

    private void Update() {
        moveinput.Movement();
        moveinput.TransferData();
        weaponSystem.WeaponShooting();
        weaponSystem.LaserCharge();
    }

    public void SpawnProjectile(GameObject prefab, bool ifIndependent) {
        Transform parentTransfom;
        if (ifIndependent) {
            parentTransfom = null;
        } else {
            parentTransfom = projectileContainer;
        }
        Instantiate(prefab, shootingOrigin.transform.position, this.transform.rotation, parentTransfom);
    }

    public void OnDestroy() {
        Settings.current.GameLost();
    }

    public void Forward(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            moveinput.Forward(true);
        } else if (ctx.canceled) {
            moveinput.Forward(false);
        }
    }
    public void TurnLeft(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            moveinput.TurnLeft(true);
        } else if (ctx.canceled) {
            moveinput.TurnLeft(false);
        }
    }
    public void TurnRight(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            moveinput.TurnRight(true);
        } else if (ctx.canceled) {
            moveinput.TurnRight(false);
        }
    }
    public void Bullet(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            weaponSystem.BulletButton(true);
        } else if (ctx.canceled) {
            weaponSystem.BulletButton(false);
        }
    }
    public void Laser(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            weaponSystem.LaserButton(true);
        } else if (ctx.canceled) {
            weaponSystem.LaserButton(false);
        }
    }
}
