using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlideMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource sound;
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
        animator.SetBool("DoorMovingIsOpen", true);
        sound.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorMovingIsOpen", false);
        sound.Play();
    }
}
