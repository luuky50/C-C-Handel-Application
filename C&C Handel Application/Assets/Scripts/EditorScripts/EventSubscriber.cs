using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    EventBaseClass baseClass;
    public InteractableHandler _InteractableHandler;
    public UIManager _UIManager;
    public LevelDataManager dataManager;

    private void OnEnable()
    {
        baseClass = GetComponent<EventBaseClass>();

        baseClass.AddQuestioInteraction += baseClass_AddQuestionInteraction;
        baseClass.IsPlacingObj += baseClass_IsPlacingObj;
        baseClass.GoToNormalState += baseClass_GoToNormalView;
        baseClass.GoToDraggingState += baseClass_GoToDraggingState;
        baseClass.MakeNewProject += baseClass_MakeNewProject;
        baseClass.CompleteQuestionInteraction += baseClass_CompleteQuestionInteraction;
        baseClass.EditQuestion += baseClass_EditQuestion;
    }

    public void baseClass_EditQuestion()
    {
        dataManager.GetDataOfGivenInteractable(dataManager.currentQuestionIndex);
        _InteractableHandler.changeIsPlacing();
        _InteractableHandler.changeIsEditingInteractable();
        _UIManager.OpenQuestion();
    }

    public void baseClass_MakeNewProject()
    {
        dataManager.MakeNewProject();
        dataManager.MakeNewDataInstanceForScene();
    }

    public void baseClass_AddQuestionInteraction()
    {
        _InteractableHandler.changeIsEditingInteractable();

        _InteractableHandler.changeIsPlacing();


        dataManager.AddDataInstanceForInteractable();
        _InteractableHandler.instantiateInteraction();
        _InteractableHandler.SetPositionOfNewObj();

        _UIManager.OpenQuestion();
    }

    public void baseClass_CompleteQuestionInteraction()
    {
        _InteractableHandler.changeIsPlacing();

        dataManager.SetDataOfNewInteractable(dataManager.currentQuestionIndex);

        _UIManager.CloseQuestion();
        _InteractableHandler.changeIsEditingInteractable();

    }

    public void baseClass_IsPlacingObj()
    {
        _UIManager.ActivatePlacingUI();
        _InteractableHandler.changeIsPlacing();
    }

    public void baseClass_GoToNormalView()
    {
        _UIManager.ActivateNormalUI();
        _InteractableHandler.SetNormalStateBooleans();
    }

    public void baseClass_GoToDraggingState()
    {
        _InteractableHandler.changeIsDragging();
        _UIManager.ActivateDraggingUI();
    }
}
