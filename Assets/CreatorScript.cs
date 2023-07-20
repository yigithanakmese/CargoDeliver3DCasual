using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class CreatorScript : MonoBehaviour
{
    public GameObject box;
    public GameObject road;
    public GameObject houseyellow;




    public void Start()
    {
        int j = 10;
        for (int i = 0; i < 8; i++)
        {
            
            Instantiate(road);
            road.transform.position = new Vector3(0,0,j);
            j = j + 10;
        }
        int h = 15;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(houseyellow);
            houseyellow.transform.position = new Vector3(-5, 0, h);
            h = h + 15;
        }
        
        Instantiate(box, new Vector3(0, 0.5f, 10), Quaternion.identity);
        Instantiate(box, new Vector3(0, 0.5f, 25), Quaternion.identity);
        Instantiate(box, new Vector3(0, 0.5f, 40), Quaternion.identity);
        Instantiate(box, new Vector3(0, 0.5f, 55), Quaternion.identity);
        
        
        
    }
}
