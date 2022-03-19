using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    private CloneSetup cloneSetup;
    public Transform original;
    public Transform nClone;
    public Transform sClone;
    public Transform wClone;
    public Transform eClone;

    void Start()
    {
        cloneSetup = new CloneSetup(original, nClone, sClone, wClone, eClone);
        cloneSetup.SetupClones();
    }
}
