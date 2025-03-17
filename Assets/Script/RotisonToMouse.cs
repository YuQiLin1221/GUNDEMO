using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotisonToMouse : MonoBehaviour
{
    public Camera cam;
    public float maximumLeght;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousepos = Input.mousePosition;
                rayMouse = cam.ScreenPointToRay(mousepos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLeght))
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint (maximumLeght);
                RotateToMouseDirection (gameObject, pos);
            }
        }
        else
        {
            Debug.Log("No camera");
        }
    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);

    }

    public Quaternion getRotation()
    {
        return rotation;
    }
}
