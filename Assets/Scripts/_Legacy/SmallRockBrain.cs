using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRockBrain 
{
    private float speed;

    private Vector3 moveDirection;
    private GameObject origin;
    private float speedFactor = 100f;

    public SmallRockBrain(float _speed, GameObject _origin) {
        speed = _speed;
        origin = _origin;
    }

    public void Move() {
        moveDirection = new Vector3(0f, speed * Time.deltaTime * speedFactor, 0f);
        moveDirection = origin.transform.TransformDirection(moveDirection);

        origin.transform.position += moveDirection;
        CheckIfOut();
    }

    private void CheckIfOut() {
        if ((System.Math.Abs(origin.transform.position.x) > Settings.current.width / 2) || (System.Math.Abs(origin.transform.position.y) > Settings.current.height / 2)) {
            //Debug.Log("Out of borders!");
            GameObject.Destroy(origin);
        }
    }
}
