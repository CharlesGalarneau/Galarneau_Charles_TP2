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
    public gamemanager gamemanager;
    public GameObject SelectedTurret;
    public BuildManager BuildManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //SelectedTurret = BuildManager.TurretBuilder;
        ButtonPlay.onClick.AddListener(ButtonPlayClicked);
        ButtonPause.onClick.AddListener(ButtonPauseClicked);
        ButtonTowerGun.onClick.AddListener(ButtonGunTurretClicked);
        ButtonCannonGun.onClick.AddListener(ButtonCannonTurretClicked);
        ButtonSlowerGun.onClick.AddListener(ButtonSlowerTurretClicked);
        ButtonPause.gameObject.SetActive(false);

        gamemanager = FindObjectOfType<gamemanager>();
       // BuildManager = FindObjectOfType<BuildManager>();

    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        txtTimer.text = timer.ToString();
        txtTimer.text = string.Format("{0:0}:{1:00}",
                   Mathf.Floor(timer / 60),   // Minutes
                   Mathf.Floor(timer) % 60);  // seconds
        txtLife.text = gamemanager.PlayerLife.ToString();
        Debug.Log(gamemanager.PlayerLife.ToString());
        txtennemieskilled.text = gamemanager.EnnemiesKilled.ToString();
        txtMoney.text = gamemanager.Money.ToString();
        txtvague.text = gamemanager.nbRounds.ToString();

    }
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
    void ButtonGunTurretClicked()
    {
        Debug.Log("SUCC");
        if (gamemanager.Money >=3)
        {

        }
    }
    void ButtonCannonTurretClicked()
    {
        Debug.Log("SUCC");
        if (gamemanager.Money >= 5)
        {

        }
        else
        {
            Debug.Log("SUCC");
        }
    }
    void ButtonSlowerTurretClicked()
    {
        Debug.Log("SUCC");
        if (gamemanager.Money >= 4)
        {

        }
    }
}
