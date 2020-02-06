using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexInformation : MonoBehaviour
{
    ProjectDataManager levelData;
    InteractableHandler interactableHandler;
    public int indexOfThisObject;
    public void SetIndexOfThisObj()
    {
        levelData = GameObject.Find("EditorManager").GetComponent<ProjectDataManager>();
        interactableHandler = GameObject.Find("EditorManager").GetComponent<InteractableHandler>();
        indexOfThisObject = levelData.NewProject._Scene[levelData.CurrentSceneIndex].allQuestionsOfScene.Count - 1;
        interactableHandler.SetCurrentQuestionIndexWhenNewObjInstantiated(indexOfThisObject);
        
    }
}
