using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDataManager : MonoBehaviour
{
    List<ProjectClass> allLevels = new List<ProjectClass>();
   public int currentQuestionIndex = 0;
    int currentMediaIndex;
    private ProjectClass newProject;
    public int CurrentSceneIndex;
    UIManager _UIManager;

    internal ProjectClass NewProject { get => newProject; set => newProject = value; }

    private void Start()
    {
        MakeNewProject();
        _UIManager = GetComponent<UIManager>();
    }

    public void MakeNewProject()
    {
        NewProject = new ProjectClass();
        CurrentSceneIndex = 0;
    }

    public void SetCurrentIndex(int _currentSceneIndex)
    {
        CurrentSceneIndex = _currentSceneIndex;
    }

    public void MakeNewDataInstanceForScene()
    {
        //if param is 0
        NewProject._Scene.Add(new SceneInProject());
        CurrentSceneIndex = NewProject._Scene.Count - 1;
    }

    public void AddDataInstanceForInteractable()
    {
        //if param is 0
        NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene.Add(new QuestionInteractable());
    }
    private void Update()
    {
        Debug.Log(currentQuestionIndex + " current que index");
    }
    public void SetDataOfNewInteractable(int param)
    {
        if (param == 0)
        {
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].Question = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Question").GetComponent<InputField>().text;
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].AnswerOne = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans1").GetComponent<InputField>().text;
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].AnswerTwo = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans2").GetComponent<InputField>().text;
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].AnswerThree = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans3").GetComponent<InputField>().text;
        }
        Debug.Log(currentQuestionIndex + " questionindex direct after");
        Debug.Log(NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].Question+  " Direct after");
    } 

    public void GetDataOfGivenInteractable(int videoIndex)
    {
        Debug.Log(videoIndex + " videoindex");
        Debug.Log(NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].Question + " question");
        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Question").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].Question;
        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans1").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].AnswerOne;
        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans2").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].AnswerTwo;
        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans3").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].AnswerThree;
    }

}
