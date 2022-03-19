using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceHandler
{
    private Text coordinates;
    private Text angle;
    private Text speed;
    private Text laserChargesLeft;
    private Text laserCooldown;
    private Text score;
    private Text finalScore;

    private string stringX;
    private string stringY;

    public InterfaceHandler(Text _coordinates, Text _angle, Text _speed, Text _laserChargesLeft, Text _laserCooldown, Text _score, Text _finalScore) {
        coordinates = _coordinates;
        angle = _angle;
        speed = _speed;
        laserChargesLeft = _laserChargesLeft;
        laserCooldown = _laserCooldown;
        score = _score;
        finalScore = _finalScore;
    }

    public void DrawText() {
        stringX = Settings.current.shipXCoordinate.ToString("F0");
        stringY = Settings.current.shipYCoordinate.ToString("F0");
        coordinates.text = "x: " + stringX + ", y: " + stringY;

        angle.text = Settings.current.shipAngle.ToString("F0") + "°";

        speed.text = Settings.current.shipSpeed.ToString("F2") + " km/s";
        score.text = "Score: " + Settings.current.score.ToString();
        finalScore.text = "Final score: " + Settings.current.score.ToString();

        laserChargesLeft.text = "Laser batteries ready: " + Settings.current.laserChargesLeft.ToString();
        laserCooldown.text = "Loading next battery: " + Settings.current.laserCurrentRecharge.ToString("F2");
    }


}
