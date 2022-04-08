using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinChemin : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ennemies"))
        {
            Destroy(other.gameObject);
            gamemanager manager = FindObjectOfType<gamemanager>();
            manager.PlayerLife --;
            Debug.Log(manager.PlayerLife);
        }
    }
}
