using UnityEngine;
using System.Collections;

public class Disable : MonoBehaviour {

    Light light;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
