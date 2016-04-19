//using UnityEngine;
//using System.Collections;

//public class objectPool : MonoBehaviour {
//    public GameObject[] floatObjects;
//    private CameraScript camScript;
//    int lastObject = -1;
//    int objectCache = 5;
//	// Use this for initialization
//	void Awake () {
//        floatObjects = new GameObject[objectCache];
//        for (int i = 0; i<floatObjects.Length; i++)
//        {
//            Instantiate(floatObjects[i],transform.position,transform.rotation);
//            floatObjects[i].SetActive(false);
//        }
//        //camScript.GetComponent<CameraScript>()
//	}

      
   
//	// Update is called once per frame
//	void Update () {
//        GameObject fObject = floatObjects[lastObject++];
//        if (lastObject > objectCache - 1)
//        {
//            lastObject = 0;
//        }
//        fObject.SetActive(true);
//        fObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
//        fObject.transform.position = transform.position;
//        fObject.transform.rotation = transform.rotation;
//        fObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100.0f);
//       // return lastObject;
//    }
//}
