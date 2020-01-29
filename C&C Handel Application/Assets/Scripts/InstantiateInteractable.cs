using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateInteractable : MonoBehaviour
{
    public UIManager _UIManager;
    public EventBaseClass eventBase;
    public PlayerManager playerManager;
    Camera mainCamera;
    GameObject newObj;
    public GameObject world;
    public bool isPlacing;
    public GameObject[] Interactables;
    public bool isDragging;
    void Start()
    {
        mainCamera = Camera.main;
        isPlacing = false;
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                eventBase.CallEventAddQuestionInteraction();
            }
        }

        if (isDragging)
        {
            Debug.Log(isDragging);
            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 1000), out RaycastHit hitInfo))
                {
                    if (hitInfo.transform.tag == "Interactable")
                    {
                        hitInfo.transform.gameObject.SetActive(false);
                        if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 1000), out RaycastHit hitInfo2))
                        {
                            if (hitInfo2.transform.tag == "World")
                            {
                                hitInfo.transform.position = hitInfo2.point;
                                hitInfo.transform.gameObject.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }

    public void SetNormalStateBooleans()
    {
        isPlacing = false;
        isDragging = false;
    }

    public void changeIsPlacing()
    {
        isPlacing = !isPlacing;
    }

    public void changeIsDragging()
    {
        isDragging = !isDragging;
    }

    public void instantiateInteraction()
    {
        newObj = Instantiate(Interactables[0]);
        newObj.transform.parent = world.transform;
    }

    public void SetPositionOfNewObj()
    {
        if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 10000), out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.point);
            if (hitInfo.transform.tag == "World")
            {
                newObj.transform.position = hitInfo.point;
            }
            eventBase.CallEventGoToNormalState();
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
