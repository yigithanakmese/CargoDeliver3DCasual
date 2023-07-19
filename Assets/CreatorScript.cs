using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorScript : MonoBehaviour
{
    public GameObject box;
    

    public void Start()
    {
        
            Instantiate(box);
        
    }
}
