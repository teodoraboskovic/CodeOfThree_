using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private float speed;
    private float currentPosition;
    private Vector3 velocity =Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosition, transform.position.y, transform.position.z), ref velocity, speed);
    }
    public void moveToNewRoom(Transform _newRoom)
    {
        currentPosition = _newRoom.position.x;
    }
}
