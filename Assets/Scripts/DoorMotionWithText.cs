using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorMotionWithText : MonoBehaviour
{
    private Animator animator;
    private AudioSource sound;
    public Text KeyText;
    public GameObject Key;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        KeyText.gameObject.SetActive(true);
        if (!Key.active)
        {
            KeyText.gameObject.SetActive(false);
            animator.SetBool("DoorIsOpen", true);
            sound.PlayDelayed(0.8f);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpen", false);
        sound.PlayDelayed(0.8f);
        KeyText.gameObject.SetActive(false);
    }
}
