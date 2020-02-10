using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectDataManager : MonoBehaviour
{
    private List<ProjectClass> allLevels = new List<ProjectClass>();
    public int currentQuestionIndex = 0;
    int currentMediaIndex;
    private ProjectClass newProject;
    public int CurrentSceneIndex;
    public UIManager _UIManager;
    public List<Toggle> goodAnsSwitches = new List<Toggle>();
    // public Material materialOnSphere;
    public InteractableHandler interactableHandler;
    public Material materialOnSphere;
    internal ProjectClass NewProject { get => newProject; set => newProject = value; }
    internal List<ProjectClass> AllLevels { get => allLevels; set => allLevels = value; }

    public void LoadProjectScene(int Scene)
    {
        foreach (GameObject Item in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(Item);
        }

        foreach (QuestionInteractable item in newProject._Scene[CurrentSceneIndex].allQuestionsOfScene)
        {
            Debug.Log(interactableHandler.Interactables[0]);
            GameObject newObj = Instantiate(interactableHandler.Interactables[0], item.positionInteractable, Quaternion.identity);
            newObj.transform.parent = interactableHandler.world.transform;
        }
    }
    public void Get360ImageForCurrentScene()
    {
           materialOnSphere.mainTexture = NewProject._Scene[CurrentSceneIndex]._360Image;
    }

    public void Set360ImageForCurrentScene(Texture2D material)
    {
             NewProject._Scene[CurrentSceneIndex]._360Image = material;
    }

    private void Start()
    {
        //   MakeNewProject();
        //    _UIManager = GetComponent<UIManager>();
    }
    public void ChangeSceneIndex(int dir)
    {
        if (dir == 0)
        {
            CurrentSceneIndex--;
        }
        else
        {
            CurrentSceneIndex++;
        }
    }
    public void MakeNewProject()
    {
        CurrentSceneIndex = 0;
        NewProject = new ProjectClass();
    }

    public void SetCurrentIndex(int _currentSceneIndex)
    {
        CurrentSceneIndex = _currentSceneIndex;
    }

    public void MakeNewDataInstanceForScene()
    {
        //if param is 0
        NewProject._Scene.Add(new SceneInProject());
        //  CurrentSceneIndex = NewProject._Scene.Count - 1;
    }

    public void AddDataInstanceForInteractable()
    {
        //if param is 0
        // Debug.Log(NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene);
        Debug.Log(CurrentSceneIndex);
        int currentIndex = NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene.Count;
        NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene.Add(new QuestionInteractable());
        foreach (Toggle item in goodAnsSwitches)
        {
            Debug.Log(currentIndex);
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
                //   Debug.Log(NewProject._Scene[CurrentSceneIndex].allQuestionsOfScene[currentQuestionIndex].goodAnswers[i]);
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
