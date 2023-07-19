using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movespeed;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(0, 0, 5);
        }
    }
}
