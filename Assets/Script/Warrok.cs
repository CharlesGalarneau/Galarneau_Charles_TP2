using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warrok : Ennemies
{
    bool isDuplicate;
    public AudioRenderer Audio;
    //permet de definir une valeur que long change selon l'ennemies
    protected override void Setup()
    {
        pvEnnemi = 8;
        if (isDuplicate == true)
        {
            // valeur qui sert pou diviser les pv du Warrok en deux pour ses doubles
            float pvEnnemiFlt = pvEnnemi;
            pvEnnemi = Mathf.RoundToInt(pvEnnemiFlt * 0.5f);
            ennemiGold = 75;
        }

    }
}



