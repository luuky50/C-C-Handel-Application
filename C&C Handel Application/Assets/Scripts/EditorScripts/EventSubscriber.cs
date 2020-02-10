using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    EventBaseClass baseClass;
    public InteractableHandler _InteractableHandler;
    public UIManager _UIManager;
    public ProjectDataManager dataManager;

    private void OnEnable()
    {
        baseClass = GetComponent<EventBaseClass>();

        baseClass.AddQuestioInteraction += baseClass_AddQuestionInteraction;
        baseClass.IsPlacingObj += baseClass_GoToPlacingView;
        baseClass.GoToNormalState += baseClass_GoToNormalView;
        baseClass.GoToDraggingState += baseClass_GoToDraggingState;
        baseClass.MakeNewProject += baseClass_MakeNewProject;
        baseClass.CompleteQuestionInteraction += baseClass_CompleteQuestionInteraction;
        baseClass.EditQuestion += baseClass_EditQuestion;
        baseClass.LoadScene += baseClass_LoadScene;
    }

    private void Update()
    {
        Debug.Log("current scene " + dataManager.CurrentSceneIndex);
    }

    private void baseClass_LoadScene()
    {
        Debug.Log(dataManager.CurrentSceneIndex + " " + dataManager.NewProject._Scene.Count);
        if (dataManager.CurrentSceneIndex > dataManager.NewProject._Scene.Count - 1)
        {

            _UIManager.openNewScenePanel();
            dataManager.MakeNewDataInstanceForScene();
        }
        Debug.Log(dataManager.CurrentSceneIndex + "rigtht after");
        dataManager.LoadProjectScene(dataManager.CurrentSceneIndex);
        _UIManager.SetCurrentSceneText();
    }

    public void baseClass_EditQuestion()
    {
        dataManager.GetDataOfGivenInteractable(dataManager.currentQuestionIndex);
        _InteractableHandler.changeCanPlace(false);
        _InteractableHandler.changeIsEditingInteractable(true);
        _UIManager.OpenQuestion();
        _UIManager.EditorPanel.SetActive(false);
    }

    public void baseClass_MakeNewProject()
    {
        dataManager.MakeNewProject();
        dataManager.MakeNewDataInstanceForScene();
    }

    public void baseClass_AddQuestionInteraction()
    {
        dataManager.AddDataInstanceForInteractable();
        _InteractableHandler.instantiateInteraction();
        _InteractableHandler.SetPositionOfNewObj();
    }

    public void baseClass_CompleteQuestionInteraction()
    {
        _InteractableHandler.changeCanPlace(true);
        dataManager.SetDataOfNewInteractable(0);

        _InteractableHandler.changeIsEditingInteractable(false);
        _UIManager.CloseQuestion();
        if (_InteractableHandler.isInNormalView)
        {
            _UIManager.ActivateNormalUI();
        }
    }

    public void baseClass_GoToPlacingView()
    {
        _UIManager.ActivatePlacingUI();
        _InteractableHandler.changeCanPlace(true);
        _InteractableHandler.isInNormalView = false;
    }

    public void baseClass_GoToNormalView()
    {
        _UIManager.ActivateNormalUI();
        _InteractableHandler.SetNormalStateBooleans();
        _InteractableHandler.EnablePlayerManager();
        _InteractableHandler.changeIsDragging(false);
        _InteractableHandler.changeIsPlacing(false);
        _InteractableHandler.changeCanPlace(false);
        _InteractableHandler.isInNormalView = true;
    }

    public void baseClass_GoToDraggingState()
    {
        _InteractableHandler.changeIsDragging(true);
        _UIManager.ActivateDraggingUI();
    }
}
