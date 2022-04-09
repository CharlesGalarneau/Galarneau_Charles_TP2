using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    public void ReachEnnemies(Transform _target)
    {
        target = _target;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target = null)
        {
            Destroy(gameObject);
            return;
        }
    }
}
