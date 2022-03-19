using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public void GotoMainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
