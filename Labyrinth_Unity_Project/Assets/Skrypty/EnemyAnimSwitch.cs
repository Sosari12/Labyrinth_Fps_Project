using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimSwitch : MonoBehaviour
{
    public bool[] Rodzaj; //0 walk, 1 attack, 
    private int losowana;
    public bool naStale;
    public bool zmieniono = false;
    public int ileAnimacjiWalk;
    public Animator myBodyAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(zmieniono == false)
        {
            if (Rodzaj[0] == true)
            {
                losowana = Random.Range(0, ileAnimacjiWalk);
                if (losowana == 0)
                {
                    myBodyAnim.SetBool("Walk1", true);
                    myBodyAnim.SetBool("Walk2", false);
                }else if (losowana == 1)
                {
                    myBodyAnim.SetBool("Walk1", false);
                    myBodyAnim.SetBool("Walk2", true);
                }
            }
        }
        





        if (naStale == true && zmieniono == false)
        {
            zmieniono = true;
        }


    }
}
