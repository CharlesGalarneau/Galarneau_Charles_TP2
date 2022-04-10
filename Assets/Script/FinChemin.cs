using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinChemin : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        //detecte si l'ennemies touche a son collider si oui il le tue
        if (other.CompareTag("Ennemies"))
        {
            Destroy(other.gameObject);
            GameManager manager = FindObjectOfType<GameManager>();
            manager.PlayerLife --;
            manager.Killed++;
            Debug.Log(manager.PlayerLife);
        }
    }
}
