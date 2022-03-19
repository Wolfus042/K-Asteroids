using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public LayerMask destroysWhat;
    public LayerMask weaponToKill;
    public Collider2D myCollider;
    public float initialSpeed = 5f;
    public float pursuitFactor = 1.5f;
    public int scoreValue = 35;

    private float speedFactor = 100f;

    [HideInInspector]
    public Vector3 initialWanderVector;


    private UFOControlPanel controls;
    private bool ifScoreWhenDead = true;

    private void Start() {
        controls = new UFOControlPanel(gameObject, initialSpeed, pursuitFactor, myCollider, speedFactor, destroysWhat, weaponToKill);
        controls.FindWanderVector();
    }

    private void Update() {
        controls.Pursuit();
        controls.CheckIfOut();
    }

    public void ScoreWhenDead(bool data) {
        ifScoreWhenDead = data;
    }

    public void OnDisable() {
        //Debug.LogWarning("Noo! Death to humans!...");
        if (ifScoreWhenDead)
            controls.AddScore(scoreValue);
    }
}
