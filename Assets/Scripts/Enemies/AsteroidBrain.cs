using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBrain
{
    private float speed;
    private float speedFactor;
    private GameObject origin;
    private Transform asteroid;
    private Transform asteroidSpriteTransform;

    private Vector3 moveDirection;
    private float minLifetime = 2f;

    private Collider2D collider;
    private List<Collider2D> colColliders = new List<Collider2D>();
    private ContactFilter2D contFilter;

    private bool spawnSmallRocksOnDeath = true;


    public AsteroidBrain(GameObject _origin, Transform _asteroid, Transform _asteroidSpriteTransform, float _baseSpeed, float _deviation, float _speedFactor, Collider2D _collider, bool _spawnSmallRocksOnDeath) {
        speed = Random.Range(_baseSpeed - _deviation, _baseSpeed + _deviation);
        asteroid = _asteroid;
        speedFactor = _speedFactor;
        asteroidSpriteTransform = _asteroidSpriteTransform;
        origin = _origin;
        collider = _collider;
        spawnSmallRocksOnDeath = _spawnSmallRocksOnDeath;


    }


    public void Move() {
        moveDirection = new Vector3(0f, speed * Time.deltaTime * speedFactor, 0f);
        moveDirection = asteroid.TransformDirection(moveDirection);

        asteroid.position += moveDirection;
        CheckIfOut();
    }

    private void CheckIfOut() {
        if (minLifetime > 0) {
            minLifetime -= Time.deltaTime;

            /*if (minLifetime > 0)
                Debug.Log("timeout");*/
        } else {
            if ( (System.Math.Abs(asteroid.position.x) > Settings.current.width / 2) || (System.Math.Abs(asteroid.position.y) > Settings.current.height / 2) ) {
                NoScoreWhenDead();
                GameObject.Destroy(origin);
            }
        }
    }

    private void NoScoreWhenDead() {
        Asteroid originScript = origin.GetComponent<Asteroid>();
        if (originScript != null) {
            originScript.ScoreWhenDead(false);
            //Debug.Log("All fine.");
        } else {
            //Debug.LogError("No asteroid script!");
        }
    }

    public void CheckOverlap(LayerMask layerMask) {
        if(collider != null) {
            contFilter.NoFilter();
            contFilter.useLayerMask = true;
            contFilter.layerMask = layerMask;

            if (Physics2D.OverlapCollider(collider, contFilter, colColliders) >= 1) {
                if (colColliders.Count >= 1) {
                    foreach (Collider2D collider in colColliders) {
                        //Debug.Log("Collision");
                        if(spawnSmallRocksOnDeath) SpawnRocks(2);
                        if (collider.gameObject.name != "LaserCollider")
                        GameObject.Destroy(collider.gameObject);
                    }
                    GameObject.Destroy(origin);
                }
            }
        }
    }

    private void SpawnRocks(int num) {
        Asteroid asteroid = origin.GetComponent<Asteroid>();
        if (asteroid != null) {
            for (int i = 0; i < num; i++) {
                asteroid.SpawnRock();
            }
        } else {
            Debug.Log("no Asteroid component found!");
        }
            
    }

    public void AddScore(int _score) {
        Settings.current.score += _score;
    }

    public void RotateSprite() {
        //an odd way to check if that's a smallRock or not, for sure, but it's easier than reinvent all architechture for this small task 
        if (spawnSmallRocksOnDeath) {
            int rotation = Random.Range(0, 360);
            collider.transform.Rotate(Vector3.forward, rotation);
            asteroidSpriteTransform.Rotate(Vector3.forward, rotation);
        } else {
            //Debug.Log("I'm a rock!");
            asteroidSpriteTransform.Rotate(Vector3.forward, Random.Range(0, 360));
            origin.transform.Rotate(Vector3.forward, Random.Range(0, 360));
        }

    }
}
