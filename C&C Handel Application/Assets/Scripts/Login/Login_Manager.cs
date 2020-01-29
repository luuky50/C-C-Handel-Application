using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_Manager : MonoBehaviour
{
    public GameObject Login;
    public GameObject Register;


    private void Awake()
    {
        Login.SetActive(true);
        Register.SetActive(false);
    }

    public void LoadRegister()
    {
        Login.SetActive(false);
        Register.SetActive(true);
    }

    public void LoadLogin()
    {
        Login.SetActive(true);
        Register.SetActive(false);
    }

}
