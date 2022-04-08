using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject ennemies;
    public List<GameObject> ListEnnemies;
    bool AllEnnnemiesDead = true;
    bool isGameOver;
    public GameObject ZombieSkeleteton;
    public GameObject NightShade;
    public GameObject Warrok;
    public int PlayerLife  = 3;
    public int EnnemiesKilled = 0;
    public int Money = 5;
    public int nbRounds = 1;
    private int CounterEnnemies = 0;
    private int Intervale = 2;
    // Start is called before the first frame update
    void Start()
    {
        ListEnnemies = new List<GameObject>();


       // if (!AllEnnnemiesDead)
        {
            for (int i = 0; i < nbRounds; i++)
            {
                StartCoroutine(SpawnerZombies());
            }
            
            for (int i = 0; i < nbRounds; i++)
            {
                StartCoroutine(SpawnerWarrok());
            }
            
            for (int i = 0; i < nbRounds; i++)
            {
                StartCoroutine(SpawnerNightshade());
                
            }
            AllEnnnemiesDead = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        

        if (PlayerLife >=0)
        {
            GameOver();
        }
    }
    IEnumerator SpawnerZombies()
    {
        Vector3 location = new Vector3(-11.25f, 0.04f, 55.01f);
        //Spawn des ennemies selon l'ennemies au spawn points
        
        GameObject EnnemiesSpawn = Instantiate(ZombieSkeleteton, location, Quaternion.identity).gameObject;
        ListEnnemies.Add(EnnemiesSpawn);
        yield return new WaitForSeconds(Intervale);
        yield return EnnemiesSpawn;

    }
    IEnumerator SpawnerWarrok()
    {
        Vector3 location = new Vector3(-11.25f, 0.04f, 55.01f);
        //Spawn des ennemies selon l'ennemies au spawn points

        GameObject EnnemiesSpawn = Instantiate(Warrok, location, Quaternion.identity).gameObject;
        ListEnnemies.Add(EnnemiesSpawn);
        yield return new WaitForSeconds(Intervale);
        yield return EnnemiesSpawn;

    }
    IEnumerator SpawnerNightshade()
    {
        Vector3 location = new Vector3(-11.25f, 0.04f, 55.01f);
        //Spawn des ennemies selon l'ennemies au spawn points

        GameObject EnnemiesSpawn = Instantiate(NightShade, location, Quaternion.identity).gameObject;
        ListEnnemies.Add(EnnemiesSpawn);
        yield return new WaitForSeconds(Intervale);
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
        ListEnnemies.Remove(ennemies);
        Destroy(ennemies);
        LooseLife();

    }


    public Vector3 Destination()

    {
        //Une Fonction pour Definir un vecteur de position
        return new Vector3(14.13f, 1.97f, -46.26184f);
    }

}

