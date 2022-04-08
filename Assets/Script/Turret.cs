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
    private GameObject[] ListeEnnemis;
    public Transform TurretRotation;
    // Start is called before the first frame update
    void Start()
    {
        
        ennemies = GetComponent<GameObject>();
        InvokeRepeating("ennemiesinReach", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) 
        {
            return;
        }
        //Definie une potition vers ou tournées
        Vector3 DirectionRotation = Target.position - transform.position;
        //Definie un endroit ou regarder avec la rotation
        Quaternion DirectionRegarder = Quaternion.LookRotation(DirectionRotation);
        //Convertion des quarternion en euler angles 
        Vector3 rotation = Quaternion.Lerp(TurretRotation.rotation,DirectionRegarder, Time.deltaTime * range).eulerAngles;
        // fais le déplacement.
        TurretRotation.rotation = Quaternion.Euler(0f,rotation.y,0f);
    }
    
    void ennemiesinReach()
    {
       
       
        foreach (GameObject ennemies in ListeEnnemis)
        {

            DistanceEnnemies = Vector3.Distance(transform.position, ennemies.transform.position);
        }
        if (ennemies !=null && DistanceEnnemies <= range )
        {
            Target = ennemies.transform;
        }
        else
        {
            Target = null;
        }    
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
