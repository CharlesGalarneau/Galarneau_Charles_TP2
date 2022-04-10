using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NightShade : Ennemies
{
    //permet d'activer l'animation de flotte du nightshade
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pathway"))
            animator.SetBool("IsFloating", true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pathway"))
            animator.SetBool("IsFloating", false);
    }
}

