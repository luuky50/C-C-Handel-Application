using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    #region variables
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject cofPassword;

    private string Username;
    private string Email;
    private string Password;
    private string CofPassword;

    private string form;

    private bool emailValid = false;

    public string filePath = "C:/Users/Gebruiker/Desktop/Users/";

    private string[] Characters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                                    "1","2","3","4","5","6","7","8","9","0","_","-" };
    #endregion

    #region Warning variables
    public GameObject Empty_Username;
    public GameObject Empty_Email;
    public GameObject Empty_Password;
    public GameObject Empty_ConfPassword;

    public GameObject Taken_Username;

    public GameObject Incorrect_Email;

    public GameObject SixCharacters_Password;

    public GameObject NoMatch_Password;

    public GameObject RegistrationComplete;
    #endregion

    private void Awake()
    {
        Empty_Username.SetActive(false);
        Empty_Email.SetActive(false);
        Empty_Password.SetActive(false);
        Empty_ConfPassword.SetActive(false);
        Taken_Username.SetActive(false);
        Incorrect_Email.SetActive(false);
        SixCharacters_Password.SetActive(false);
        NoMatch_Password.SetActive(false);
        RegistrationComplete.SetActive(false);
    }


    private void Update()
    {
        TabFunction();
        InputFuction();
    }

    void TabFunction()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
            if (username.GetComponent<InputField>().isFocused)
                email.GetComponent<InputField>().Select();

        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
            if (email.GetComponent<InputField>().isFocused)
                password.GetComponent<InputField>().Select();

        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
            if (password.GetComponent<InputField>().isFocused)
                cofPassword.GetComponent<InputField>().Select();


    }

    void InputFuction()
    {
        //alle info moet eerst ingevuld worden voordat die door kan naar RegisterButton 
        if (Input.GetKeyDown(KeyCode.Return))
            if (Password != "" && Email != "" && Password != "" && CofPassword != "")
                RegisterButton();

        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        CofPassword = cofPassword.GetComponent<InputField>().text;
    }

    public void RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;



        Empty_Username.SetActive(false);
        Empty_Email.SetActive(false);
        Empty_Password.SetActive(false);
        Empty_ConfPassword.SetActive(false);
        Taken_Username.SetActive(false);
        Incorrect_Email.SetActive(false);
        SixCharacters_Password.SetActive(false);
        NoMatch_Password.SetActive(false);


        if (Username != "")
        {
            //mensen kunnen niet dezelfde username hebben
            if (!System.IO.File.Exists(@filePath + Username + ".txt"))
            {
                UN = true;
            }
            else
            {
                Debug.LogWarning("Username Taken");
                Taken_Username.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Username Field Empty");
            Empty_Username.SetActive(true);
        }
        //checkt of het een email is doormiddel van een | @ . |
        if (Email != "")
        {
            EmailValidation();
            if (emailValid)
            {
                if (Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        EM = true;
                    }
                    else
                    {
                        Debug.LogWarning("Email is Incorrect");
                        Incorrect_Email.SetActive(true);
                    }
                }
                else
                {
                    Debug.LogWarning("Email is Incorrect");
                    Incorrect_Email.SetActive(true);
                }
            }
            else
            {
                Debug.LogWarning("Email is Incorrect");
                Incorrect_Email.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Email Field Empty");
            Empty_Email.SetActive(true);
        }

        if (Password != "")
        {
            if (Password.Length > 5)
            {
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password must be atleast 6 charachters long");
                SixCharacters_Password.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Password Field Empty");
            Empty_Password.SetActive(true);
        }

        if (CofPassword != "")
        {
            //checkt of het wachtwoord het zelfde is als de configuration wachtwoord
            if (CofPassword == Password)
            {
                CPW = true;
            }
            else
            {
                Debug.LogWarning("Password Don't Match");
                NoMatch_Password.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Confirm Password Field Empty");
            Empty_ConfPassword.SetActive(true);
        }


        if (UN == true && EM == true && PW == true && CPW == true)
        {
            bool Clear = true;
            int i = 1;

            //encrypt
            foreach (char c in Password)
            {
                if (Clear)
                {
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                Password += Encrypted.ToString();
            }
            form = (Username + "\n" + Email + "\n" + Password);
            System.IO.File.WriteAllText(@filePath + Username + ".txt", form);

            //reset de input field naar niets
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            cofPassword.GetComponent<InputField>().text = "";
            Debug.Log("Registration Complete");
            RegistrationComplete.SetActive(true);
        }


    }

    void EmailValidation()
    {
        bool SW = false;
        bool EW = false;
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.StartsWith(Characters[i]))
            {
                SW = true;
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.EndsWith(Characters[i]))
            {
                EW = true;
            }
        }
        if (SW == true && EW == true)
        {
            emailValid = true;
        }
    }

}
