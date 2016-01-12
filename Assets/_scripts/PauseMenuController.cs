using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour {

    bool _isPaused = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton7) && (_isPaused == false))
        {
            Debug.Log("Game paused");
            Time.timeScale = 0;
            _isPaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.JoystickButton7) && (_isPaused == true))
        {
            Time.timeScale = 1;
            _isPaused = false;
            Debug.Log("Game Unpaused");
        }
	}
}