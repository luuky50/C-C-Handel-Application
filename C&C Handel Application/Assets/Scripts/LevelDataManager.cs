using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    List<LevelClass> allLevels = new List<LevelClass>();
    int currentQuestionIndex;
    int currentMediaIndex;
    LevelClass newLevel;
    public void MakeNewLevel()
    {
        newLevel = new LevelClass();
    }

    public void MakeNewDataInstanceForInteractable()
    {

    }

    public void SetDataOfNewInteractable()
    {
        newLevel._Scene[currentQuestionIndex].allQuestionsOfScene[currentQuestionIndex].Question = "Test";
        newLevel._Scene[currentQuestionIndex].allQuestionsOfScene[currentQuestionIndex].AnswerOne = "Ans1";
    }
}
