using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuKlocki : MonoBehaviour
{
    public float backDistance;
    public float originalDist;
    public bool feelKursor = false;

    // Start is called before the first frame update
    void Start()
    {
        originalDist = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kursor")
        {
            this.transform.position = new Vector3(0, 0, backDistance);
            feelKursor = true;
        }

    }

}
