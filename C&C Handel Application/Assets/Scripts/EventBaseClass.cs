using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBaseClass : MonoBehaviour
{
    public delegate void EventHandler();

    public event EventHandler AddQuestioInteraction;
    public event EventHandler IsPlacingObj;
    public event EventHandler GoToNormalState;
    public event EventHandler GoToDraggingState;
    public event EventHandler MakeNewProject;
    public event EventHandler CompleteQuestionInteraction;
    public event EventHandler EditQuestion;
    public event EventHandler LoadScene;

    public void CallEventLoadScene()
    {
        LoadScene?.Invoke();
    }

    public void CallEventEditQuestion()
    {
        EditQuestion?.Invoke();
    }

    public void CallEventCompleteQuestionInteraction()
    {
        CompleteQuestionInteraction?.Invoke();
    }

    public void CallEventMakeNewProject()
    {
        MakeNewProject?.Invoke();
    }

    public void CallEventAddQuestionInteraction()
    {
        AddQuestioInteraction?.Invoke();
    }

    public void CallEventIsPlacingObj()
    {
        IsPlacingObj?.Invoke();
    }

    public void CallEventGoToNormalState()
    {
        GoToNormalState?.Invoke();
    }

    public void CallEventGoToDraggingState()
    {
        GoToDraggingState?.Invoke();
    }
}
