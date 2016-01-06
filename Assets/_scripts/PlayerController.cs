using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour 
{

    private CharacterController _cc;
    private GameObject _camera;
    private Vector3 _normalCameraPos;
    private Vector3 _moveDirection;

    private float _cameraMoveSpeed = 3f;
    private float _playerNormalMoveSpeed = 4f;
    private float _playerMoveSpeed;
    private float _playerRunSpeed = 12f;
    private float _playerCrouchSpeed = 2f;
    private float _playerJumpSpeed = 10f;
    private float _upVisionRange = 45f;
    private float _downVisionRange = 70f;
    private float _verticalRotation = 0;

    private bool _isCrouching = false;

    private float x = 0f;
    private float y = 0f;
    private float gravity = 20f;

	void Awake ()
    {
        _cc = GetComponent<CharacterController>();
        _camera = GameObject.Find("Main Camera");
        _playerMoveSpeed = _playerNormalMoveSpeed;
        _normalCameraPos = _camera.transform.localPosition;
	}
	
	void FixedUpdate ()
    {
        CameraRotation();
        Movement();
        PickupItem();
	}

    void CameraRotation()
    {
        float RightX = Input.GetAxis("JoystickRX");
        float RightY = Input.GetAxis("JoystickRY");

        x += RightX * _cameraMoveSpeed;
        y += RightY * _cameraMoveSpeed;

        x = Mathf.Clamp(x, -_upVisionRange, _downVisionRange);
        _verticalRotation = x;
        
        _camera.transform.eulerAngles = new Vector3(_verticalRotation, y, 0f);
        transform.eulerAngles = new Vector3(0f, y, 0f);

    }

    void Movement()
    {
        float LeftX = Input.GetAxis("Horizontal") * _playerMoveSpeed;
        float LeftY = Input.GetAxis("Vertical") * _playerMoveSpeed;

        if (_cc.isGrounded)
        {
            _moveDirection = new Vector3(LeftX, 0, LeftY);
            _moveDirection = transform.TransformDirection(_moveDirection);
            if (Input.GetButton("JoystickA"))
             {
                _moveDirection.y += _playerJumpSpeed;
             }
            
        }
        _cc.Move(_moveDirection * Time.fixedDeltaTime);
        _moveDirection.y -= gravity * Time.fixedDeltaTime;

        if (_isCrouching == false)
        {
            if (Input.GetButtonDown("JoystickLB"))
            {
                _playerMoveSpeed = _playerRunSpeed;
            }
            else if (Input.GetButtonUp("JoystickLB"))
            {
                _playerMoveSpeed = _playerNormalMoveSpeed;
            }
        }

        if (Input.GetButtonDown("JoystickRB"))
        {
            Crouch();   
        }
    }

    void Crouch()
    {
        Vector3 crouchCameraPos = _normalCameraPos + new Vector3(0, -.8f, 0);

        _isCrouching = !_isCrouching;

        if (_isCrouching == false)
        {
            _playerMoveSpeed = _playerNormalMoveSpeed;
            _camera.transform.localPosition = _normalCameraPos;
        }
        else if (_isCrouching == true)
        {
            _playerMoveSpeed = _playerCrouchSpeed;
            _camera.transform.localPosition = crouchCameraPos;

        }
    }

    void PickupItem()
    {
        if (Input.GetButtonDown("JoystickA"))
        {
            Debug.Log("A is pressed");
            /*
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, fwd, out hitInfo, 10))
            {
                if (hitInfo.collider.tag == "Pickup")
                {
                    // pak de pickup op
                }
            }
            */
        }
    }
}
