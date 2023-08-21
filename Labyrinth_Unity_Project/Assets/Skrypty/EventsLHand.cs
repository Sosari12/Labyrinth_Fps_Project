using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsLHand : MonoBehaviour
{

    public GameObject RayCastScript;
    public PlayerControl myBody;
    public AudioClip[] rldSFX;
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


    public void ReloadEvent()
    {
        RayCastScript.GetComponent<RaycastShootComplete>().ReloadWeapon();
    }

    public void ShootEvent()
    {
        if(Input.GetMouseButton(0)) RayCastScript.GetComponent<RaycastShootComplete>().ShootGun();

    }

    public void DisableSlow()
    {
        myBody.Slowed = false;
    }

    public void ReloadSFX()
    {
        int reloadLos = Random.Range(0, rldSFX.Length);
        source.clip = rldSFX[reloadLos];
        source.Play();

    }
}
