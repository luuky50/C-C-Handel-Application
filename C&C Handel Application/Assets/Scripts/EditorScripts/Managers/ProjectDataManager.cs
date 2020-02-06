using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectDataManager : MonoBehaviour
{
    List<ProjectClass> allLevels = new List<ProjectClass>();
    public int currentQuestionIndex = 0;
    int currentMediaIndex;
    private ProjectClass newProject;
    public int CurrentSceneIndex;
    UIManager _UIManager;
    public List<Toggle> goodAnsSwitches = new List<Toggle>();

    internal ProjectClass NewProject { get => newProject; set => newProject = value; }

    public void LoadProjectScene(int Scene)
    {
        foreach (GameObject Item in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(Item);
        }
    }

    public void Set360ImageForCurrentScene(Texture2D material)
    {
     //   NewProject._Scene[CurrentSceneIndex]._360Image = material;
    }

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
        int currentIndex = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene.Count;
        NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene.Add(new QuestionInteractable());
        foreach(Toggle item in goodAnsSwitches)
        {
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentIndex].goodAnswers.Add(item.isOn);
        }
    }

    public void SetDataOfNewInteractable(int param)
    {
        if (param == 0)
        {
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].Question = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Question").GetComponent<InputField>().text;
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].AnswerOne = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans1").GetComponent<InputField>().text;
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].AnswerTwo = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans2").GetComponent<InputField>().text;
            NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].AnswerThree = _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans3").GetComponent<InputField>().text;
            int i = 0;
            foreach (Toggle item in goodAnsSwitches)
            {
                NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].goodAnswers[i] = item.isOn;
                Debug.Log(NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].goodAnswers[i]);
                i++;
            }


        }
    }

    public void GetDataOfGivenInteractable(int videoIndex)
    {
        if (NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].goodAnswers.Count == 3)
        {
            int i = 0;
            foreach (Toggle item in goodAnsSwitches)
            {
                Debug.Log(NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].goodAnswers[i]);
                item.isOn = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].goodAnswers[i];
                i++;
            }
        }

        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Question").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].Question;
        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans1").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].AnswerOne;
        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans2").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].AnswerTwo;
        _UIManager.MakeQuestionPanel.gameObject.transform.Find("Ans3").GetComponent<InputField>().text = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[videoIndex].AnswerThree;
    }

}
