using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public GameObject myBody;
    public bool violence = false;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(violence == true)
        {
            myBody.GetComponent<Enemy>().seeEnemy = true;
            myBody.GetComponent<Enemy>().target = Player.transform;
        }
    }


    private void OnTriggerEnter(Collider other)
    {


        if(other.tag == "Player")
        {
            myBody.GetComponent<Enemy>().seeEnemy = true;
            myBody.GetComponent<Enemy>().target = Player.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<Enemy>().seeEnemy == true)
            {
                myBody.GetComponent<Enemy>().seeEnemy = true;
                myBody.GetComponent<Enemy>().target = Player.transform;
            }
        }
    }
}
