using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour
{
    public GameObject myAttackColider;

    //public Enemy myBody;
    public GameObject healthSpawn;
    public GameObject ammoSpawn;
    public int healthDropRate;
    public int ammoDropRate;
    private int losHealth;
    private int losAmmo;

    public SoundTrackManager OSTManager;

    //The box's current health point total
    public int currentHealth = 3;

    public void Damage(int damageAmount)
    {
        myAttackColider.GetComponent<PlayerDetect>().violence = true;
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            //if health has fallen below zero, deactivate it 

            OSTManager.enemiesOnPlayer--;
            losAmmo = Random.Range(0, ammoDropRate);
            losHealth = Random.Range(0, healthDropRate);
            if(losHealth <= 10)
            {
                GameObject healthObj = Instantiate(healthSpawn, transform.position, Quaternion.identity);
                healthObj.SetActive(true);
            }
            if (losAmmo <= 10)
            {
                GameObject ammoObj = Instantiate(ammoSpawn, transform.position, Quaternion.identity);
                ammoObj.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}