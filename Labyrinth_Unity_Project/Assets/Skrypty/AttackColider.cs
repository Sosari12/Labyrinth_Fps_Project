using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColider : MonoBehaviour
{
    public bool hitPlayer = false;
    public float invTime;
    private float invMaxTime;
    private bool readyToHit = true;
    public Enemy myBody;

    // Start is called before the first frame update
    void Start()
    {
        invMaxTime = invTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToHit == false)
        {
            if(invTime <= 0)
            {
                invTime = invMaxTime;
                readyToHit = true;
            }
            else
            {
                invTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.tag == "Player")
            {
                if (readyToHit == true)
                {
                //hitPlayer = true;
                GameObject.Find("Player").GetComponent<PlayerControl>().health -= myBody.Damage;
                GameObject.Find("Player").GetComponent<PlayerControl>().PlayHitSFX();

                readyToHit = false;
                }
            }

    }

}
