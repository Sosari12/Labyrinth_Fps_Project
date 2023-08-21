using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuCamera : MonoBehaviour
{
    public Animator animCam;
    public Animator animLight;

    public float timeToIdle;
    private float timeToIdleMax;

    public bool attention = false;

    public int ktory = 0;



    // Start is called before the first frame update
    void Start()
    {

        timeToIdleMax = timeToIdle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            attention = true;
            timeToIdle = timeToIdleMax;
            if (ktory == 0)
            {
                ktory = 1;
            }
            else if(ktory == 2)
            {
                ktory = 1;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            attention = true;
            timeToIdle = timeToIdleMax;
            if (ktory == 0)
            {
                ktory = 1;
            }
            else if (ktory == 1)
            {
                ktory = 2;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            attention = true;
            timeToIdle = timeToIdleMax;
            if (ktory == 0)
            {
                ktory = 1;
            }
            else if (ktory == 1)
            {
                SceneManager.LoadScene("Labirynt");
            }
            else if (ktory == 2)
            {
                Application.Quit();
            }
        }

        if(ktory == 0)
        {
            animLight.SetInteger("Ktory", 0);
            animCam.SetInteger("Ktory", 0);
        }
        else if(ktory == 1)
        {
            animLight.SetInteger("Ktory", 1);
            animCam.SetInteger("Ktory", 1);

        }
        else if(ktory == 2)
        {
            animLight.SetInteger("Ktory", 2);
            animCam.SetInteger("Ktory", 2);
        }


        if (attention == false)
        {
            animCam.SetBool("Zoom", false);
        }
        else
        {
            animCam.SetBool("Zoom", true);
            if (timeToIdle <= 0)
            {
                ktory = 0;
                attention = false;
                timeToIdle = timeToIdleMax;
            }
            else
            {
                timeToIdle -= Time.deltaTime;
            }
        }

    }
}
