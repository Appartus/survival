using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    bool doorIsOpen = false;

    float doorTimer = 0.0f;
    int a = 0;
    public float doorOpenTime = 4.0f;

    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    void Door(AudioClip aClip, bool openCheck, string animName)
    {
        if (doorIsOpen == false)
        {
            GetComponent<AudioSource>().PlayOneShot(doorOpenSound);
            doorIsOpen = true;
            transform.parent.GetComponent<Animation>().Play("dooropen");
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(doorShutSound);
            doorIsOpen = false;
            transform.parent.GetComponent<Animation>().Play("doorshut");
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpen)
        {
            doorTimer += Time.deltaTime;
            if (doorTimer > doorOpenTime)
            {

                Door(doorShutSound, doorIsOpen, "doorshut");

                doorTimer = 0.0f;

            }
        }

    }

    void DoorCheck()
    {
        if (!doorIsOpen)
        {
            Door(doorOpenSound, true, "dooropen");
        }
    }
}
