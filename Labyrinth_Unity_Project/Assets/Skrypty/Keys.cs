using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public bool hasKey1;
    public GameObject effect;

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
        if (other.tag == "Key")
        {
            hasKey1 = true;
            Destroy(other.gameObject);
            GameObject effectObj = Instantiate(effect, transform.position, Quaternion.identity);
            effectObj.SetActive(true);
        }


    }
}
