using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    List<LevelClass> allLevels = new List<LevelClass>();
    int currentQuestionIndex = 0;
    int currentMediaIndex;
    LevelClass newLevel;
    int CurrentSceneIndex;

    private void Start()
    {
        MakeNewLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakeNewDataInstanceForScene();
            AddDataInstanceForInteractable();
            SetDataOfNewInteractable();
        }
    }
    public void MakeNewLevel()
    {
        newLevel = new LevelClass();
        CurrentSceneIndex = 0;            
    }

    public void SetCurrentIndex(int _currentSceneIndex)
    {
        CurrentSceneIndex = _currentSceneIndex;
    }

    public void MakeNewDataInstanceForScene()
    {
        //if param is 0
        newLevel._Scene.Add(new SceneInLevel());
        CurrentSceneIndex = newLevel._Scene.Count - 1;
    }

    public void AddDataInstanceForInteractable()
    {
        //if param is 0
        newLevel._Scene[CurrentSceneIndex].allQuestionsOfScene.Add(new QuestionInteractable());
    }

    public void SetDataOfNewInteractable()
    {
        newLevel._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].Question = "Test";
        newLevel._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].AnswerOne = "Ans1";
    }
}
