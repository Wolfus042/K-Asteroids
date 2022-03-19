using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float fadeTime = 1f;
    private LaserBrain laserBrain;

    public float fadeTarget;
    public float fadeQUEST;


    private void Start() {
        laserBrain = new LaserBrain(gameObject, fadeTime);
    }

    private void Update() {
        laserBrain.Fade();
        fadeTarget = laserBrain.fadeTimeTarget;
        fadeQUEST = laserBrain.fadeTimeCurrent;
    }

}
