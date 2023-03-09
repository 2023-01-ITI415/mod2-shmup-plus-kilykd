using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(BoundsCheck) )]
public class ProjectileBoss : MonoBehaviour
{
    private BoundsCheck  bndCheck;

    void Awake() {
        bndCheck = GetComponent<BoundsCheck>();
    }

    void Update () {
        if ( bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown) ) {       
            Destroy( gameObject );
        }
    }
}
