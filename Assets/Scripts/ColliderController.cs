using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiger")
        { 
            Destroy(other.gameObject);
            GameObject.Find("Girl").GetComponent<Cutscene>().RunScene();
        }
    }
}
