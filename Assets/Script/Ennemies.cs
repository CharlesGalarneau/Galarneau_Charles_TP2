using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    int hitpoints;
    float despawnedTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Onhit()
    {
        //donne du dommages a l'ennemies selon l'armes
        hitpoints--;
        if (hitpoints < 0)
            die();
    }
    void die()
    {
        
        ra
    }
        

}
