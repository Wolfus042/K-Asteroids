using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput
{
    private bool forwardPressed = false;
    private bool leftPressed = false;
    private bool rightPressed = false;

    private Transform ship;
    private float constantSlow = 0.2f;
    private float angularDrag = 2f; //unused for now
    private float forwardAcceleration = 1f;
    private float topSpeed = 3f;
    private float minSpeed = 0f;
    private float turningSpeed = 0.5f;
    Vector3 turningDiretction = new Vector3(0, 0, 0);

    private float currentSpeed; // ÌÃÍÎÂÅÍÍÀß ÑÊÎÐÎÑÒÜ
    private Vector3 moveDirection;
    private float speedFactor = 100f;

    public MovementInput(Transform ship, MovementSettings inputSettings) {
        this.ship = ship;
        Settings.current.movables.Add(ship);
        this.constantSlow = inputSettings.constantSlow;
        this.angularDrag = inputSettings.angularDrag;
        this.forwardAcceleration = inputSettings.forwardAcceleration;
        this.topSpeed = inputSettings.topSpeed;
        this.minSpeed = inputSettings.minSpeed;
        this.turningSpeed = inputSettings.turningSpeed;
        this.speedFactor = inputSettings.speedFactor;
    }   

    public void Movement() {
        ForwardMove();
        SideMovement();
    }

    public void TransferData() {
        Settings.current.shipSpeed = currentSpeed;
        Settings.current.shipXCoordinate = ship.position.x;
        Settings.current.shipYCoordinate = ship.position.y;

        if (ship.rotation.eulerAngles.z > 0) {
            Settings.current.shipAngle = 360f - ship.rotation.eulerAngles.z;
        } else {
            Settings.current.shipAngle = ship.rotation.eulerAngles.z * -1f;
        }
        

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

        moveDirection = ship.TransformDirection(moveDirection);

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

    public void Forward(bool context) {
        if (context) {
            forwardPressed = true;
        } else {
            forwardPressed = false;
        }
    }
    public void TurnLeft(bool context) {
        if (context) {
            leftPressed = true;
        } else {
            leftPressed = false;
        }
    }
    public void TurnRight(bool context) {
        if (context) {
            rightPressed = true;
        } else {
            rightPressed = false;
        }
    }

}
