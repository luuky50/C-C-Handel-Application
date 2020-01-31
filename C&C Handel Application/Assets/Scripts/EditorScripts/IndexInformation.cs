using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexInformation : MonoBehaviour
{
    LevelDataManager levelData;
    InteractableHandler interactableHandler;
    public int indexOfThisObject;
    public void SetIndexOfThisObj()
    {
        levelData = GameObject.Find("EditorManager").GetComponent<LevelDataManager>();
        interactableHandler = GameObject.Find("EditorManager").GetComponent<InteractableHandler>();
        indexOfThisObject = levelData.NewProject._Scene[levelData.CurrentSceneIndex].allQuestionsOfScene.Count - 1;
        Debug.Log(indexOfThisObject + " index of this obj in obj");
        interactableHandler.SetCurrentQuestionIndexWhenNewObjInstantiated(indexOfThisObject);
        
    }
}
