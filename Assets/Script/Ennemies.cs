using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    int hitpoints;
    float Timeout = 5f;
    bool isDead;
     public GameObject ennemies;
    protected Rigidbody[] ListEnnemies;
    protected Animator animator;
    // Start is called before the first frame update
    void Start()
    {

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
        if (hitpoints < 0)
            isDead = true;
        StartCoroutine(despawnedTimer());
            delete();
    }
    void Die(bool value)
    {
        foreach (var r in ListEnnemies)
        {
            r.isKinematic =!value;
        }
    }
    void delete()
    {
        if (Timeout <= 0)
            Destroy(ennemies);
              
    }
        

}
