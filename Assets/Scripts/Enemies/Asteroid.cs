using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private AsteroidBrain asteroidBrain;
    public Transform thisAsteroid;
    public Transform asteroidSpriteTransform;
    public Collider2D myCollider;
    public LayerMask collidesWith;

    public bool spawnSmallRocksOnDeath = true;
    public GameObject smallRock;

    public float baseSpeed = 3f;
    public float deviation = 2f;
    public float speedFactor = 100f;
    public int scoreVaule = 10;

    [HideInInspector]
    public bool ifScoreWhenDead = true;


    private void OnEnable() {
        asteroidBrain = new AsteroidBrain(gameObject, thisAsteroid, asteroidSpriteTransform, baseSpeed, deviation, speedFactor, myCollider, spawnSmallRocksOnDeath) ;
        asteroidBrain.RotateSprite();
    }

    private void Update() {
        asteroidBrain.Move();
        asteroidBrain.CheckOverlap(collidesWith);

    }

    public void SpawnRock() {
        Instantiate(smallRock, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void ScoreWhenDead(bool data) {
        ifScoreWhenDead = data;
    }

    public void OnDisable() {
        if(ifScoreWhenDead)
        asteroidBrain.AddScore(scoreVaule);
    }
}
