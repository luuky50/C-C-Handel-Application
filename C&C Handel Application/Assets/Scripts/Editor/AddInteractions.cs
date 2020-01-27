using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInteractions : MonoBehaviour
{
    EventBaseClass baseClass;

    private void OnEnable()
    {
        baseClass = GetComponent<EventBaseClass>();

        baseClass.AddMediaInteraction += baseClass_AddMediaInteraciton;
    }

    public void baseClass_AddMediaInteraciton()
    {

    }
}
