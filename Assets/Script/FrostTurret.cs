using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostTurret : MonoBehaviour
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
    // appelles des différentes composantes besoins
    void Start()
    {
        gamemanager = GetComponent<GameManager>();
        ennemies = GetComponent<GameObject>();
        audioSource = GetComponent<AudioSource>();
        
        InvokeRepeating("ennemiesinReach", 1f, 0.5f);

    }
    protected void ennemiesinReach()
    {
        //détermine les ennemies les plus proches et fais une liste
        ListEnnemies = GameObject.FindGameObjectsWithTag(ennemiesTag);

        foreach (GameObject ennemies in ListEnnemies)
        {

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
    //trouve la position pour viser l'ennemies 
    void Update()
    {
        ennemiesinReach();
        if (Target == null)
        {
            return;
        }
        //Definie une potition vers ou tourn?es
        Vector3 DirectionRotation = Target.position - transform.position;
        //Definie un endroit ou regarder avec la rotation
        Quaternion DirectionRegarder = Quaternion.LookRotation(DirectionRotation);
        //Convertion des quarternion en euler angles 
        Vector3 rotation = Quaternion.Lerp(TurretRotation.rotation, DirectionRegarder, Time.deltaTime * MultiplicateurAngles).eulerAngles;
        // fais le d?placement.
        TurretRotation.rotation = Quaternion.Euler(-89.98f, rotation.y, 0f);
        if (FireCountdown <= 0)
        {
            Shooting();
            FireCountdown++;
        }
        FireCountdown -= Time.deltaTime;
    }
    //tire l'ennemies et joue les annimations et le son
    protected void Shooting()
    {
        

        GameObject projectile = Instantiate(Projectile, Barrel.position, Barrel.rotation);
        Frost bullet = projectile.GetComponent<Frost>();
       
        bullet.ReachEnnemies(Target);
        audioSource.PlayOneShot(Son, 0.5f);
        AnimationTir.Play();

    }

}
