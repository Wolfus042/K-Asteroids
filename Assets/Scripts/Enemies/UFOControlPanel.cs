using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOControlPanel { 

    private float initialSpeed = 5f;
    private float speedFactor;

    private float pursuitFactor = 1.5f;
    private Collider2D myCollider;

    private ContactFilter2D contFilter;
    private List<Collider2D> listColliders = new List<Collider2D>();
    private LayerMask destroysWhat;
    private LayerMask weaponToKill;


    private float minLifetime = 4f;

    private GameObject origin;
    private Vector3 initialWanderVector;
    private Vector3 distToShip;
    private bool isEngaged = false;

    public UFOControlPanel(GameObject _origin,  float _initialSpeed, float _pursuitFactor, Collider2D _myCollider, float _speedFactor, LayerMask _destroysWhat, LayerMask _weaponToKill) {
        pursuitFactor = _pursuitFactor;
        initialSpeed = _initialSpeed;
        myCollider = _myCollider;
        origin = _origin;
        speedFactor = _speedFactor;

        destroysWhat = _destroysWhat;
        weaponToKill = _weaponToKill;


    }

    public void FindWanderVector() {
        Vector3 randomPoint = new Vector3(Random.Range((Settings.current.width) / -2, (Settings.current.width) / 2), Random.Range((Settings.current.height) / -2, (Settings.current.height) / 2), 0f);
        initialWanderVector = randomPoint - origin.transform.position; 
    }

    public void Pursuit() {
        distToShip = new Vector3(Settings.current.shipXCoordinate, Settings.current.shipYCoordinate, 0f) - origin.transform.position;

        if (!isEngaged) {
            origin.transform.position += initialWanderVector.normalized * Time.deltaTime * initialSpeed * speedFactor * pursuitFactor;
            if (distToShip.magnitude <= 400f) {
                isEngaged = true;
            }
        } else {
            origin.transform.position += distToShip.normalized * Time.deltaTime * initialSpeed * speedFactor * pursuitFactor;
        }

        CheckOverlap(destroysWhat, weaponToKill);

    }


    public void CheckOverlap(LayerMask destroysWhat, LayerMask weaponToKill) {
        if (myCollider != null) {
            contFilter.NoFilter();
            contFilter.useLayerMask = true;
            contFilter.layerMask = destroysWhat;

            if (Physics2D.OverlapCollider(myCollider, contFilter, listColliders) >= 1) {
                if (listColliders.Count >= 1) {
                    foreach (Collider2D collider in listColliders) {
                        GameObject.Destroy(collider.gameObject);
                    }
                }
            }
            contFilter.NoFilter();
            contFilter.useLayerMask = true;
            contFilter.layerMask = weaponToKill;

            if (Physics2D.OverlapCollider(myCollider, contFilter, listColliders) >= 1) {
                if (listColliders.Count >= 1) {
                    GameObject.Destroy(origin.gameObject);
                }
            }
        }
    }

    public void CheckIfOut() {
        if (minLifetime > 0) {
            minLifetime -= Time.deltaTime;
        }else {
            if ((System.Math.Abs(origin.transform.position.x) > Settings.current.width / 2) || (System.Math.Abs(origin.transform.position.y) > Settings.current.height / 2)) {
                NoScoreWhenDead();
                GameObject.Destroy(origin);
            }
        }

    }
    private void NoScoreWhenDead() {
        UFO originScript = origin.GetComponent<UFO>();
        if (originScript != null)
            originScript.ScoreWhenDead(false);
    }

    public void AddScore(int _score) {
        Settings.current.score += _score;
    }

}
