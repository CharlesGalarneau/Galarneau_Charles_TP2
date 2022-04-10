using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Button ButtonPlay;
    public Button ButtonPause;
    public Button ButtonTowerGun;
    public Button ButtonCannonGun;
    public Button ButtonSlowerGun;

    public Text txtTimer;
    float timer;
    public Text txtvague;
    public Text txtMoney;
    public Text txtLife;
    public Text txtennemieskilled;
    public GameManager gamemanager;
    public GameObject SelectedTurret;
    public BuildManager BuildManager;
    
    //appelle les différentes fonctions des boutons et composants
    void Start()
    {
        //SelectedTurret = BuildManager.TurretBuilder;
        ButtonPlay.onClick.AddListener(ButtonPlayClicked);
        ButtonPause.onClick.AddListener(ButtonPauseClicked);
       
        ButtonPause.gameObject.SetActive(false);

        gamemanager = FindObjectOfType<GameManager>();
       // BuildManager = FindObjectOfType<BuildManager>();

    }
    
    //fait le temps et les différente valeur des composents de l'interface
    void Update()
    {
        timer += Time.deltaTime;
        txtTimer.text = timer.ToString();
        txtTimer.text = string.Format("{0:0}:{1:00}",
                   Mathf.Floor(timer / 60),   // Minutes
                   Mathf.Floor(timer) % 60);  // seconds
        txtLife.text = gamemanager.PlayerLife.ToString();
        Debug.Log(gamemanager.PlayerLife.ToString());
        txtennemieskilled.text = gamemanager.Killed.ToString();
        txtMoney.text = gamemanager.Money.ToString();
        txtvague.text = gamemanager.IVague.ToString();

    }
    //les fonctions pour les boutons play et stop
    void ButtonPlayClicked()
    {
        
        ButtonPlay.gameObject.SetActive(false);
        ButtonPause.gameObject.SetActive(true);
        
    }
    void ButtonPauseClicked()
    {
        ButtonPlay.gameObject.SetActive(true);
        ButtonPause.gameObject.SetActive(false);
    }
   
}
