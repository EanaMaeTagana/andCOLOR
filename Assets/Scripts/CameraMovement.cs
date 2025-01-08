using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float FollowSpeed = 2f; // speed of camera
    public Transform target; // the target which the camera follows

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y,-10f); // calculates the new position based on the player
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime); // smoothly moves the camera to new position
    }
}