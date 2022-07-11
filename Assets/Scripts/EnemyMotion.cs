using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private LineRenderer line;
    public GameObject player;

    public GameObject gun;
    public ParticleSystem gunMuzzleFlash;


    public int enemyDamage = 10;

    public GameObject enemy;
    private AudioSource audio;

    private float nextTimeToFire = 3f;

    private bool modeAttack;

    







    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
        audio = GetComponent<AudioSource>();
        agent.enabled = false;
        modeAttack = false;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            agent.enabled = true;
            modeAttack = true;
            animator.SetInteger("status", 4); // start walking
        }
        //set the new path for motion and start the motion
        if (agent.enabled)
        {
            agent.SetDestination(player.transform.position); // Here A* is used to get path to target
            //showing the path
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
        }

        RaycastHit hit;
        //check what object is our focus
        if (Physics.Raycast(enemy.transform.position, player.transform.forward, out hit))
        {
            var currentEnemyDist = Vector3.Distance(player.transform.position, enemy.transform.position);

            //Debug.Log("Distance to " + hit.transform.gameObject + " is " + hit.distance);
            //Debug.Log("NEW Distance to player" + currentEnemyDist);

            if (currentEnemyDist < 100)
            {
                animator.SetInteger("status", 1);
                gun.gameObject.SetActive(true);

                nextTimeToFire -= Time.deltaTime;
                if (nextTimeToFire < 0 && !Shooting.isEnemyDead && modeAttack)
                {
                    enemyAttack();
                }
                
                
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetInteger("status", 1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("status", 0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetInteger("status", 2);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetInteger("status", 3);
            agent.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetInteger("status", 5);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.gameObject.name) // change the position of the target
        {
            float x, y, z;
            x = Random.Range(0 , 800);
            z = Random.Range(0, 800);
            // new position must be accessible so y should be on the surface of terrain
            y = Terrain.activeTerrain.SampleHeight(new Vector3(x,1,z));
            //target.transform.position = new Vector3(x, y, z);
        }
    }

    void enemyAttack()
    {
        nextTimeToFire = 3f;
        PlayerHealth.singelton.TakeDamage(10);
        gunMuzzleFlash.Play();
        audio.Play();
        
        
    }
}
