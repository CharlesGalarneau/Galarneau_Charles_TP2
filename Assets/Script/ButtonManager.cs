using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void GunTurretButton()
    {
        buildManager.SetTurretToBuild(buildManager.GunTurret);
    }
    public void FrostTurretButton()
    {
        buildManager.SetTurretToBuild(buildManager.FrostTurret);
    }

    public void CannonTurretButton()
    {
        buildManager.SetTurretToBuild(buildManager.CannonTurret);
    }


}
