using UnityEngine;
using System.Collections;
using TMPro;

public class RaycastShootComplete : MonoBehaviour
{

    public int gunDamage = 1;                                            // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.1f;                                        // Number in seconds which controls how often the player can fire
    public float weaponRange = 50f;                                        // Distance in Unity units over which the player can fire
    public float hitForce = 100f;                                        // Amount of force which will be added to objects with a rigidbody shot by the player
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun

    public Camera fpsCam;                                                // Holds a reference to the first person camera
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    private AudioSource gunAudio;                                        // Reference to the audio source which will play our shooting sound effect
    private LineRenderer laserLine;                                        // Reference to the LineRenderer component which will display our laserline
    private float nextFire;                                                // Float to store the time the player will be allowed to fire again, after firing

    public TMP_Text ammoText;
    public TMP_Text ReserveammoText;
    public int currentAmmo;
    public int maxAmmo;
    public GameObject shootEffect;
    public int ammoPack = 3;
    public int MaxAmmoPack;

    public Animator LHandAnim;
    public LayerMask IgnoreMe;

    public PlayerControl myBody;

    public GameObject ShootLight;

    public GameObject[] ShootSFX;
    public GameObject[] bulletDropSFX;

    

    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();

        // Get and store a reference to our AudioSource component
        gunAudio = GetComponent<AudioSource>();

        // Get and store a reference to our Camera by searching this GameObject and its parents
        //fpsCam = GetComponentInParent<Camera>();
        maxAmmo = currentAmmo;
        MaxAmmoPack = GameObject.Find("Player").GetComponent<PlayerControl>().MaxammoPacks;
    }


    void Update()
    {
        ammoPack = GameObject.Find("Player").GetComponent<PlayerControl>().ammoPacks;
        ReserveammoText.text = ""+ ammoPack + "/" + MaxAmmoPack;

        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired

        if (ammoPack > 0 && Input.GetKeyDown(KeyCode.R))
        {
            int randomReload = Random.Range(0, 3);
            if(randomReload == 0)LHandAnim.SetTrigger("Reload2");
            else LHandAnim.SetTrigger("Reload1");
        }






        if (Input.GetMouseButton(0) && Time.time > nextFire && currentAmmo>0)
        {
            LHandAnim.SetBool("Shoot", true);
            myBody.Slowed = true;
            
        }
        ammoText.text = "" + currentAmmo;

        if (!Input.GetMouseButton(0))
        {
            LHandAnim.SetBool("Shoot", false);
        }

    }


    private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        //gunAudio.Play();

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }

    public void ShootGun()
    {
        if (currentAmmo > 0) { 
            currentAmmo--;

            GameObject shootLightObj = Instantiate(ShootLight, gunEnd.position, Quaternion.identity);
            int shootLos = Random.Range(0, ShootSFX.Length);
            GameObject shootSFXObj = Instantiate(ShootSFX[shootLos], gunEnd.position, Quaternion.identity);

            int dropLos = Random.Range(0, bulletDropSFX.Length);
            GameObject dropSFXObj = Instantiate(bulletDropSFX[dropLos], gunEnd.position, Quaternion.identity);


            shootLightObj.SetActive(true);
            shootSFXObj.SetActive(true);
            dropSFXObj.SetActive(true);

            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Check if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, ~IgnoreMe))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                // Get a reference to a health script attached to the collider we hit
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                // If there was a health script attached
                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage);
                }

                // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }

                GameObject effectObj = Instantiate(shootEffect, hit.point, Quaternion.identity);

                effectObj.SetActive(true);
            }
            else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }






    public void ReloadWeapon()
    {

        if (ammoPack > 0)
        {
            //Reload
            currentAmmo = maxAmmo;
            //ammoPack--;
            GameObject.Find("Player").GetComponent<PlayerControl>().ammoPacks -= 1;

        }

    }


}
