using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        string GetProjectDescriptie();
    }

    class ProjectA1 : IAbstractProductA
    {
        string projectName;
        string projectDescriptie;
        public string GetProjectName(string referenceInput)
        {
            return referenceInput;
        }
        public string GetProjectDescriptie()
        {
            Debug.Log("dfsdf");
            return this.projectDescriptie;
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
            description2 = productA.GetProjectDescriptie();

            Debug.Log(productA.GetProjectName(input1));
            Debug.Log(productA.GetProjectDescriptie());
            //Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }
}