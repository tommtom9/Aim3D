using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public void PickupItem()
    {
        Destroy(this.gameObject);
    }
}
