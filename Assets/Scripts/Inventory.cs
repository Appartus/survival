using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int charge = 0;

    public AudioClip collectSound;

    public Text textHints;

    // HUD
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;
    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;
    //Matches
    bool haveMatches = false;
    public RawImage matchHudGUI;

    void Start()
    {
        charge = 0;
        haveMatches = false;
    }
    void CellPickup()
    {
        HUDon();
        AudioSource.PlayClipAtPoint(collectSound, transform.position);

        charge++;
        chargeHudGUI.texture = hudCharge[charge];

        meter.material.mainTexture = meterCharge[charge];

    }
    void HUDon()
    {

        if (!chargeHudGUI.enabled)
        {
            chargeHudGUI.enabled = true;
        }

    }

    void MatchPickup()
    {
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        matchHudGUI.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {

        if (col.gameObject.name == "campfire")
        {
            if (haveMatches == true) LightFire(col.gameObject);

        }

    }

    void LightFire(GameObject campfire)
    {
        ParticleSystem[] fireEmitters;
        fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem emitter in fireEmitters)
        {

            emitter.Play();

        }
        campfire.GetComponent<AudioSource>().Play();
        matchHudGUI.enabled = false;
        haveMatches = false;
    }


}
