using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Instance du gamemanager
    public static GameManager instance;
    // le point d'apparition des ennemis
    public Transform spawnpoint;
    // le point de la destination finale des ennemis
    public Transform endPoint;
    // Squelette
    public GameObject ennemiS;
    // Nightshade
    public GameObject ennemiN;
    // Warrok
    public GameObject ennemiW;
    // Pv du joueur
    int playerLife;
    public int PlayerLife { get { return playerLife; } set { playerLife = value; } }
    // Valeur qui permet de supprimer les prefab ennemis
    bool isGameOver ;
    public bool IsGameOver { get { return isGameOver; } set { isGameOver = value; } }
    // Gold du joueur
    int money;
    public int Money { get { return money; } set { money = value ; } }
    // Valeur utilisé pour déterminer si tous les ennemis sont morts
    int deadAll;
    //valeur de l'ennemi lorsqu'il est mort et va être vérifiée avec isDeadAll pour les comparer
    int killed;
    public int Killed { get { return killed ; } set { killed = value ; } }
    // Valeurs de référence pour faire apparaître les ennemis ---
    // Squelette
    int iEnnemiS;
    // NightShade
    int iEnnemiN;
    // Warrok
    int iEnnemiW;
    // Variable pour indiquer le nombre de la vague
    
    int iVague;
    public int IVague { get { return iVague; } set { iVague = value; } }
    //-----------------------------------------------------------

    // valeur fixe pour le temps entre les vaagues
    float spawnVagueInterval = 10f;
    // valeur fixe pour le délay entre chaque spawn d'ennemi
    float spawnDelay = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerLife = 6;
        // les golds de départs
        money = 10;

        // le je n'est pas terminé au commencement de la partie alors la variable est à false
        isGameOver = false;
        // Commence la coroutine pour faire apparaitre la vague
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        //  Va stopper la coroutine une fois les pv du joueur à 0
        if (PlayerLife == 0)
            theGameisOver();
        if (killed == deadAll && deadAll != 0)
            theGameisOver();
    }

    // Methode qui va faire apparaitre les ennemis
    IEnumerator Spawner()
    {
        //la valeiur de la vague
        iVague++;
        // le nombre de squelette par vague
        iEnnemiS = 1 + iVague;
        // le nombre de Nightshade par vague
        iEnnemiN = iVague - 1;
        // le nommbre de Warrok par vague--
        iEnnemiW = iVague - 2;
        if (iEnnemiW <= 0)
            iEnnemiW = 0;
        //---------------------------------
        // La quantité d'ennemi dans la variable qui détermine si tous les ennemis sont mort
        deadAll = iEnnemiS + iEnnemiN + iEnnemiW;
        //Variable qui sert à arrêter la boucle while
        int iW = 0;
        //le délais entre chaque vague
        yield return new WaitForSeconds(spawnVagueInterval);
        // Boucle qui va mettre les ennemis dans la vague
        while (iW < iEnnemiS + iEnnemiN + iEnnemiW)
        {
            // Spawn des ennemis (je vais devoir faire une boucle selon la vague)            
            for (int iSpawn = 0; iSpawn < iEnnemiS; iSpawn++, iW++)
            {
                EnnemiSpawn(ennemiS);
                yield return new WaitForSeconds(spawnDelay);
            }
            //----------------
            for (int iSpawn = 0; iSpawn < iEnnemiN; iSpawn++, iW++)
            {
                EnnemiSpawn(ennemiN);
                yield return new WaitForSeconds(spawnDelay);
            }
            //----------------
            for (int iSpawn = 0; iSpawn < iEnnemiW; iSpawn++, iW++)
            {
                EnnemiSpawn(ennemiW);
                yield return new WaitForSeconds(spawnDelay -= 0.5f);
            }
            
        }

    }
    // Méthode pour faire apparaître les types d'ennemis
    void EnnemiSpawn(GameObject ennemiType)
    {
        // fait apparaitre un préfab de l'ennemi désiré
        GameObject objEnnemi = Instantiate(ennemiType, spawnpoint.position, Quaternion.Euler(180f, 0f, 0f)).gameObject;
        // détermine la cible de l'ennemi
        Ennemies ennemies = objEnnemi.GetComponent<Ennemies>();
        ennemies.SetTarget(endPoint);
    }

    // va déterminer si la partie est terminée
    void theGameisOver()
    {
        StopAllCoroutines();
        // La partie est terminé
        if (PlayerLife == 0)
            isGameOver = true;
        else // ce déclenche seulement si le joueur est encore en vie lorsque la méthode est appelée pour
             // commencer une nouvelle vague
        {
            deadAll = 0;
            killed = 0;
            StartCoroutine(Spawner());
        }
    }
    //public void TakeDamage(Ennemies ennemies)
    //{
    //    int pvEnnemi = ennemies.PvEnnemi;
    //    // Va déterminer si l'ennemi se prend des dégâts ou s'il meurt
    //    if (pvEnnemi > 0)
    //    {
    //        //int rScream = random.Next(1, 5);
    //        // lorsque l'ennemi est touché, il perd un pv
    //        pvEnnemi--;
    //        // Audio cri ennemi

    //    }
    //    else
    //        // Lorsque l'ennemie n'a plus de PV, il meurt ou lorsqu'il est arrivé à destination, il disparait 
    //        endOrDead(ennemies);
    //}
    //// Ce qui ce produit lorsque l'ennemi meurt ou si le joueur est mort
    //public void endOrDead(Ennemies ennemies)
    //{
    //    int pvEnnemi = ennemies.PvEnnemi;
    //    // Active le Ragdoll si l'ennmei n'a plus de pv
    //    if (pvEnnemi <= 0)
    //    {
    //        // Active l'audio de mort

    //        // Méthode qui va servie pour le ragdoll de l'ennemi
    //        ennemies.ToggleRagdoll(true);
    //        // donne l'or au joueur
    //       Money += ennemies.EnnemiGold;
    //        // Juste au cas ou il y aurait un erreur et que la variable GameOver serait true
    //        if (IsGameOver == true)
    //            IsGameOver = false;
    //        // Variable dans le gamemanager qui augmente lorsque l'ennemi est mort
    //        Killed += 1;
    //        // Active Particules pour mort
    //        Destroy(this.gameObject, 2f);

    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
           
    //        IsGameOver = false;
    //    }
        

    

}
