using Unity.VisualScripting;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Vector3 startPos;
    Vector3 offset;
    Plane projectionPlane;
    Rigidbody rb;

    [SerializeField]
    [Tooltip("Move the object by adding force. If false, object will telleport to the new mouse position. moveWithForce is allways false for kinematic objects")]
    bool moveWithForce=true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb.isKinematic) moveWithForce = false;
        projectionPlane = new Plane(-Vector3.forward, transform.position);
    }

    private Vector3 findMousePoseOnPlane()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (projectionPlane.Raycast(ray, out distance))
        {
            Vector3 mousePose = ray.GetPoint(distance);
            //Debug.Log("------->\nmosuePose is: "+ mousePose);
            //Debug.Log("my pose is: "+ transform.position + "\n<----------");
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
        //Debug.Log("mousePosInGame is: " + mousePosInGame);
        //Debug.Log("Object Pos is: " + transform.position);
        if (moveWithForce)
        {
            Vector3 force = (destination - transform.position) * 200;
            rb.AddForce(force);
        }
        else
            transform.position = destination;
    }

    private void Update()
    {
        rb.velocity *= 0.1f * Time.deltaTime;
    }

}