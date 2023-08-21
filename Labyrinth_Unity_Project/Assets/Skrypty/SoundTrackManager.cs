using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackManager : MonoBehaviour
{
    public int enemiesOnPlayer = 0;

    public float defaultOSTVolume;
    public float chaseOSTVolume;

    private float chaseOSTVolumeSmall;
    private float chaseOSTVolumeMedium;
    private float chaseOSTVolumeHard;



    public AudioSource defaultOST;
    public AudioSource chaseOST;

    private bool baseOST = true;

    public float turnDownTime;
    private float turnDownTimeMax;



    // Start is called before the first frame update
    void Start()
    {
        chaseOST.volume = 0;
        defaultOST.volume = defaultOSTVolume;
        chaseOSTVolumeSmall = chaseOSTVolume * 0.3f;
        chaseOSTVolumeMedium = chaseOSTVolume * 0.6f;
        chaseOSTVolumeHard = chaseOSTVolume * 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesOnPlayer <= 0)
        {
            //default ost
            baseOST = true;
        }
        else
        {
            //chase ost
            baseOST = false;
        }


        if(baseOST == true)
        {
            volumeDown(chaseOST);
            volumeUp(defaultOST, defaultOSTVolume);
        }
        else
        {
            volumeDown(defaultOST);
            if(enemiesOnPlayer == 1)volumeUp(chaseOST, chaseOSTVolumeSmall);
            if (enemiesOnPlayer == 2) volumeUp(chaseOST, chaseOSTVolumeMedium);
            if (enemiesOnPlayer >= 3) volumeUp(chaseOST, chaseOSTVolumeHard);


        }



    }


    private void volumeDown(AudioSource source)
    {
        if(source.volume != 0)
        {
            source.volume -= Time.deltaTime * 0.07f;
        }
    }


    private void volumeUp(AudioSource source, float vol)
    {
        if (source.volume <= vol)
        {
            source.volume += Time.deltaTime * 0.05f;
        }
    }


}
