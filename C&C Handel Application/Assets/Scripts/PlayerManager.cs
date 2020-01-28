using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    float horizontal;
    float vertical;

    [SerializeField]
    Transform container;

    [SerializeField]
    float turnSpeedMouse;

    [SerializeField]
    private GameObject questionObject;

    public bool isDragging;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDragging = !isDragging;
        }
        if (!isDragging)
        {
            horizontal = Input.GetAxis("Mouse X");
            vertical = Input.GetAxis("Mouse Y");

            if (Input.GetMouseButton(0))
            {
                container.Rotate(new Vector3(0, horizontal * (1), 0f) * Time.deltaTime * turnSpeedMouse);
                transform.Rotate(new Vector3(vertical, 0, 0) * Time.deltaTime * turnSpeedMouse);
            }
        }
    }

    private void PlaceObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(questionObject, new Vector3(Camera.current.pixelRect.center, 9, 9) )

        }

    }




}