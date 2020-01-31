using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_Data : MonoBehaviour
{
    public Register _register_Script;

    static public string Username { get; set; }
    static public string Password { get; set; }
    static public string Email { get; set; }

    void Awake()
    {
        _register_Script = GameObject.Find("Register").GetComponent<Register>();
    }

    public void Update()
    {
        Data(Username, Password, Email);
    }

    public void Data(string _username, string _password, string _email)
    {
        Username = _username;
        Password = _password;
        Email = _email;        
    }

    
}
