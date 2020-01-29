using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    EventBaseClass baseClass;
    public InstantiateInteractable _instantiateClass;
    public UIManager _UIManager;

    private void OnEnable()
    {
        baseClass = GetComponent<EventBaseClass>();

        baseClass.AddQuestioInteraction += baseClass_AddQuestionInteraciton;
        baseClass.IsPlacingObj += baseClass_IsPlacingObj;
        baseClass.GoToNormalState += baseClass_GoToNormalView;
        baseClass.GoToDraggingState += baseClass_GoToDraggingState;
    }

    public void baseClass_AddQuestionInteraciton()
    {
        _instantiateClass.instantiateInteraction();
        _instantiateClass.SetPositionOfNewObj();
    }

    public void baseClass_IsPlacingObj()
    {
        _UIManager.ActivatePlacingUI();
        _instantiateClass.changeIsPlacing();
    }

    public void baseClass_GoToNormalView()
    {
        _UIManager.ActivateNormalUI();
        _instantiateClass.SetNormalStateBooleans();
    }

    public void baseClass_GoToDraggingState()
    {
        _instantiateClass.changeIsDragging();
        _UIManager.ActivateDraggingUI();
    }
}
