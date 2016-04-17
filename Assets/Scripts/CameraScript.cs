using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    public Transform target;
    private float speed = 20.0f;
    private Vector3 point;
    private Vector3 yAxis;
	// Use this for initialization
	void Start () {
        point = target.transform.position;
        transform.LookAt(point);
        yAxis = new Vector3(0.0f,1.0f,0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(point,yAxis,speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(point, yAxis,-speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, 1.0f));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -1.0f));
        }

    }
}
