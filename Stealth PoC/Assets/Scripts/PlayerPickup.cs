using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    

    [SerializeField]
    Transform cameraTransform;

    private GameObject _pickupText;
    private Text _itemText;

    private int _items = 0;

    private bool _isHittingPickup = false;

    private float _maxPickupRange = 2f;

    void Start()
    {
        _pickupText = GameObject.Find("PickupText");
        _pickupText.GetComponent<RawImage>().enabled = true;
         _pickupText.SetActive(false);
        _itemText = GameObject.Find("ItemsText").GetComponent<Text>();
    }

    void Update()
    {
        CheckForPickup();
    }

    void CheckForPickup()
    {
        RaycastHit hit;

        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * _maxPickupRange);

        _isHittingPickup = Physics.Raycast(new Ray(cameraTransform.position, cameraTransform.forward), out hit, _maxPickupRange);

            if(_isHittingPickup)
            {
                if (hit.transform.tag == "Pickup")
                {
                    _pickupText.SetActive(true);
                    if(Input.GetButtonDown("JoystickX"))
                    {
                        _items++;
                        Destroy(hit.transform.gameObject);
                        _itemText.text = "Items: " + _items + "/4";
                        _pickupText.SetActive(false);
                    }
                }
            }
            else
            {
               _pickupText.SetActive(false);
            }
    }
}
