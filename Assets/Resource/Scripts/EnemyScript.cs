using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


    public Transform Player;
    public static float Speed=3;
    public float curSpeed = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.time<100&&Speed==3)
        {
            Speed++;
            curSpeed++;
        }
        else if (GameManager.time < 50 && Speed == 4)
        {
            Speed++;
            curSpeed++;
        }
        else if (GameManager.time < 20 && Speed == 5)
        {
            Speed++;
            curSpeed++;
        }
        GetAngle();
    
	}

    void GetAngle()
    {
        Vector2 move = new Vector2(Player.transform.position.x, Player.transform.position.z) - new Vector2(transform.position.x, transform.position.z);
        move.Normalize();
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(move.x, move.y)*Mathf.Rad2Deg, 0);
        transform.Translate(Vector3.forward* Speed*Time.deltaTime);
        
    }

    private void OnTriggerExit(Collider other)
    {
        Speed+=4;
    }
    private void OnTriggerEnter(Collider other)
    {
        Speed = curSpeed;
    }
}
