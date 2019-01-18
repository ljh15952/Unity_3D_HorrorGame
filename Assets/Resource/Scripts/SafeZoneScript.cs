using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{


    public Light _light;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(lightDecrease());

        if (_light.spotAngle <= 5)
        {
            EnemyScript.Speed = 15;
            Debug.Log("WARNIG");
        }
    }

    IEnumerator lightDecrease()
    {
        yield return new WaitForSeconds(0.01f);
        _light.spotAngle -= 0.03f;
    }

}
