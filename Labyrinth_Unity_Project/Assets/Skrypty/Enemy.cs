using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navComponent;
    public Animator enemyAnim;
    public bool attack = false;
    public GameObject attackChecker;
    public float attackTime;
    private float attackTimeMax;
    private bool afterAttack;
    public bool seeEnemy = false;

    public GameObject[] placesToGo;

    private int losValue;
    public GameObject targetAnchor;
    private bool reachedAnchor = true;
    public float patrolTime;
    private float patrolTimeMax;
    private GameObject anchorObj;

    private bool dodano = false;
    public SoundTrackManager ostManager;
    public GameObject redLight;
    public int Damage;

    // private bool hitLanded = false;

    // Start is called before the first frame update
    void Start()
    {
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        attackTimeMax = attackTime;
        patrolTimeMax = patrolTime;
    }

    // Update is called once per frame
    void Update()
    {


        //hitLanded = attackColider.GetComponent<AttackColider>().hitPlayer;
        if (seeEnemy == false)
        {
            if (reachedAnchor == true)
            {
                losValue = Random.Range(0, 8);
                if (placesToGo[losValue].GetComponent<WhereToGoDetector>().touchesGround == true && placesToGo[losValue].GetComponent<WhereToGoDetector>().touchesWall == false)
                {
                    anchorObj = Instantiate(targetAnchor, placesToGo[losValue].transform.position, Quaternion.identity);
                    anchorObj.SetActive(true);
                    target = anchorObj.transform;
                    reachedAnchor = false;
                }
            }
            else
            {
                if (patrolTime <= 0)
                {
                    reachedAnchor = true;
                    target = this.gameObject.transform;
                    Destroy(anchorObj);
                    patrolTime = patrolTimeMax;
                }
                else
                {
                    patrolTime -= Time.deltaTime;
                }

            }


        }
        else
        {
            ///
            if(dodano == false)
            {
                ostManager.enemiesOnPlayer++;
                dodano = true;
                redLight.SetActive(true);
            }
        }


        attack = attackChecker.GetComponent<DetectionAttack>().nearPlayer;
        float dist = Vector3.Distance(target.position, transform.position);

        if (attack == false)
        {
            enemyAnim.SetBool("attack1", false);
            if(afterAttack == false)navComponent.SetDestination(target.position);
            
        }else
        {
            enemyAnim.SetBool("attack1", true);
            //if(hitLanded == false)enemyAnim.SetBool("attack1", true);
            afterAttack = true;
        }



        if(afterAttack == true)
        {
            if(attackTime > 0)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                attackTime = attackTimeMax;
                afterAttack = false;
            }
        }

    }



}
