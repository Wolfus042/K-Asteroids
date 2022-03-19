using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public void GotoGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ExitButton() {
        Application.Quit();
    }
}
