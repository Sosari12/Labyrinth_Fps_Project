using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManage : MonoBehaviour
{
    private float zdrowie;
    private int maxZdrowie;
    public GameObject zdrowieObj;
    public Material matRed;
    public Material matGreen;
    public Material matYellow;
    public float procent;
    public float staminaProcent;
    private int ticksDash;
    private bool isDashReady;


    // Start is called before the first frame update
    void Start()
    {
        maxZdrowie = GameObject.Find("Player").GetComponent<PlayerControl>().maxHealth;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
    zdrowie = GameObject.Find("Player").GetComponent<PlayerControl>().health;
    isDashReady = GameObject.Find("Player").GetComponent<PlayerControl>().dashReady;
        procent = zdrowie / 100;
        zdrowieObj.transform.localScale = new Vector3(procent, 0.1f, 0.1f);
        



        if (zdrowie >= 80)
        {
            zdrowieObj.GetComponent<Renderer>().material = matGreen;
        }else if(zdrowie < 80 && zdrowie >= 40)
        {
            zdrowieObj.GetComponent<Renderer>().material = matYellow;
        }
        else if(zdrowie < 40)
        {
            zdrowieObj.GetComponent<Renderer>().material = matRed;
        }
    }
}
