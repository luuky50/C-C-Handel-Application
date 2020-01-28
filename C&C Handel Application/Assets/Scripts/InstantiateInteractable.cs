using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateInteractable : MonoBehaviour
{
   public PlayerManager playerManager;
    Camera mainCamera;
    public GameObject test;
    GameObject newObj;
    public GameObject world;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.isDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                newObj = Instantiate(test);
                newObj.transform.parent = world.transform;
            }

            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 10000), out RaycastHit hitInfo))
                {
                    Debug.Log("mous");
                    Debug.Log(hitInfo.point);
                    if (hitInfo.transform.tag == "World")
                    {
                        newObj.transform.position = hitInfo.point;
                    }
                }
            }
        }
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
