using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movespeed;
    public GameObject money;
    public GameObject box;
    public Transform player;
    Vector3 moneypos = new Vector3(0, 1.5f, -1);
    Vector3 boxpos = new Vector3(0, 0.5f, -1);




    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(0, 0, 5);
        }
    }
    public int boxcount { get; private set; }
    public int moneycount { get; private set; }

    public UnityEvent<Player> Onboxcollect;
    public UnityEvent<Player> Onboxdeposit;

    public void boxcollect()
    {
        boxcount++;
        Instantiate(box, player, false);
        box.transform.position = boxpos;
        Onboxcollect.Invoke(this);
    }
    public void boxdeposit()
    {
        
        boxcount--;
        moneycount++;
        Instantiate(money, player, false);
        money.transform.position = moneypos;
        Debug.Log("delivertag collision");
        /*for (var i = player.transform.childCount; i >= player.transform.childCount-1; i--)
        {
            Object.Destroy(player.transform.GetChild(i).gameObject);
        }*/
        Transform childToRemove = player.transform.Find("box2(Clone)");
        childToRemove.parent = null;
        Onboxdeposit.Invoke(this);


    }
    
}
