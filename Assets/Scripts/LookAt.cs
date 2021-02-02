using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float speed = 0.2f;
    [SerializeField]
    public Vector3 offset;
    void Update()
    {
        Vector3 Desired = target.position + offset;
        Vector3 Smoothed = Vector3.Lerp(transform.position, Desired, speed * Time.deltaTime);
        transform.position = Smoothed;
        transform.LookAt(target);
    }
}
