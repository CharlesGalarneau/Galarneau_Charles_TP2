using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject TurretToBuild;
    public GameObject TurretBuilder;
    public GameObject GunTurret;
    public GameObject CannonTurret;
    public GameObject FrostTurret;
    private void Awake()
    {
        instance = this;
    }
   
   
    //retourne la tourelle que l'on veut construire
    public GameObject GetTurretToBuild()
    {
        return TurretToBuild;
    }
    //définie la tourelle que l'on veut construire
   public void SetTurretToBuild(GameObject turret)
    {
        TurretToBuild = turret;
    }
}
