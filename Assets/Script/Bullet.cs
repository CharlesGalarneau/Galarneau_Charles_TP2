using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    GameManager gamemanager;
    int Degat = 1;
    //se trouve une target a visée
    private void Start()
    {
        gamemanager = GetComponent<GameManager>();
    }
    public void ReachEnnemies(Transform _target)
    {
        target = _target;
    }


    //calcule la potion pour toucher l'ennemies
    void Update()
    {
        if (transform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 Deplacement = target.position - transform.position;
        float distence = speed * Time.deltaTime;
        if (Deplacement.magnitude <= distence)
        {
            HitTarget();
            return;
        }
        transform.Translate(Deplacement.normalized * distence, Space.World);
    }
    //joue l'animation et les dégats selon un range
    void HitTarget()
    {
        //gamemanager.TakeDamage(target,Degat);
        Destroy(gameObject);
    }
    //est capable d'infliger des dégats au ennemies seul qui fonction
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ennemies"))
        {
            
           Ennemies ennemies = other.GetComponent<Ennemies>();
           
            ennemies.Degats = true;
        }
    }
}
