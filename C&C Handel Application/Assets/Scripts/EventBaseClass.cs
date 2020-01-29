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
