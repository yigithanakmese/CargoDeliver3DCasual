using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movespeed;   
    public Transform player;   
    public GameObject boxes;
    public GameObject box;

    public float timer = 3f;
    public bool isReadyForDeposit;
    public bool timerStarted;
    public GameObject del;

    private void Start()
    {
        isReadyForDeposit = false;
        timerStarted = false;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(0, 0, 5);
        }


        if (timerStarted)
        {
            timer -= Time.deltaTime;
            if (timer<= 0)
            {
                timerStarted = false;
                timer = 3f;
                boxdeposit(del);
                
            }
        }

       

    }
    public int boxcount { get; private set; }
    public int moneycount { get; private set; }


    public void BoxCollect(GameObject obj)
    {
        var newPos = boxes.transform.position;
        boxcount++;
        obj.transform.parent = boxes.transform;
        newPos.y = boxcount;
        obj.transform.position = newPos;

    }
     
    public void boxdeposit(GameObject obj)
    {               
            if (boxcount > 0)
            {
          
                var deliverPos = obj.GetComponent<Home>().deliverPos.transform.position;
                
                var newObj = Instantiate(box);
                newObj.transform.parent = obj.transform;
                newObj.GetComponent<BoxCollider>().enabled = false;
                var newPos = obj.transform.position;               
                newObj.transform.position = newPos;
                newObj.transform.DOMove(deliverPos, 1f);
                //obj.GetComponent<BoxCollider>().enabled = false;
                boxcount--;
                moneycount++;
                Debug.Log("delivertag collision");
                int i = boxcount;
                GameObject.Destroy(boxes.transform.GetChild(i).gameObject);
            }
          
    }
    public GameOverScript GameOverScreen;

    public void Die()
    {
        GameOverScreen.Setup();
    }

    public int lId = 0;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "boxtag")
        {
            BoxCollect(other.transform.gameObject);
        }

        if (other.transform.tag == "delivertag")
        {
            Debug.Log("1");
            del = other.gameObject;
            other.enabled = false;
            timerStarted = true;
            

            
        }

        if (other.transform.tag == "enemytag")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Player>().enabled = false;
            Die();
        }
        if ((other.transform.tag =="finishtag"))
        {
            var lID = PlayerPrefs.GetInt("levelID");     
            PlayerPrefs.SetInt("levelID",lID+1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("is Exit");
        if (other.transform.tag == "delivertag")
        {
            timerStarted = false;
            timer = 3f;

        }
    }

    
}
