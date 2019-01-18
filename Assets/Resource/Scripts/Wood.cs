using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.y);
        if(transform.position.y >50&&i==0)
        {
            StartCoroutine(ReWood());
        }
    }

    IEnumerator ReWood()
    {
        i++;
        yield return new WaitForSeconds(20);
        transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        i = 0;
    }
}
