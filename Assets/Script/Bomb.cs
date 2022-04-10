using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    private float radius = 20f;
    public ParticleSystem Kaboom;

    //se trouve une target a visée
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
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Kaboom.Play();
    }
    void HitTarget()
    {
        //delete le projectile
        Explode();
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
