using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InputSettings", menuName = "ScriptableObjects/InputSettings")]
public class MovementSettings : ScriptableObject {

    public float constantSlow = 0.025f;
    public float angularDrag = 2f;
    public float forwardAcceleration = 0.75f;
    public float topSpeed = 4f;
    public float minSpeed = 0f;
    public float turningSpeed = 2f;
    public float speedFactor = 100f;
}
