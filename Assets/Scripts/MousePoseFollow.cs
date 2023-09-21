using UnityEngine;

public class MousePoseFollow : MonoBehaviour
{
    public float zAtGrab;
    public float zOfScreen;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // Calculate the target position based on the mouse position
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, zOfScreen));// + offset;
            //targetPosition.z = zAtGrab;

            transform.position = targetPosition;
        }
    }

}