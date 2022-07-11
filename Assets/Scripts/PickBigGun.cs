using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBigGun : MonoBehaviour
{
    public static PickBigGun singelton;
    public GameObject gunInTable;
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
        gunInTable.SetActive(false);
        gunInHand.SetActive(true);
    }

    public void changeWeapons()
    {
        gunInTable.SetActive(false);
        gunInHand.SetActive(true);
    }
}
