using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject ennemies;
    gamemanager gamemanager;
    Transform Target;
    float range = 15f;
    float DistanceEnnemies;
    GameObject[] ListEnnemies;
    private string ennemiesTag = "Ennemies";
    public Transform TurretRotation;
    public GameObject Projectile;
    private float FireCountdown;
    public Transform Barrel;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GetComponent<gamemanager>();
         ennemies = GetComponent<GameObject>();


         InvokeRepeating("ennemiesinReach", 1f, 0.5f);

    }
    void ennemiesinReach()
    {
       
        ListEnnemies = GameObject.FindGameObjectsWithTag(ennemiesTag);

        foreach (GameObject ennemies in ListEnnemies)
        {
           
            DistanceEnnemies = Vector3.Distance(transform.position, ennemies.transform.position);
            //}
            if (DistanceEnnemies <= range)
            {
                Target = ennemies.transform;
                Debug.Log("FUCKS");
            }
            else
            {
                Target = null;
            }
        }
    }
    // Update is called once per frame
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
        Vector3 rotation = Quaternion.Lerp(TurretRotation.rotation,DirectionRegarder, Time.deltaTime * range).eulerAngles;
        // fais le d?placement.
        TurretRotation.rotation = Quaternion.Euler(-89.98f, rotation.y, 0f);
        if (FireCountdown <= 0)
        {
            Shooting();
                FireCountdown +=1f;
        }
        FireCountdown -= Time.deltaTime;
    }
    public void Shooting()
    {
        GameObject projectile = Instantiate(Projectile, Barrel.position, Barrel.rotation);
    }
    
  
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
