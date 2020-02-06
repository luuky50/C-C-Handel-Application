using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHandler : MonoBehaviour
{
    public UIManager _UIManager;
    public EventBaseClass eventBase;
    public PlayerManager playerManager;
    public LevelDataManager levelDataManager;
    private GameObject newObj;
    [HideInInspector] public bool isInPlacingView;
    [HideInInspector] public bool isEditingInteratable;
    [HideInInspector] public bool isInDraggingState;
    public bool canPlace;
    private bool mouseOneClick = false;
    [SerializeField] private GameObject world;
    [SerializeField] private GameObject[] Interactables;
    private Camera mainCamera;
    private float timer;
    private float mouseClickInterval;
  GameObject  m_currenSelectedInteractable;
    bool isDraggingObj;
    public bool isInNormalView;

    private void Start()
    {
        mouseClickInterval = 0.5f;
        mainCamera = Camera.main;
        isInPlacingView = false;
        isInDraggingState = false;
        isEditingInteratable = false;
        //    m_cameraRigidbody = mainCamera.transform.GetComponent<Rigidbody>();
    //    eventBase.CallEventMakeNewProject();

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            mouseOneClick = false;
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (!mouseOneClick)
            {
                timer = mouseClickInterval;
                mouseOneClick = true;
            }
            else if (mouseOneClick && timer > 0)
            {
                checkRayCast();
                mouseOneClick = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            eventBase.CallEventMakeNewProject();
        }

        if (isDraggingObj)
        {
            if (Input.GetMouseButton(0))
            {
                playerManager.enabled = false;

                m_currenSelectedInteractable.SetActive(false);
                if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 1000), out RaycastHit hitInfo2))
                {
                    if (hitInfo2.transform.tag == "World")
                    {
                        m_currenSelectedInteractable.transform.position = hitInfo2.point;
                        m_currenSelectedInteractable.transform.gameObject.SetActive(true);

                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                playerManager.enabled = true;
                isDraggingObj = false;
            }
        }
    }

    public void EnablePlayerManager()
    {
        playerManager.enabled = true;
    }

    private void checkRayCast()
    {
        if (Physics.Raycast(mainCamera.transform.position, GetWorldPositionOnPlane(Input.mousePosition, 10000), out RaycastHit hitInfo))
        {
            if (canPlace)
            {
                if (hitInfo.transform.tag == "World")
                {
                    eventBase.CallEventAddQuestionInteraction();

                    return;
                }
            }

            if (!isInDraggingState && !isEditingInteratable)
            {
                if (hitInfo.transform.tag == "Interactable")
                {
                    levelDataManager.currentQuestionIndex = hitInfo.transform.GetComponent<IndexInformation>().indexOfThisObject;
                    eventBase.CallEventEditQuestion();

                    return;
                }
            }
            if (isInDraggingState)
            {
                if (hitInfo.transform.tag == "Interactable")
                {
                    m_currenSelectedInteractable = hitInfo.transform.gameObject;
                    m_currenSelectedInteractable.SetActive(false);
                    isDraggingObj = true;
                }
            }
        }
    }

    public void changeCanPlace(bool value)
    {
        canPlace = value;
    }

    public void SetNormalStateBooleans()
    {
        isInPlacingView = false;
        isInDraggingState = false;
    }

    public void changeIsEditingInteractable(bool value)
    {
        isEditingInteratable = value;
    }

    public void changeIsPlacing(bool value)
    {
        isInPlacingView = value;
    }

    public void changeIsDragging(bool value)
    {
        isInDraggingState = value;
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
        newObj.transform.name = "deze is de current" + IndexFromTheScriptOnThePrefab;
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
