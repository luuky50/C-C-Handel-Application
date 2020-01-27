using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBaseClass : MonoBehaviour
{
    public delegate void EventHandler();

    public event EventHandler AddMediaInteraction;
    public void CallEventAddMediaInteraction()
    {
        AddMediaInteraction?.Invoke();
    }
}
