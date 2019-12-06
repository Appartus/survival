using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
	
	CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController> ();
		
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C)){
			cc.height = 1.0f;
		} else {
			cc.height = 1.8f;
		}
		
    }
}
