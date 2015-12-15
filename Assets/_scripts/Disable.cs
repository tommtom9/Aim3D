using UnityEngine;
using System.Collections;

public class Disable : MonoBehaviour {

    Light _lighting;
	// Use this for initialization
	void Start () {
        _lighting = GetComponent<Light>();
        _lighting.enabled = false;
	}
}
