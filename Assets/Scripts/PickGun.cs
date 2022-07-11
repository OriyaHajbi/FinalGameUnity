using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public static PickGun singelton;
    public GameObject gunInDrawer;
    public GameObject gunInHand;
    // Start is called before the first frame update
    void Start()
    {
        singelton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
           

    }
    private void OnMouseEnter()
    {
        gunInDrawer.SetActive(false);
        gunInHand.SetActive(true);
    }

    public void changeWeapons()
    {
        gunInDrawer.SetActive(false);
        gunInHand.SetActive(true);
    }
}
