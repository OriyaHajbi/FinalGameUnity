using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 30;
    private float angularSpeed = 50;
    private float rotationAboutY = 0;
    private float rotationAboutX = 0;
    public GameObject aCamera; // [public] must be connected to external object
    private AudioSource steps;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        steps = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0;
        float dy = -1;
        float dz = 0;

        //set the rotation angles
        rotationAboutY += Input.GetAxis("Mouse X")*angularSpeed*Time.deltaTime;
        Vector3 rotation = new Vector3(0, rotationAboutY, 0);
        transform.localEulerAngles = rotation; // sets the rotation angles of THIS
        
        //set the rotation angles X axis
        rotationAboutX -= Input.GetAxis("Mouse Y")* angularSpeed * Time.deltaTime;
        Vector3 rotationX = new Vector3(rotationAboutX, 0, 0);
        //if (Mathf.Abs(rotationAboutX)<60)
            aCamera.transform.localEulerAngles = rotationX;

        dx = Input.GetAxis("Horizontal"); //can be -1 , 0, +1 // left , none , right
        dx *= speed * Time.deltaTime;//Time.deltaTime is the time lapse between frames
        dz = Input.GetAxis("Vertical"); // can be -1, 0 , +1 // forward , none , backward
        dz *= speed * Time.deltaTime;//Time.deltaTime is the time lapse between frames

        //add motion use character controller
        Vector3 motion = new Vector3(dx, dy, dz);//dx,dy,dz are local coordinates
        motion = transform.TransformDirection(motion);//transform LOCAL to GLOBAL
        this.controller.Move(motion);//the vector motion must be in global coordinates
        if (Mathf.Abs(dz) > 0.01 || Mathf.Abs(dx) > 0.01)
        {
            if(!steps.isPlaying)
                steps.Play();
        }
    }
}
