using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public void Restart()
    {
        Application.LoadLevel(0);
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Sausage")
        {
            Restart();
            print("Win");
        }
    }
}
