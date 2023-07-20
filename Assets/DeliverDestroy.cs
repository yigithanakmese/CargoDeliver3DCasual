using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player inventory = other.GetComponent<Player>();
        if (inventory != null)
        {
            inventory.boxdeposit();
            gameObject.SetActive(false);

        }
    }
}
