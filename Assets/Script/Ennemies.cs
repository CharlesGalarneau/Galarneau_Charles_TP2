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
    protected gamemanager gamemanager;
    protected Animator animator;
    Vector3 Destionation;
    protected Collider colliderEnnemies;
    // Start is called before the first frame update
    void Start()
    {
        
       
        ListEnnemies = GetComponentsInChildren<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        colliderEnnemies = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        gamemanager = FindObjectOfType<gamemanager>();
        Die(false);
        Destionation = gamemanager.Destination();
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
           
            i ++;
        }
        if (Timeout <= 0)
        {
            gamemanager.delete(ennemies);
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


    void OnTriggerEnter(Collider other)
    {
        
            // Si l'un des ennemies touche le chateau le joueur pert une vie
            if (other.CompareTag("FinChemin"))
            {
            Debug.Log("FIUC");
                gamemanager.FinChemin(ennemies);
            }
    }

    
}
