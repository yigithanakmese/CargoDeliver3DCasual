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
    





    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(0, 0, 5);
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
                var newObj = Instantiate(box);
                newObj.transform.parent = obj.transform;
                newObj.GetComponent<BoxCollider>().enabled = false;
                var newPos = obj.transform.position;               
                newObj.transform.position = newPos;
                obj.transform.DOMoveX(-3, 1f);
                obj.GetComponent<BoxCollider>().enabled = false;
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
            boxdeposit(other.gameObject);
        }

        if (other.transform.tag == "enemytag")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Player>().enabled = false;
            Die();
        }
        if ((other.transform.tag =="finishtag"))
        {
            lId = lId +1;            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
