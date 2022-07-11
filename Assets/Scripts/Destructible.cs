using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public static Destructible singelton;

    public GameObject destroyedVersion;

    void Start()
    {
        singelton = this;
    }

    public void destroyIt()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
