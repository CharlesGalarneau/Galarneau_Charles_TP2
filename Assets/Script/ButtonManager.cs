using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    BuildManager buildManager;
    GameManager gamemanager;
    public int money;
    void Start()
    {
        //permet d'aller chercher le buildmanager
      //  money = Gamemanager.Money;
        buildManager = BuildManager.instance;
    }
    //permet de choisir la tourelle selon le bouton que l'on clique
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
