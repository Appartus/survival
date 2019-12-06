using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    bool doorIsOpen = false;

    float doorTimer = 0.0f;
    int a = 0;
    public float doorOpenTime = 4.0f;

    public AudioClip doorOpenSound;
    GameObject currentDoor;
    public AudioClip doorShutSound;
    // Start is called before the first frame update
    void OnControllerColliderHit (ControllerColliderHit hit) {
        if (hit.gameObject.tag == "playerDoor" && doorIsOpen == false) {

            currentDoor = hit.gameObject;

            OpenDoor (currentDoor);
        }
    }

    void OpenDoor (GameObject door) {
        door.GetComponent<AudioSource> ().PlayOneShot (doorOpenSound);
        doorIsOpen = true;
        door.transform.parent.GetComponent<Animation> ().Play ("dooropen");
    }
    void ShutDoor (GameObject door) {

        doorIsOpen = false;

        door.GetComponent<AudioSource> ().PlayOneShot (doorShutSound);

        door.transform.parent.GetComponent<Animation> ().Play ("doorshut");

    }

    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (doorIsOpen) {
            doorTimer += Time.deltaTime;
            if (doorTimer > doorOpenTime) {

                ShutDoor (currentDoor);

                doorTimer = 0.0f;

            }
        }

    }
}