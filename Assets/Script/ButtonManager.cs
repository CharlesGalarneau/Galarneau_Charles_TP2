using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    BuildManager buildManager;
    gamemanager Gamemanager;
    public int money;
    void Start()
    {
      //  money = Gamemanager.Money;
        buildManager = BuildManager.instance;
    }
    public void GunTurretButton()
    {
      //  if (money >= 1)
            buildManager.SetTurretToBuild(buildManager.GunTurret);
         money-=1;
    }
    public void FrostTurretButton()
    {
       // if (money >= 3)
            buildManager.SetTurretToBuild(buildManager.FrostTurret);
    }

    public void CannonTurretButton()
    {
     // if (money >=5)

        buildManager.SetTurretToBuild(buildManager.CannonTurret);

    }


}
