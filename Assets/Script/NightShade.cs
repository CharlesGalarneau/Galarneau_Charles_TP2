using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NightShade : Ennemies
{
    private float hitpoint = 2f;
    private float vitesse = 5f;
    private float purse = 2f;
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

