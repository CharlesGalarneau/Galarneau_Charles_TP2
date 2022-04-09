using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject TurretToBuild;
    public GameObject TurretBuilder;
    private void Awake()
    {
        instance = this;
    }
   
    private void Start()
    {
        TurretToBuild = TurretBuilder;

    }
    
    public GameObject GetTurretToBuild()
    {
        return TurretToBuild;
    }
   
}
