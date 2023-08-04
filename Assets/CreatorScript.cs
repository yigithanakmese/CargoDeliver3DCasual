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
    public GameObject enemy;
    public GameObject finish;

    public int[] roadLen = new[] { 8, 10, 12 };
    public int[] houseNum = new[] { 4, 30, 40 };
    public int[] boxNum = new[] { 4, 30, 40 };
    public int[] enemyNum = new[] { 2, 3, 4 }; 
    public Player playerscript;

   

    public void Start()
    {
        playerscript = FindObjectOfType<Player>();
        int LID = PlayerPrefs.GetInt("levelID");
        
        int j = 10;
        for (int i = 0; i < roadLen[LID]; i++)
        {
            var newRoad = Instantiate(road);
            newRoad.transform.position = new Vector3(0, 0, j);
            j = j + 10;
        }
        int h = 15;
        for (int i = 0; i < houseNum[LID]; i++)
        {
            var newHouse = Instantiate(houseyellow);
            var r = Random.Range(0, 10);
            if (r%2==0)
            {
                newHouse.transform.position = new Vector3(-5, 0, h);
            }

            else
            {
                newHouse.transform.position = new Vector3(5, 0, h);
                newHouse.transform.Rotate(0,180,0);
            }
    
            
            

            h = h + 15;
        }

        int l = 10;
        for (int i = 0; i < boxNum[LID]; i++)
        {
            var newBox = Instantiate(box);
            newBox.transform.position = new Vector3(0, 0.5f, l);
            l = l + 15;
        }
        int e = 20;
        for (int i = 0; i < enemyNum[LID]; i++)
        {
            var newBox = Instantiate(enemy);
            newBox.transform.position = new Vector3(0, 0.5f, e);
            e = e + 15;
        }

        var newFinish = Instantiate(finish);
        newFinish.transform.position = new Vector3(0, 0, roadLen[LID] * 10);

    }
    
}
