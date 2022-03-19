using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private RocketBrain rocketBrain;

    public float bulletSpeed = 6f;

    private void Start() {
        rocketBrain = new RocketBrain(this, bulletSpeed, gameObject) ;
    }

    private void Update() {
        rocketBrain.Move();
    }
}
