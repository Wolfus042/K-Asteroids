using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRock : MonoBehaviour
{
    private SmallRockBrain brain;
    public float speed;

    private void Start() {
        brain = new SmallRockBrain(speed, gameObject);
    }

    private void Update() {
        brain.Move();
    }
}
