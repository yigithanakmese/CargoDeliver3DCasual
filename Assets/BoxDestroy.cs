using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxDestroy : MonoBehaviour
{
   


    private void OnTriggerEnter(Collider other)
    {
        Player inventory = other.GetComponent<Player>();
        if (inventory != null)
        {
            inventory.boxcollect();
         
            gameObject.SetActive(false);
        }
    }
}
