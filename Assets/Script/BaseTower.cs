using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public Color HoverColor;
    private Renderer rend;
    private Color BaseColor;
    private GameObject turret;
    BuildManager buildManager;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
        BaseColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    //quand on clique sur une tour elle mais la tour qu'on a choisi
    private void OnMouseDown()
    {
       if (Input.GetButtonDown("Fire1"))
        {//si on a pas choisi de tourelle rien ne se passe
            if (buildManager.GetTurretToBuild() == null)
            {
                
                return;
            }
            //enlève l'ancienne tourelle si on clique sur l'encienne
            if (turret !=null)
            {
                Destroy(turret);
            return;
            }
            //crée la tourelle choisis
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        }
       


    }

    void OnMouseEnter()
    {//losque glise notre souris sur la base elle change de couleur
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = HoverColor;
    }

    //retoure a sa couleur normale quand on sort
    void OnMouseExit()
    {
        rend.material.color = BaseColor;
    }
}
