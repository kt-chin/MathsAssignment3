using UnityEngine;
using System.Collections;

public class MouseBehaviour : MonoBehaviour {
   // public GameObject camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Detected" + hit.transform.name);
            }
        }
      
      //  if(Physics.Raycast())
	}
}
