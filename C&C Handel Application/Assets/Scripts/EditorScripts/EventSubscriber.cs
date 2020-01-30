using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    EventBaseClass baseClass;
    public InstantiateInteractable _instantiateClass;
    public UIManager _UIManager;
    public LevelDataManager dataManager;

    private void OnEnable()
    {
        baseClass = GetComponent<EventBaseClass>();

        baseClass.AddQuestioInteraction += baseClass_AddQuestionInteraction;
        baseClass.IsPlacingObj += baseClass_IsPlacingObj;
        baseClass.GoToNormalState += baseClass_GoToNormalView;
        baseClass.GoToDraggingState += baseClass_GoToDraggingState;
    }

    public void baseClass_AddQuestionInteraction()
    {
        _instantiateClass.instantiateInteraction();
        _instantiateClass.SetPositionOfNewObj();


        //TEMP
        dataManager.MakeNewLevel();
        dataManager.MakeNewDataInstanceForScene();
        //TEMP


        dataManager.AddDataInstanceForInteractable();
        dataManager.SetDataOfNewInteractable(1);

        _UIManager.OpenQuestion();
    }

    public void baseClass_CompleteQuestionInteraction()
    {
        dataManager.SetDataOfNewInteractable(1);
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
