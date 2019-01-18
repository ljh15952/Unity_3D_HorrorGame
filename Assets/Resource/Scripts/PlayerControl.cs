using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;

    public Joystick joystick;


    public Camera Cam;

    public Image DashBar;
    public Text SpeedText;

    bool isCoolTime;

    private Vector3 _moveVector;
    private Transform _transform;

    public GameManager GM;

    public AudioSource Walk;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        _transform = transform;
        _moveVector = Vector3.zero;
        isCoolTime = false;

        Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.
    }

    private void Update()
    {
        SpeedText.text = "Speed : " + moveSpeed.ToString();

        PlayerMove();
        PlayerDash();
        RotateCamera();



        HandleInput();
        Move();
    }

    public void HandleInput()
    {
        _moveVector = PoolInput();
    }
    float h, v;
    public Vector3 PoolInput()
    {
        h = joystick.GetHorizontalValue();
        v = joystick.GetVerticalValue();

        Vector3 movedir = new Vector3(h, 0, v).normalized;

        return movedir;
    }

    public void Move()
    {
        _transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }

    void PlayerMove()
    {
        float Hor = Input.GetAxis("Horizontal");
        float Ver = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(Hor, 0, Ver);
        _transform.Translate(move * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {


            StartCoroutine("Sound");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {

            StopCoroutine("Sound");
        }
    }
    public float delay=1;
    IEnumerator Sound()
    {
        while (true)
        {
            Walk.Play();
            yield return new WaitForSeconds(delay);

        }
    }

    void PlayerDash()
    {
        // if (v>0.8f&& DashBar.fillAmount>0&&!isCoolTime)

        if (Input.GetKey(KeyCode.LeftShift) && DashBar.fillAmount > 0 && !isCoolTime)
        {
            StartCoroutine(Dash());
            delay = 0.5f;
        }
        else
        {
            if (DashBar.fillAmount <= 0.01f)
            {
                isCoolTime = true;
            }
            if (DashBar.fillAmount >= 0.5)
            {
                isCoolTime = false;
            }
            StartCoroutine(DashIncrease());
            moveSpeed = 5;
            delay = 1;
        }
    }

    IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.01f);
        moveSpeed += 0.05f;
        DashBar.fillAmount -= 0.005f;

    }
    IEnumerator DashIncrease()
    {
        yield return new WaitForSeconds(0.01f);
        DashBar.fillAmount += 0.005f;
    }





    void RotateCamera()
    {


        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;




        transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        Cam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);

        





    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wood"))
        {
            GM.ReturnWood();
        }

        if (collision.gameObject.CompareTag("Hit"))
        {
            SceneManager.LoadScene("DIESCENE");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("getwood"))
        {
            Debug.Log("ASDASDASD");
            other.transform.position = new Vector3(other.transform.position.x,999,transform.position.z);
            GM.GetWood();
        }
    }
}
