using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemies : MonoBehaviour
{
    int hitpoints;
    float Timeout = 5f;
    bool isDead;
     GameObject ennemies;
     NavMeshAgent agent;
    protected Rigidbody[] ListEnnemies;
    protected Animator animator;
    Vector3 Destionation;
    // Start is called before the first frame update
    void Start()
    {
        Destionation = Destination();
        ListEnnemies = GetComponentsInChildren<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Die(false);
        agent.SetDestination(Destionation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator despawnedTimer()
    {
        Timeout -= 1;
        yield  return Timeout;
    }
    void Onhit()
    {
        //donne du dommages a l'ennemies selon l'armes
        hitpoints--;
        //Playsound
        if (hitpoints < 0)
            isDead = true;
        for (int i = 0; i < 5;) 
        { 
            StartCoroutine(despawnedTimer());
            delete();
            i ++;
        }
    }
    void Die(bool value)
    {
        foreach (var r in ListEnnemies)
        {

            r.isKinematic =!value;

        }
            animator.enabled = !value;
    }
    void delete()
    {
        if (Timeout <= 0)
            Destroy(ennemies);
              
    }
    void FinChemin()
    {
        if (

        return FinChemin;


    }
    Vector3 Destination()
        

    {

   
        return new Vector3(14.13f, 1.97f, -46.26184f);
        // Update is called once per frame


    }




}
