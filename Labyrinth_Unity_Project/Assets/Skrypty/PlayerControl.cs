using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public Text healthText;
    public float invTime;
    private float invTimeMax;
    private bool invFrame;
    public GameObject effect;
    public bool isGrounded;
    public GameObject staminaObj;
    public int ammoPacks;
    public int MaxammoPacks;

    CharacterController characterController;
    public float MovementSpeed = 1;
    private float normalMovementSpeed;
    public float SlowMovementSpeed;
    public bool Slowed = false;
    private float runSpeed;
    public float runChange;

    public float runTime;
    public float runMaxTime;

    public float timeRecharge;
    public float maxTimeRecharge;

    public float Gravity = 2f;
    private float velocity = 0;
    public bool dashReady = true;
    public bool wall;

    public Animator LHandAnim;
    public Animator RHandAnim;

    public float timePerPunch;
    private float maxTimePerPunch;

    public float switchIdle;
    private float maxSwitchIdle;
    private int randomIdle;

    public int enemiesOnMe = 0;


    //private Rigidbody rb;
    //public Vector3 jump;
    //public float jumpForce = 2.0f;

    public GameObject[] hitSFX;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
        runMaxTime = runTime;
        invTimeMax = invTime;
        maxTimePerPunch = timePerPunch;
        maxSwitchIdle = switchIdle;
        normalMovementSpeed = MovementSpeed;
    }

    void Update()
    {
        //Slowed
        if(Slowed == true)
        {
            MovementSpeed = SlowMovementSpeed;
        }
        else
        {
            MovementSpeed = normalMovementSpeed;
        }

        //idle switch
        if(switchIdle <= 0)
        {
            randomIdle = Random.Range(0, 10);
            if (randomIdle == 0 || randomIdle == 1) RHandAnim.SetTrigger("Idle2");
            switchIdle = maxSwitchIdle;
        }
        else
        {
            switchIdle -= Time.deltaTime;
        }
        
        
        
        // player movement - forward, backward, left, right
        healthText.text = "Health: " + health;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal +transform.forward * vertical;
        characterController.Move(move * MovementSpeed * runSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && dashReady == true)
        {
            dashReady = false;
            characterController.Move(move * MovementSpeed * runChange * Time.deltaTime);
            staminaObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            runSpeed = 1.0f;
        }


        if(dashReady == false)
        {
            if(runTime <= 0)
            {
                runTime = runMaxTime;
                dashReady = true;
            }
            else
            {
                runTime -= Time.deltaTime;
                staminaObj.transform.localScale += new Vector3(0.3f* Time.deltaTime, 0.0f, 0.0f);
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        */

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }


        if(invFrame == true)
        {

            if(invTime > 0)
            {
                invTime -= Time.deltaTime;
            }else
            {
                invTime = invTimeMax;
                invFrame = false;
            }
        }



        //Punch
        if (Input.GetKeyDown(KeyCode.F))
        {
            RHandAnim.SetTrigger("Punch");
        }






    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Apteczka")
        {
            if(health<maxHealth)health += 30;
            Destroy(other.gameObject);
            GameObject effectObj = Instantiate(effect, transform.position, Quaternion.identity);
            effectObj.SetActive(true);
        }

        if(other.tag == "Ground")
        {
            isGrounded = true;
        }else
        {
            isGrounded = false;
        }


        if (invFrame == false)
        {
            if (other.tag == "Blade")
            {
                PlayHitSFX();

                health -= 20;
                invFrame = true;
            }
        }

        if(other.tag == "Ammo")
        {
            if(ammoPacks < MaxammoPacks)
            {
                ammoPacks++;
                Destroy(other.gameObject);
                GameObject effectObj = Instantiate(effect, transform.position, Quaternion.identity);
                effectObj.SetActive(true);
            }

        }

        if (other.tag == "Exit")
        {
            GameObject.Find("Controler").GetComponent<SceneControl>().wantsToExit = true;
        }
        else
        {
            GameObject.Find("Controler").GetComponent<SceneControl>().wantsToExit = false;

        }
        if(other.tag == "Fall")
        {
            GameObject.Find("Controler").GetComponent<SceneControl>().Reset = true;
        }


    }

    public void PlayHitSFX()
    {
        int hitLos = Random.Range(0, hitSFX.Length);
        GameObject hitSFXObj = Instantiate(hitSFX[hitLos], transform.position, Quaternion.identity);
        hitSFXObj.SetActive(true);
    }


}
























//Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//characterController.Move(move * Time.deltaTime * MovementSpeed);


/*

if (wall != true)
{
    if (Input.GetKey(KeyCode.W))
    {
        transform.Translate(Vector3.forward * (MovementSpeed) * Time.deltaTime);
    }


    if (Input.GetKey(KeyCode.S))
    {
        transform.Translate(Vector3.back * (MovementSpeed) * Time.deltaTime);
    }
}

*/
