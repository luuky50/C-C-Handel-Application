using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject ItemsPanel;
    public GameObject PlaceYourItem;
    public GameObject ExitDraggingButton;
    public GameObject DragAnItem;
    public GameObject ActiveDraggingState;
    
    public void ActivatePlacingUI()
    {
        ItemsPanel.SetActive(false);
        PlaceYourItem.SetActive(true);
    }

    public void ActivateNormalUI()
    {
        ItemsPanel.SetActive(true);
        PlaceYourItem.SetActive(false);
        ExitDraggingButton.SetActive(false);
        DragAnItem.SetActive(false);
        ActiveDraggingState.SetActive(true);

    }

    public void ActivateDraggingUI()
    {
        ItemsPanel.SetActive(false);
        ExitDraggingButton.SetActive(true);
        DragAnItem.SetActive(true);
        ActiveDraggingState.SetActive(false);
    }
}
