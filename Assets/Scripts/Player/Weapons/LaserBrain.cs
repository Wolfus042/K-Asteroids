using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBrain
{
    public float fadeTimeTarget;
    public float fadeTimeCurrent = 0f;
    private GameObject origin;


    public LaserBrain(GameObject _origin, float _fadeTimeTarget) {
        fadeTimeTarget = _fadeTimeTarget;
        origin = _origin;
    }

    public void Fade() {
        fadeTimeCurrent += Time.deltaTime;
        if (fadeTimeCurrent >= fadeTimeTarget) {
            GameObject.Destroy(origin);
        }
    }
}
