using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverDestroy : MonoBehaviour
{
    public GameObject box;
    public Transform house;
    Vector3 boxpos = new Vector3(2, 0.5f, 3);
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(box,house,false);
        box.transform.position = boxpos;
        Player inventory = other.GetComponent<Player>();
        if (inventory != null)
        {
            inventory.boxdeposit();
            gameObject.SetActive(false);

        }
    }
}
