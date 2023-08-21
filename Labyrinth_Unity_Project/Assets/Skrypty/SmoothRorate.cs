using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRorate : MonoBehaviour
{
    public float smooth;
    public GameObject cam;
    private Transform targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation = cam.transform;


        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation.rotation, smooth * Time.deltaTime);
    }
}
