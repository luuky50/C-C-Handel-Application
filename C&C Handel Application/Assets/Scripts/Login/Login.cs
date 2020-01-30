using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    #region variables
    public GameObject username;
    public GameObject password;

    private string Username;
    private string Password;

    private String[] Lines;

    private string DecryptedPass;

    public string filePath = "C:/Users/Gebruiker/Desktop/Users/";
    #endregion


    #region Warning variables
    public GameObject Empty_Username;
    public GameObject Empty_Password;

    public GameObject Invalid_Username;
    public GameObject Invalid_Password;
    #endregion

    private void Awake()
    {
        Empty_Username.SetActive(false);
        Empty_Password.SetActive(false);
        Invalid_Username.SetActive(false);
        Invalid_Password.SetActive(false);
    }

    void Update()
    {
        TabFunction();
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;


        if (Input.GetKeyDown(KeyCode.Return))
            if (Password != "" && Password != "")
                LoginButton();

    }

    void TabFunction()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
            if (username.GetComponent<InputField>().isFocused)
                password.GetComponent<InputField>().Select();
    }

    public void LoginButton()
    {
        bool UN = false;
        bool PW = false;

        Empty_Username.SetActive(false);
        Empty_Password.SetActive(false);
        Invalid_Username.SetActive(false);
        Invalid_Password.SetActive(false);

        if (Username != "")
        {
            if (System.IO.File.Exists(@filePath+Username+".txt"))
            {
                UN = true;
                Lines = System.IO.File.ReadAllLines(@filePath + Username + ".txt");
            }
            else
            {
                Debug.LogWarning("Username Invalid");
                Invalid_Username.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Username Field Empty");
            Empty_Username.SetActive(true);
        }


        //decryptie
        if (Password != "")
        {
            if (System.IO.File.Exists(@filePath + Username + ".txt"))
            {
                int i = 1;
                foreach (char c in Lines[2])
                {
                    i++;
                    char Decrypted = (char)(c / i);
                    DecryptedPass += Decrypted.ToString();
                }
                if (Password == DecryptedPass)
                {
                    PW = true;
                }
                else
                {
                    Debug.LogWarning("Password is Invalid");
                    Invalid_Password.SetActive(true);
                }
            }
            else
            {
                Debug.LogWarning("Password Is Invalid");
                Invalid_Password.SetActive(true);
            }

        }
        else
        {
            Debug.LogWarning("Password Field Empty");
            Empty_Password.SetActive(true);
        }

        if (UN == true && PW == true)
        {
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            Debug.Log("Login Sucessful");
            Application.LoadLevel("Editor");
        }
      

    }



}