using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBrain
{
    private Rocket origin;
    private float bulletSpeed;
    private GameObject bullet;

    private float speedFactor = 100f;
    private Vector3 moveDirection;
    private Collider2D colCollider;


    public RocketBrain(Rocket origin, float bulletSpeed, GameObject bullet) {
        this.origin = origin;
        this.bulletSpeed = bulletSpeed;
        this.bullet = bullet;
    }

    public void Move() {
        moveDirection = new Vector3(0f, bulletSpeed * Time.deltaTime * speedFactor, 0f);
        moveDirection = bullet.transform.TransformDirection(moveDirection);

        bullet.transform.position += moveDirection;
        CheckIfOut();
    }



    private void CheckIfOut() {
        if ((System.Math.Abs(bullet.transform.position.x) > Settings.current.width / 2) || (System.Math.Abs(bullet.transform.position.y) > Settings.current.height / 2)) {
            //Debug.Log("Out of borders!");
            GameObject.Destroy(origin.gameObject);
        }
    }
}
