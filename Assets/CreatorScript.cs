using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        
        Instantiate(box);
        box.transform.position = new Vector3(0, 0.5f, 10);
        Instantiate(box);
        box.transform.position = new Vector3(0, 0.5f, 25);
        Instantiate(box);
        box.transform.position = new Vector3(0, 0.5f, 40);
        Instantiate(box);
        box.transform.position = new Vector3(0, 0.5f, 55);
        
    }
}
