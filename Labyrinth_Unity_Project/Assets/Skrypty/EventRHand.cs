using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRHand : MonoBehaviour
{
    public GameObject hitBox;
    public Animator PHandAnim;
    public AudioClip[] iSFX;
    public AudioClip[] rpSFX;
    public AudioClip[] fpSFX;

    //public GameObject[] hSFX;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisableHitBox()
    {
        hitBox.SetActive(false);
        PHandAnim.SetBool("HitBool", false);

    }

    public void EnableHitBox()
    {
        hitBox.SetActive(true);
    }


    public void Idle2SFX()
    {
        int idleLos = Random.Range(0, iSFX.Length);
        source.clip = iSFX[idleLos];
        source.Play();
    }

    public void RampUpSFX()
    {
        int RampUpLos = Random.Range(0, rpSFX.Length);
        source.clip = rpSFX[RampUpLos];
        source.Play();
    }

    public void FlySFX()
    {
        int FlyLos = Random.Range(0, fpSFX.Length);
        source.clip = fpSFX[FlyLos];
        source.Play();
    }

    /*
    public void HitSFX()
    {
        int hitLos = Random.Range(0, hSFX.Length);
        GameObject hitSFXObj = Instantiate(hSFX[hitLos], transform.position, Quaternion.identity);
        hitSFXObj.SetActive(true);
    }
    */
}
