using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChestMotion : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject SeeThroughCrossHair;
    public GameObject TouchCrossHair;
    public GameObject Chest;
    public GameObject Key;
    public Text ChestText;
    public Text TakeKeyText;
    private bool chestIsOpen = true;
    public static bool keyTaked = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
            // this is the chest. so we want check if the hit object is the chest
            if ((hit.transform.gameObject == this.gameObject || hit.transform.gameObject == Chest.gameObject) && hit.distance < 1)
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
            //check if we hit the chest
            if (hit.transform.gameObject == Chest.gameObject)
            {
                if (chestIsOpen)
                {
                    ChestText.gameObject.SetActive(true);
                }
                
                

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(DrawerOpenClose());
                    chestIsOpen = false;
                    ChestText.gameObject.SetActive(false);
                }
                if(!chestIsOpen && !keyTaked) 
                {
                    TakeKeyText.gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.K))
                    {
                        TakeKeyText.gameObject.SetActive(false);
                        Key.SetActive(false);
                        keyTaked = true;
                    }
                }
            }
            else
            {
                if (ChestText.IsActive())
                {
                    ChestText.gameObject.SetActive(false);
                }
                TakeKeyText.gameObject.SetActive(false);

            }
        }
    }

    // change text only after animation played
    IEnumerator DrawerOpenClose()
    {
        animator.SetBool("chestIsOpen", true);
        //IsChestClose = !IsChestClose;

        yield return new WaitForSeconds(1);

        
        //if (IsChestClose)
        //   ChestText.text = "Press [Space] to Open";

    }

}
