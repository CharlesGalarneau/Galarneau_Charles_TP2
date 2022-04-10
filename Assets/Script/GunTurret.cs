using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : Turret
{
    //definie les variables besoins pour le gun turret
    protected override void Setup()
    {
        base.FireCountdown = 1;
    }


}
