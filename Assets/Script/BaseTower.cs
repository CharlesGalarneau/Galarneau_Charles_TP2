using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public Color HoverColor;
    private Renderer rend;
    private Color BaseColor;
    private GameObject turret;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
        BaseColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (turret !=null)
        {
            Debug.Log("there is alredy a tower there MORON");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = HoverColor;
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        rend.material.color = BaseColor;
    }
}
