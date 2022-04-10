using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemies : MonoBehaviour, IDamageable
{
    // une des choses les plus d�biles que j'ai jamais vu pour utiliser un nombre random
    System.Random random = new System.Random();
// valeur de r�f�rence pour les rigid bodies
protected Rigidbody[] rbEnnemi;
// valeur de r�f�rence pour l'animator
protected Animator animator;
//valeur pour la vie de l'ennemi
protected int pvEnnemi;
    public int PvEnnemi { get { return pvEnnemi; } set { pvEnnemi = value; } }
    // valeur mon�taire de l'ennemi
    protected int ennemiGold;
    public int EnnemiGold { get { return ennemiGold; } set { ennemiGold = value; } }
    // Le navMesh pour l'ennemi
    protected NavMeshAgent agent;
// Variable qui dit � l'ennemi est touch� Je vais peut-�tre devoir le changer d'endroit
protected bool degats = false;
    public bool Degats { get { return degats; } set { degats = value; } }
    // Valeur de destination pour les ennemies qui va �tre caller par le gamemanager
    protected Transform destination;
    public AudioClip audioClip;
    public AudioSource audioSource;
// Valeur qui va permettre de d�tecter l'ennemi
protected Collider colliderEnnemi;

// Va servir pour appeler le GameManager, n'est pas n�cessaire, mais c'est toujours plus rapide que de faire FindObjectofType<GameObject> � chaque fois
GameManager manager;


// Start is called before the first frame update
void Start()
{
    // va chercher les r�f�rences des rigid bodies de l'ennemi
    rbEnnemi = GetComponentsInChildren<Rigidbody>();
    // va chercher la r�f�rence de l'animator de l'ennemi
    animator = GetComponent<Animator>();
    // D�sactive le ragdoll
    ToggleRagdoll(false);
    // va chercher le collider de l'ennemi
    colliderEnnemi = GetComponent<Collider>();

    // Appel le GameManager
    manager = FindObjectOfType<GameManager>();
    Setup();
}

void Update()
{
        audioClip = GetComponent<AudioClip>();
        audioSource = GetComponent<AudioSource>();
        // V�rifie si la partie est termin� lorsque le joueur n'a plus de pv
        if (manager.IsGameOver == true)
            endOrDead();
        // V�rifie si l'ennemi est touch� et qu'il est viviant
        if (degats == true && agent.enabled == true)
        {
            TakeDamage(degats);
            degats = false;
            if (pvEnnemi == 0)
            {
                endOrDead();
            audioSource.PlayOneShot(audioClip);
            }
        }
    }


// m�thode pour la destination des ennemies qui est caller
public void SetTarget(Transform endDestination)
{

    // va chercher le navmesh de l'ennemi
    agent = GetComponent<NavMeshAgent>();

    destination = endDestination;

    agent.SetDestination(destination.position);
}

    public void TakeDamage(bool Degats)
    {
        // Va d�terminer si l'ennemi se prend des d�g�ts ou s'il meurt
        if (pvEnnemi > 0)
        {
            int rScream = random.Next(1, 5);
            // lorsque l'ennemi est touch�, il perd un pv
            pvEnnemi--;
            // Audio cri ennemi

        }
        else
            // Lorsque l'ennemie n'a plus de PV, il meurt ou lorsqu'il est arriv� � destination, il disparait 
            endOrDead();
    }
    // Ce qui ce produit lorsque l'ennemi meurt ou si le joueur est mort
    public void endOrDead()
    {
        // Active le Ragdoll si l'ennmei n'a plus de pv
        if (pvEnnemi <= 0)
        {
            // Active l'audio de mort

            // M�thode qui va servie pour le ragdoll de l'ennemi
            ToggleRagdoll(true);
            // donne l'or au joueur
            manager.Money += ennemiGold;
            // Juste au cas ou il y aurait un erreur et que la variable GameOver serait true
            if (manager.IsGameOver == true)
                manager.IsGameOver = false;
            // Variable dans le gamemanager qui augmente lorsque l'ennemi est mort
            manager.Killed += 1;
            // Active Particules pour mort
            Destroy(this.gameObject, 2f);

        }
        else
        {
            Destroy(this.gameObject);
            manager.IsGameOver = false;
        }
    }


    public void ToggleRagdoll(bool value)
{
    //Activer/desactiver les rigidbodies
    foreach (var r in rbEnnemi)
    {
        r.isKinematic = !value;
    }

    //Activer/desactiver l'Animator
    animator.enabled = !value;
    //active/desactive le navmesh
    agent.enabled = !value;

}
// M�thode virtual qui contient les valeurs des ennemis
protected virtual void Setup()
{
    // D�termine les pv de l'ennemi
    pvEnnemi = 4;
    // D�termine la valeur de l'ennemi
    ennemiGold = 50;

}
    // M�thode pour tester si lorsque l'ennemi meurt la round se termine

}


   

    

