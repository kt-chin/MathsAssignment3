using UnityEngine;
using System.Collections;

public class CameraScript: MonoBehaviour {
    public GameObject Squares;
    private float speed = 20.0f;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    public bool toggledMouse = false;
  //  private objectPool poolScript;


    // Use this for initialization
    void Start () {
     //   poolScript.GetComponent<objectPool>();

    }
    //void Shoot()
    //{
    //    for (int i = 0; i < Squares.Length; i++)
    //    {
    //        Instantiate(Squares[i], transform.position, transform.rotation);
    //    }
    //   // poolScript.
    //}
	
	// Update is called once per frame
	void Update () {
        if (toggledMouse == true)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(toggledMouse)
            {
                Cursor.visible = true;
                toggledMouse = false;
            }
            else
            {
                Cursor.visible = false;
                toggledMouse = true;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right* speed);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left *speed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0.0f, 1.0f, 0.0f)*speed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0.0f, -1.0f, 0.0f) * speed);
        }

        if (toggledMouse)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Left click");
                GameObject squareInstance;
                squareInstance = Instantiate(Squares, transform.position, transform.rotation) as GameObject;
                squareInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                //poolScript.gameObject 
                //Instantiate(floatObjects);
            }
        }

    }
}
