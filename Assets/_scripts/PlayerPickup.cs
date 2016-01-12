using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    [SerializeField] Transform cameraTransform;
    [SerializeField] GameObject pickupText;

    void Start()
    {
        pickupText.SetActive(false);
    }

	void Update ()
    {
        CheckForPickup();
	}

    void CheckForPickup()
    {
        RaycastHit hit;

        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 10);

        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward * 10, out hit));
        {
            if(hit.transform.tag == "Pickup")
            {
                pickupText.SetActive(true);
                Debug.Log("hit mayn");
            }
            else
            {
                pickupText.SetActive(false);
                Debug.Log("no hittered mate");
            }
        }
    }

    void PickupItem()
    {
        //
    }
}
