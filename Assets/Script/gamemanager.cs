using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject ennemies;
    //protected GameObject[] ListEnnemies;
    bool AllEnnnemiesDead = false;
    bool isGameOver;
    public float PlayerLife  = 3;
    float nbRounds =1;
    // Start is called before the first frame update
    void Start()
    {
        //ennemies = GetComponent<Ennemies>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!AllEnnnemiesDead)
        {
            for (int i = 0; i < nbRounds; i++)
            {
                StartCoroutine(Spawner());
            }
            AllEnnnemiesDead = true;
        }

        if (PlayerLife >=0)
        {
            GameOver();
        }
    }
    IEnumerator Spawner()
    {
        Vector3 location = new Vector3(-11.25f, 0.04f, 55.01f);
        //Spawn des ennemies selon l'ennemies au spawn points
        GameObject EnnemiesSpawn = Instantiate(ennemies, location, Quaternion.identity).gameObject;
        yield return EnnemiesSpawn;

    }
    public void GameOver()
    {
        isGameOver = true;
        
        
    }
    public void LooseLife()
    {
        PlayerLife--;

        
    }
    public void delete(GameObject ennemies)
    {

        Destroy(ennemies);

    }
    public void FinChemin(GameObject ennemies)
    {
        delete(ennemies);
        LooseLife();

    }


    public Vector3 Destination()

    {
        //Une Fonction pour Definir un vecteur de position
        return new Vector3(14.13f, 1.97f, -46.26184f);
    }
}

