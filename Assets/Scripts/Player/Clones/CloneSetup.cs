using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSetup
{
    private Transform original;
    private Transform nClone;
    private Transform sClone;
    private Transform wClone;
    private Transform eClone;

    public CloneSetup(Transform original, Transform nClone, Transform sClone, Transform wClone, Transform eClone) {
        this.original = original;
        this.nClone = nClone;
        this.sClone = sClone;
        this.wClone = wClone;
        this.eClone = eClone;
    }

    public void SetupClones() {
        nClone.position = new Vector3(original.position.x, original.position.y + (Settings.current.height + Settings.current.teleportOffset), 0);

        sClone.position = new Vector3(original.position.x, original.position.y - (Settings.current.height + Settings.current.teleportOffset), 0);

        wClone.position = new Vector3(original.position.x - (Settings.current.width + Settings.current.teleportOffset), original.position.y, 0);

        eClone.position = new Vector3(original.position.x + (Settings.current.width + Settings.current.teleportOffset), original.position.y, 0);

    }
    
}
