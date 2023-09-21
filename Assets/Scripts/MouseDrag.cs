using Unity.VisualScripting;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    //private Rigidbody rb;
    //private Vector3 offset;
    //private float hitZ;
    //private float ObjectZ;
    //private bool isDragging = false;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {

    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit) && hit.collider.transform.IsChildOf(transform))//hit.collider == objectCollider)
    //        {
    //            // Mouse click is on the object; start dragging
    //            Debug.Log("hit.point is: " + hit.point);
    //            hitZ = Vector3.Dot((hit.point - Camera.main.transform.position),Camera.main.transform.rotation*Vector3.forward);
    //            Vector3 mouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, hitZ));
    //            Debug.Log("mouse to world is: " + mouseToWorld);
    //            offset = rb.position - hit.point;
    //            Debug.Log("offset is: "+ offset);
    //            Debug.Log("mouse to world plus offset is: " + (mouseToWorld + offset));
    //            isDragging = true;
    //        }
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        isDragging = false;
    //    }
    //    UpdatePos();
    //}

    //private void UpdatePos()
    //{
    //    if (isDragging)
    //    {
    //        // Calculate the target position based on the mouse position
    //        Vector3 mouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, hitZ));
    //        Debug.Log("mouse to world is: " + mouseToWorld);
    //        Vector3 targetPosition = mouseToWorld+ offset;
    //        Debug.Log("current position is " + transform.position);
    //        Debug.Log("target position is " + targetPosition);

    //        // Calculate the force vector to move the object towards the target position
    //        Vector3 force = (targetPosition - rb.position) * 100f; // Adjust force strength as needed

    //        // Apply the force to the object's Rigidbody

    //        //rb.velocity *= 0.1f * Time.deltaTime;
    //        //rb.AddForce(force);

    //        transform.position = targetPosition;
    //    }
    //}
    Vector3 startPos;
    Vector3 offset;
    Plane projectionPlane;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        projectionPlane = new Plane(-Vector3.forward, transform.position);
    }

    private Vector3 findMousePoseOnPlane()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (projectionPlane.Raycast(ray, out distance))
        {
            Vector3 mousePose = ray.GetPoint(distance);
            Debug.Log("------->\nmosuePose is: "+ mousePose);
            Debug.Log("my pose is: "+ transform.position + "\n<----------");
            return mousePose;
        }
        return transform.position;

    }

    void OnMouseDown()
    {
        Vector3 mousePosInGame = findMousePoseOnPlane();
        offset = transform.position - mousePosInGame;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosInGame = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, startPos.z));
        mousePosInGame = findMousePoseOnPlane();
        Vector3 destination = mousePosInGame + offset;
        Debug.Log("mousePosInGame is: " + mousePosInGame);
        Debug.Log("Object Pos is: " + transform.position);
        Vector3 force = (destination - transform.position) * 100;
        rb.AddForce(force);
        //transform.position = destination;
    }

    private void Update()
    {
        rb.velocity *= 0.1f * Time.deltaTime;
    }

}