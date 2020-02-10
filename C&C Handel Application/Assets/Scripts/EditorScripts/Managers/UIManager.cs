using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject ItemsPanel;
    public GameObject PlaceYourItem;
    public GameObject DragAnItemButton;
    public GameObject ActivateNormalViewButton;
    public GameObject MakeQuestionPanel;

    public GameObject EditorPanel;
    public GameObject MakeNewScenePanel;

    public ProjectDataManager projectData;

    public Text currentSceneText;
    public void ActivatePlacingUI()
    {
        PlaceYourItem.SetActive(true);
        ActivateNormalViewButton.SetActive(true);

        EditorPanel.SetActive(false);
    }

    public void ActivateNormalUI()
    {
        PlaceYourItem.SetActive(false);
        ActivateNormalViewButton.SetActive(false);

        EditorPanel.SetActive(true);
    }

    public void ActivateDraggingUI()
    {
        EditorPanel.SetActive(false);
        ActivateNormalViewButton.SetActive(true);
    }

    public void OpenQuestion()
    {
        MakeQuestionPanel.SetActive(true);
        ActivateNormalViewButton.SetActive(false);
    }

    public void CloseQuestion()
    {
        MakeQuestionPanel.SetActive(false);
        ActivateNormalViewButton.SetActive(true);
    }

    public void openNewScenePanel()
    {
        MakeNewScenePanel.SetActive(true);
    }

    public void closwNewScenePanel()
    {
        MakeNewScenePanel.SetActive(false);
    }

    public void SetCurrentSceneText()
    {
        currentSceneText.text = projectData.CurrentSceneIndex + 1.ToString();
    }
}
