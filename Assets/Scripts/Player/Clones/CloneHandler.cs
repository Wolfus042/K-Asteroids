using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneHandler
{
    Transform cloneTransform;
    public enum CloneDirection {
        North,
        South,
        East,
        West
    }

    public CloneDirection thisCloneDirection;

    public CloneHandler(Clone.CloneDirection cloneDirection, Transform transform) {
        thisCloneDirection = (CloneDirection)cloneDirection;
        cloneTransform = transform;
    }

    public void CheckBoundaries() {
        if ( (thisCloneDirection == CloneDirection.North) && (cloneTransform.position.y > 1.5*(Settings.current.height)) ) {           
            foreach (Transform movable in Settings.current.movables) {
                movable.transform.position -= new Vector3(0, Settings.current.height, 0);
            }
            TeleportationEffect(thisCloneDirection);
        }
        else if ((thisCloneDirection == CloneDirection.South) && (cloneTransform.position.y < -1.5 * (Settings.current.height))) {
            foreach (Transform movable in Settings.current.movables) {
                movable.transform.position += new Vector3(0, Settings.current.height, 0);
            }
            TeleportationEffect(thisCloneDirection);
        } else if ((thisCloneDirection == CloneDirection.West) && (cloneTransform.position.x < -1.5 * (Settings.current.width))) {
            foreach (Transform movable in Settings.current.movables) {
                movable.transform.position += new Vector3(Settings.current.width, 0, 0);
            }
            TeleportationEffect(thisCloneDirection);
        } else if ((thisCloneDirection == CloneDirection.East) && (cloneTransform.position.x > 1.5 * (Settings.current.width))) {
            foreach (Transform movable in Settings.current.movables) {
                movable.transform.position -= new Vector3(Settings.current.width, 0, 0);
            }
            TeleportationEffect(thisCloneDirection);
        }
    }

    /// <summary>
    /// Debug tool for correct teleportation. Works fine now, i guess!
    /// </summary>
    /// <param name="cDir"></param>
    private void TeleportationEffect(CloneDirection cDir) {
        Debug.Log("Teleported from" + cDir.ToString());
    }

}
