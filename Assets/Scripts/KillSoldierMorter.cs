using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSoldierMorter : MonoBehaviour
{
    public static KillSoldierMorter singelton;

    //public GameObject notShootingVersion;

    void Start()
    {
        singelton = this;
    }

    public void replaceIt()
    {
        //Instantiate(notShootingVersion, transform.position, transform.rotation);
        if (gameObject)
            Destroy(gameObject);
    }
}
