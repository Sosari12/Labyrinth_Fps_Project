using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    public int zdrowie;
    public bool wantsToExit = false;
    public bool hasKey = false;
    public bool wantsToReset = false;
    public Scene nextScene;
    public GameObject game1;
    public GameObject game2;
    public GameObject game3;
    public int ktoraGra = 0;
    public bool Reset = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zdrowie = GameObject.Find("Player").GetComponent<PlayerControl>().health;
        hasKey = GameObject.Find("Player").GetComponent<Keys>().hasKey1;

        if (zdrowie <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if(Reset == true)
        {
            Reset = false;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if(wantsToExit == true)
        {
            if(hasKey == true)
            {
                if(ktoraGra == 0)
                {
                    game1.SetActive(false);
                    game2.SetActive(true);
                    ktoraGra = 1;
                }else if(ktoraGra == 1)
                {
                    Scene scene = nextScene;
                    SceneManager.LoadScene("Menu");
                    game2.SetActive(false);
                    //game3.SetActive(true);

                    ktoraGra = 2;
                }else if(ktoraGra == 2)
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    //menu
                }
                //Scene scene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(scene.name);
            }
            else
            {
                // i need a key
            }
        }


        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }


}
