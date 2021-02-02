using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public GameObject parent;
    private Slingshot slingshot;
    public bool isShot;
    
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
        parent.GetComponent<Slingshot>().isCollider = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            parent.GetComponent<Slingshot>().isCollider = false;
        }
    }

}
