using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : MonoBehaviour
{
    

    private Transform target;
    public float speed = 70f;
    private float radius = 20f;
    public ParticleSystem Frosty;

    //se trouve une target a visée
    public void ReachEnnemies(Transform _target)
    {
        target = _target;
    }


   
    void Update()
    {
        if (transform == null)
        {
            Destroy(gameObject);
            return;
        }
        //calcule la potion pour toucher l'ennemies
        Vector3 Deplacement = target.position - transform.position;
        float distence = speed * Time.deltaTime;
        if (Deplacement.magnitude <= distence)
        {
            HitTarget();
            return;
        }
        transform.Translate(Deplacement.normalized * distence, Space.World);
    }
    public void Coldburst()
    {   //joue l'animation et les dégats selon un range
        //Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Frosty.Play();
    }
    void HitTarget()
    {
        Coldburst();
        //détruit le projectile
        Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemies"))
        {

            Ennemies ennemies = other.GetComponent<Ennemies>();

            ennemies.Degats = true;
        }
    }
}
