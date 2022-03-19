using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Transform ship;
    public float constantSlow = 0.025f;
    public float angularDrag = 2f;
    public float forwardAcceleration = 0.75f;
    public float topSpeed = 4f;
    public float minSpeed = 0f;
    public float turningSpeed = 2f;
    Vector3 turningDiretction = new Vector3(0, 0, 0);



    [SerializeField]
    private bool forwardPressed = false;
    [SerializeField]
    private bool leftPressed = false;
    [SerializeField]
    private bool rightPressed = false;
    [SerializeField]
    private bool bulletPressed = false;
    [SerializeField]
    private bool laserPressed = false;




    private float currentSpeed; // Ã√ÕŒ¬≈ÕÕ¿ﬂ — Œ–Œ—“‹
    private Vector3 moveDirection;
    private float speedFactor = 100f;

    private void Start() {
        Debug.Log("Start of ScriptableObject");
        currentSpeed = 0;
        Settings.current.movables.Add(ship);
    }

    void Update()
    {
        ForwardMove();
        SideMovement();
    }

    public void ForwardMove() {
        if (forwardPressed) {
            currentSpeed += forwardAcceleration;
        }
        currentSpeed -= constantSlow;
        if (currentSpeed < minSpeed)
            currentSpeed = minSpeed;
        else if (currentSpeed > topSpeed)
            currentSpeed = topSpeed;
        moveDirection = new Vector3(0f, currentSpeed, 0f);

        moveDirection = transform.TransformDirection(moveDirection);

        //ship.position += moveDirection * Time.deltaTime * speedFactor ;
            //now included in Settings.current.movables

        foreach (Transform movable in Settings.current.movables) {
            movable.position += moveDirection * Time.deltaTime * speedFactor;
        }
    }

    public void SideMovement() {
        //turningDiretction.z -= Mathf.Sign(turningDiretction.z) * angularDrag;

        turningDiretction = Vector3.zero;
        if (leftPressed) {
            turningDiretction.z += turningSpeed;
        }
        if (rightPressed) {
            turningDiretction.z += -turningSpeed;
        }
        //ship.Rotate(turningDiretction * Time.deltaTime * speedFactor);
            //now included in Settings.current.movables

        foreach (Transform movable in Settings.current.movables) {
            movable.Rotate(turningDiretction * Time.deltaTime * speedFactor);
        }
    }


    public void Forward(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            forwardPressed = true;
        } else if (ctx.canceled) {
            forwardPressed = false;
        }
    }
    public void TurnLeft(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            leftPressed = true;
        } else if (ctx.canceled) {
            leftPressed = false;
        }
    }
    public void TurnRight(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            rightPressed = true;
        } else if (ctx.canceled) {
            rightPressed = false;
        }
    }
    public void Bullet(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            bulletPressed = true;
        } else if (ctx.canceled) {
            bulletPressed = false;
        }
    }
    public void Laser(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            laserPressed = true;
        } else if (ctx.canceled) {
            laserPressed = false;
        }
    }
}
