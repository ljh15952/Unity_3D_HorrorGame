using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public Text timer;
    public  Text WoodText;
    static public int time=180;
    public int woodNum=0;
    float minX, minY, maxX, maxY;

    public GameObject SZS;

    // Use this for initialization
    void Start ()
    {
        WoodText.text = "WooD : " + woodNum.ToString();
        StartCoroutine(timerF());
    }

    // Update is called once per frame
    void Update ()
    {
        if(time <=0)
        {
            SceneManager.LoadScene("WIN");
        }
	}

    IEnumerator timerF()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            timer.text = "Remain : " + time.ToString();
        }
    }

    public void GetWood()
    {
        woodNum++;
        WoodText.text = "WooD : " + woodNum.ToString();
    }

    public void ReturnWood()
    {
        for(int i=0; i<woodNum;i++)
        {
            SZS.GetComponent<SafeZoneScript>()._light.spotAngle += 5;
        }
        woodNum = 0;
        WoodText.text = "WooD : " + woodNum.ToString();
    }
}
