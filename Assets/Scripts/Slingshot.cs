using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    
    bool itsDown;
    Ray mouseRay;
    RaycastHit mouseHit;
    public Vector3 startPos;
    public Vector3 finishPos;
    public TrajectoryRenderer Trajectory;
    public bool isCollider;
    // Start is called before the first frame update
   
    void Update()
    {
        if (isCollider)
        {
        
            if (Input.GetMouseButtonDown(0))
            {
                itsDown = true;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out mouseHit, 100))
                {
                    startPos = mouseHit.point;
                }
            }
            if (itsDown)
            {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float midPoint = (transform.position - Camera.main.transform.position).magnitude * 4.5f;

                Vector3 speed = (finishPos - startPos) * 430;
                Trajectory.ShowTrajectory(transform.position, -speed);
                transform.LookAt(mouseRay.origin + new Vector3(-mouseRay.direction.x, -mouseRay.direction.y, mouseRay.direction.z) * midPoint);

                if (Physics.Raycast(mouseRay, out mouseHit, 100))
                {
                    finishPos = mouseHit.point;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                itsDown = false;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(
                transform.forward * Vector3.Distance(startPos, finishPos) * 3000, startPos);
            }
        }
        
    }

}
