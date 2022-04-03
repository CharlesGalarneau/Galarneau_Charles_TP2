using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Ennemies;
    bool RoundOver;
    bool isGameOver;
    float PlayerLife;
    float nbRounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundOver!)
        {
            for (int i = 0; i < nbRounds; i++)
            {

            }
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
        GameObject EnnemiesSpawn = Instantiate(Ennemies, location, Quaternion.identity).gameObject;
        yield return EnnemiesSpawn;

    }
    public void GameOver()
    {
        isGameOver = true;
        
        
    }
}
