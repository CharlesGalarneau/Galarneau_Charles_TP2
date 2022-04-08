using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    Rigidbody[] rbs;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        //desactiver le ragdoll
       
    }

    public void TakeDamage()
    {
        
    }
    

    
}
