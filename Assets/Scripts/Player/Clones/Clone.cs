using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    private CloneHandler cloneHandler;
    public enum CloneDirection {
        North,
        South,
        East,
        West
    }

    public CloneDirection cloneDirection;

    public void Start() {
        if (Settings.current != null)
            Settings.current.movables.Add(transform);
        else
            Debug.Log("no current settings!");

        cloneHandler = new CloneHandler(cloneDirection, this.transform);
    }

    private void Update() {
        cloneHandler.CheckBoundaries();
    }


}
