using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairChange : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject SeeThroughCrossHair;
    public GameObject TouchCrossHair;
    public GameObject Drawer4;
    public Text DrawerText;
    private bool IsDrawerClose = true;
    private Animator animator;
    private AudioSource drwerSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        drwerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
         if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
            // this is the chest. so we want check if the hit object is the chest
            if ((hit.transform.gameObject == this.gameObject || hit.transform.gameObject == Drawer4.gameObject)  && hit.distance < 20)
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
            //check if we hit the drawer
            if ( hit.transform.gameObject == Drawer4.gameObject)
            {
                if (!DrawerText.IsActive())
                {
                    DrawerText.gameObject.SetActive(true);
                }
                if (!IsDrawerClose)
                {
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        PickGun.singelton.changeWeapons();
                    }
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(DrawerOpenClose());
                    
                }
            }
            else
            {
                if (DrawerText.IsActive())
                {
                    DrawerText.gameObject.SetActive(false);
                }
            }
        }
    }

    // change text only after animation played
    IEnumerator DrawerOpenClose()
    {
        
        animator.SetBool("Open", IsDrawerClose);
        IsDrawerClose = !IsDrawerClose;
        //DrawerText.gameObject.SetActive(IsDrawerClose);
        drwerSound.PlayDelayed(0.2f);


        yield return new WaitForSeconds(2);

        if (IsDrawerClose)
            DrawerText.text = "Press [E] to Open";
        else
            DrawerText.text = "Press [E] to Close";

        
    }
}
