using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public static Settings current;

    public GameObject loseScreen;
    public List<Transform> movables;
    public float teleportOffset = 5;
    public float spawnOffset = 100f;

    public float asteroidSpawnFrequency = 5f;
    public float UFOSpawnFrequency = 5f;
    public float laserRechargeTime = 5f;
    public int laserChargesOnStart = 1;

    public int laserMaxCharges = 3;


    [HideInInspector]
    public float height;
    [HideInInspector]
    public float width;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public float shipSpeed;
    [HideInInspector]
    public float shipXCoordinate;
    [HideInInspector]
    public float shipYCoordinate;
    [HideInInspector]
    public float shipAngle;
    [HideInInspector]
    public int laserChargesLeft;
    [HideInInspector]
    public float laserCurrentRecharge;


    private void Awake() {
        if (current == null) {
            current = this;
        }

        Setup();
        laserChargesLeft = laserChargesOnStart;
    }

    public void GameLost() {
        loseScreen.SetActive(true);
    }

    public void TurnOffEndscreen() {
        loseScreen.SetActive(false);

    }

    private void Setup() {
        height = Screen.height;
        width = Screen.width;
        score = 0;
    }
}
