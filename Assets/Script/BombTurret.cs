using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrok : MonoBehaviour
{

    Rigidbody[] rbs;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        //desactiver le ragdoll
        ToggleRagdoll(false);
    }

    public void TakeDamage()
    {
        Die();
    }
    // Update is called once per frame
    void Die()
    {
        //Activer le ragdoll
        ToggleRagdoll(true);

    }

    void ToggleRagdoll(bool value)

    {
        foreach (var r in rbs)
        {
            r.isKinematic = !value;
        }
        animator.enabled = !value;
    }
}
