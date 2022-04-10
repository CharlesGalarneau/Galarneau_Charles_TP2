using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
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
    GameObject TargetCollider;

    // appelles des différentes composantes besoins
    void Start()
    {
        gamemanager = GetComponent<GameManager>();
         ennemies = GetComponent<GameObject>();
        audioSource = GetComponent<AudioSource>();
        Setup();
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
    // Update is called once per frame
    protected virtual void Setup()
    {
        //change les variable selon la tour
        FireCountdown = 3;
        GoldCost = 1;
    }
    //trouve la position pour viser l'ennemies 
    void Update()
    {
        ennemiesinReach();
        if (Target == null) 
        {
            return;
        }
        if (TurretRotation == null)
        {
            return;
        }
        //Definie une potition vers ou tourn?es
        Vector3 DirectionRotation = Target.position - transform.position;
        //Definie un endroit ou regarder avec la rotation
        Quaternion DirectionRegarder = Quaternion.LookRotation(DirectionRotation);
        //Convertion des quarternion en euler angles 
        Vector3 rotation = Quaternion.Lerp(TurretRotation.rotation,DirectionRegarder, Time.deltaTime * MultiplicateurAngles).eulerAngles;
        // fais le d?placement.
        TurretRotation.rotation = Quaternion.Euler(-89.98f, rotation.y, 0f);
        if (FireCountdown <= 0)
        {
            Shooting();
                FireCountdown ++ ;
        }
        FireCountdown -= Time.deltaTime;
    }
    protected  void Shooting()
    {
        //tire l'ennemies et joue les annimations et le son

        GameObject projectile = Instantiate(Projectile, Barrel.position, Barrel.rotation);
        Bullet bullet = projectile.GetComponent<Bullet>();
        bullet.ReachEnnemies(Target);
        audioSource.PlayOneShot(Son, 0.5f);
        AnimationTir.Play();

    }
    
  
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
