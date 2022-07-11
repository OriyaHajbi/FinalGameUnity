using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigGunScript : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject SeeThroughCrossHair;
    public GameObject TouchCrossHair;
    public GameObject table;
    public Text gunText;
  
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
            // this is the table. so we want check if the hit object is the table
            if ((hit.transform.gameObject == this.gameObject || hit.transform.gameObject == table.gameObject) && hit.distance < 20)
            {
                // chnge crosshair
                if (!TouchCrossHair.active)
                {
                    SeeThroughCrossHair.SetActive(false);
                    TouchCrossHair.SetActive(true);
                }

            }
            else
            {
                // chnge crosshair
                if (TouchCrossHair.active)
                {
                    SeeThroughCrossHair.SetActive(true);
                    TouchCrossHair.SetActive(false);
                }
            }
            //check if we hit the table
            if (hit.transform.gameObject == table.gameObject)
            {
                if (!gunText.IsActive())
                {
                    gunText.gameObject.SetActive(true);
                }

                
                if (Input.GetKeyDown(KeyCode.G))
                {
                   PickBigGun.singelton.changeWeapons();
                }
                
            }
            else
            {
                if (gunText.IsActive())
                {
                    gunText.gameObject.SetActive(false);
                }
            }
        }
    }

}
