using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; // for text


public class Shooting : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject aTarget;
    GameObject enemy;
    GameObject enemy1;
    public GameObject bigGunInHand;
    public GameObject smallGunInHand;
    public GameObject smallGunMuzzle;
    public GameObject bigGunMuzzle;
    private Animator animator;
    private Animator animator1;
    private AudioSource smallShootingSound;
    private AudioSource bigShootingSound;
    private LineRenderer smallGunLine;
    private LineRenderer bigGunLine;
    public ParticleSystem smallMuzzleFlash;
    public ParticleSystem bigMuzzleFlash;

    public static bool isEnemyDead;
    public static bool isEnemyDead1;

    public static int enemyKilled = 0;
    public Text enemyKilledText;

    public float damage = 10f;
    public float impactForce = 30f;

    public GameObject box;
    public GameObject soldiersWithMorter;

    public Text goFindKeyText;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        enemy1 = GameObject.FindWithTag("Enemy1");
        animator = enemy.GetComponent<Animator>();
        animator1 = enemy1.GetComponent<Animator>();
        smallShootingSound = smallGunInHand.GetComponent<AudioSource>();
        bigShootingSound = bigGunInHand.GetComponent<AudioSource>();
        smallGunLine = smallGunInHand.GetComponent<LineRenderer>();
        bigGunLine = bigGunInHand.GetComponent<LineRenderer>();
        isEnemyDead = false;
        isEnemyDead1 = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (smallGunInHand.active || bigGunInHand.active)
        {
            RaycastHit hit;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (smallGunInHand.active)
                {
                    smallShootingSound.Play();
                    smallMuzzleFlash.Play();
                }

                if (bigGunInHand.active)
                {
                    bigMuzzleFlash.Play();
                    bigShootingSound.Play();

                }
                    
                if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
                {
                    aTarget.transform.position = hit.point;
                    //draw shotting
                    if (smallGunInHand.active)
                        StartCoroutine(DrawFlash(smallGunMuzzle , smallGunLine));
                    else
                    {
                        StartCoroutine(DrawFlash(bigGunMuzzle , bigGunLine));
                    }

                    if (!isEnemyDead && (hit.transform.gameObject == enemy.transform.gameObject))
                    {
                        isEnemyDead = true;
                        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                        //stop enemy motion
                        agent.enabled = false;
                        enemyKilled++;
                        enemyKilledText.text = "Enemy Killed: " + enemyKilled;
                        animator.SetInteger("status", 3);
                    }
                    if (!isEnemyDead1 && (hit.transform.gameObject == enemy1.transform.gameObject ))
                    {
                        isEnemyDead1 = true;
                        NavMeshAgent agent = enemy1.GetComponent<NavMeshAgent>();
                        //stop enemy motion
                        agent.enabled = false;
                        enemyKilled++;
                        enemyKilledText.text = "Enemy Killed: " + enemyKilled;
                        animator1.SetInteger("status", 3);
                    }

                    if (hit.transform.gameObject == box.transform.gameObject)
                    {
                        Destructible.singelton.destroyIt();
                    }

                    if (hit.transform.gameObject == soldiersWithMorter.transform.gameObject)
                    {
                        KillSoldierMorter.singelton.replaceIt();
                    }

                  

                    

                }
            }
        }

        if (enemyKilled == 2)
        {
            goFindKeyText.gameObject.SetActive(true);
        }
        
    }
    IEnumerator DrawFlash(GameObject gunMuzzle , LineRenderer line)
    {
        // draw shooting
        line.SetPosition(0, gunMuzzle.transform.position);
        line.SetPosition(1, aTarget.transform.position);

        // delay
        yield return new WaitForSeconds(0.1f);

        //erase
        line.SetPosition(0, gunMuzzle.transform.position);
        line.SetPosition(1, gunMuzzle.transform.position);

    }
}
