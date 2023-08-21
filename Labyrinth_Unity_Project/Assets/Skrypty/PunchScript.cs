using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    public int PunchDamage;
    public float impulsePower;
    public Animator PHandAnim;
    public GameObject[] hSFX;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //play sound
            int hitLos = Random.Range(0, hSFX.Length);
            GameObject hitSFXObj = Instantiate(hSFX[hitLos], transform.position, Quaternion.identity);
            hitSFXObj.SetActive(true);
            //play vfx


            PHandAnim.SetBool("HitBool" , true);
            ShootableBox health = other.GetComponent<ShootableBox>();

            if (health != null)
            {
                health.Damage(PunchDamage);
            }
        }
    }
}
