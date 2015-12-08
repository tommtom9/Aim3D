using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    CharacterController controller;
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float visionrangeRange = 3;
    public float maxVisionRange = 15;
    private Light lighting;

    private float vector3Add;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        lighting = GetComponentInChildren<Light>();
    }
    void Update()
    {

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        vector3Add = controller.velocity.magnitude;

        lighting.range = maxVisionRange - (Mathf.Abs(vector3Add) * visionrangeRange);
    }

}
