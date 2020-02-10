using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AbstractFactory
{


    public interface CreateTestProject
    {
        IAbstractProductA CreateTestProduct_();
    }

    class ProjectFactory : CreateTestProject
    {
        public IAbstractProductA CreateTestProduct_()
        {
            return new ProjectA1();
        }
    }

    public interface IAbstractProductA
    {
        string GetProjectName(string refernceInput);

        string GetProjectDescriptie(string refernce_Input);
    }

    class ProjectA1 : IAbstractProductA
    {
        //string projectName;
        //string projectDescriptie;
        public string GetProjectName(string referenceInput)
        {
            return referenceInput;
        }
        public string GetProjectDescriptie(string refernce_Input)
        {
            return refernce_Input;
        }
    }

    public class AbstractProject : MonoBehaviour
    {
        [SerializeField]
        private InputField inputField;

        [SerializeField]
        private InputField descriptionField;

        
        public void GenerateProject()
        {   
            new Client().Main(inputField.text, descriptionField.text);
            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            yield return null;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
            while (!asyncOperation.isDone)
            {
                Debug.Log("Loading.....");
                yield return null;
            }
        }
    }

    class Client
    {
        public void Main(string input1, string description2)
        {
            // The client code can work with any concrete factory class.
            Debug.Log("Client: Testing client code with the first factory type...");
            ClientMethod(new ProjectFactory(), input1, description2);
        }

        public void ClientMethod(ProjectFactory factory, string input1, string description2)
        {
            var productA = factory.CreateTestProduct_();
            //var productB = factory.CreateProductB();
            productA.GetProjectName(input1);
            productA.GetProjectDescriptie(description2);

            Debug.Log(productA.GetProjectName(input1));
            Debug.Log(productA.GetProjectDescriptie(description2));

            

            //Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }
}