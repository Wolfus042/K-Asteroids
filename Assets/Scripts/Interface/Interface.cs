using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    private InterfaceHandler _UIHandler;

    public Text coordinates;
    public Text angle;
    public Text speed;
    public Text laserChargesLeft;
    public Text laserCooldown;
    public Text score;
    public Text finalScore;

    private void Start() {
        _UIHandler = new InterfaceHandler(coordinates, angle, speed, laserChargesLeft, laserCooldown, score, finalScore);
    }

    private void Update() {
        _UIHandler.DrawText();
    }

}
