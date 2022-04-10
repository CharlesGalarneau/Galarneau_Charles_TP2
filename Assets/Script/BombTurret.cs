using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret: MonoBehaviour
{
    private GameObject ennemies;
    GameManager gamemanager;
    Transform Target;
    float range = 15f;
    float MultiplicateurAngles = 10f;
    float DistanceEnnemies;
    GameObject[] ListEnnemies;
    private string ennemiesTag = "Ennemies";
    public Transform TurretRotation;
    public GameObject Projectile;
    protected float FireCountdown;
    protected int GoldCost;
    public Transform Barrel;
    public ParticleSystem AnimationTir;
    public AudioClip Son;
    AudioSource audioSource;
    public LineRenderer bulletTrail;

    void Start()
    {
        //appel des différents composant que l'on a besoin
        gamemanager = GetComponent<GameManager>();
        ennemies = GetComponent<GameObject>();
        audioSource = GetComponent<AudioSource>();
        //fait la fonction plusieur pour viser l'ennemies evite de le faire 60 fois dans un update
        InvokeRepeating("ennemiesinReach", 1f, 0.5f);

    }
    protected void ennemiesinReach()
    {
        //crée une liste d'ennemies avec leur tag
        ListEnnemies = GameObject.FindGameObjectsWithTag(ennemiesTag);
        //fait la vérification pour chaque ennemies
        foreach (GameObject ennemies in ListEnnemies)
        {
            //determine la distance entre lui et l'ennemies
            DistanceEnnemies = Vector3.Distance(transform.position, ennemies.transform.position);
            //}
            if (DistanceEnnemies <= range)
            {
                Target = ennemies.transform;

            }
            else
            {
                Target = null;
            }
        }
    }
    void Update()
    {
        ennemiesinReach();
        if (Target == null)
        {
            return;
        }
        //Definie une potition vers ou tournées
        Vector3 DirectionRotation = Target.position - transform.position;
        //Definie un endroit ou regarder avec la rotation
        Quaternion DirectionRegarder = Quaternion.LookRotation(DirectionRotation);
        //Convertion des quarternion en euler angles 
        Vector3 rotation = Quaternion.Lerp(TurretRotation.rotation, DirectionRegarder, Time.deltaTime * MultiplicateurAngles).eulerAngles;
        // fais le déplacement.
        TurretRotation.rotation = Quaternion.Euler(-89.98f, rotation.y, 0f);
        if (FireCountdown <= 0)
        {
            Shooting();
            FireCountdown++;
        }
        FireCountdown -= Time.deltaTime;
    }

    protected void Shooting()
    {

        //crée le projectille et appelles les différents sons et animations
        GameObject projectile = Instantiate(Projectile, Barrel.position, Barrel.rotation);
        Bomb bullet = projectile.GetComponent<Bomb>();

        bullet.ReachEnnemies(Target);
        audioSource.PlayOneShot(Son, 0.5f);
        AnimationTir.Play();

    }

}
