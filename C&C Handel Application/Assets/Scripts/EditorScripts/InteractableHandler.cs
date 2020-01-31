using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHandler : MonoBehaviour
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
    public bool isEditingInteratable;
    //public int interactableIndex;
    public LevelDataManager levelDataManager;


    void Start()
    {
        mainCamera = Camera.main;
        isPlacing = false;
        isDragging = false;
        isEditingInteratable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(isDragging + " dragging");
        //    Debug.Log(isPlacing + " placing");
        //    Debug.Log(isEditingInteratable +" Edit");
        if (!isDragging && !isEditingInteratable)
        {
            if (Input.GetMouseButton(0))
            {
                //      Debug.Log("Edit This Question");
                if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 10000), out RaycastHit hitInfo))
                {
                    if (hitInfo.transform.tag == "Interactable")
                    {
                        //   Debug.Log(hitInfo.transform.GetComponent<IndexInformation>().indexOfThisObject + " index of this object");
                        levelDataManager.currentQuestionIndex = hitInfo.transform.GetComponent<IndexInformation>().indexOfThisObject;
                        eventBase.CallEventEditQuestion();
                    }
                }
            }
        }

        if (isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 10000), out RaycastHit hitInfo))
                {
                    if (hitInfo.transform.tag == "World")
                    {
                        eventBase.CallEventAddQuestionInteraction();
                        //      interactableIndex = hitInfo.transform.GetComponent<IndexInformation>();
                        //Debug.Log(hitInfo.transform.GetComponent<IndexInformation>());
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            eventBase.CallEventMakeNewProject();
        }

        // Debug.Log(newObj.transform.GetComponent<IndexInformation>().indexOfThisObject + " index after instantiation ");

        if (isDragging)
        {
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

    public void changeIsEditingInteractable()
    {
        isEditingInteratable = !isEditingInteratable;
    }

    public void changeIsPlacing()
    {
        isPlacing = !isPlacing;
    }

    public void changeIsDragging()
    {
        isDragging = !isDragging;
        //  Debug.Log("draggingvoid");
    }

    public void instantiateInteraction()
    {
        newObj = Instantiate(Interactables[0]);
        newObj.transform.parent = world.transform;
        newObj.transform.GetComponent<IndexInformation>().SetIndexOfThisObj();
    }
    public void SetCurrentQuestionIndexWhenNewObjInstantiated(int IndexFromTheScriptOnThePrefab)
    {
        levelDataManager.currentQuestionIndex = IndexFromTheScriptOnThePrefab;
        //  Debug.Break();
        newObj.transform.name = "deze is de current" + IndexFromTheScriptOnThePrefab;
        Debug.Log(IndexFromTheScriptOnThePrefab + " indexfromscriptafterprefab ");
        // newObj.SetActive(false);

    }
    public void SetPositionOfNewObj()
    {
        if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 10000), out RaycastHit hitInfo))
        {
            if (hitInfo.transform.tag == "World")
            {
                 newObj.transform.position = hitInfo.point;
            }
        }
        //    Debug.Log("make a Question");

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
