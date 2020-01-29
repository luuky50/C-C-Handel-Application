using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_Data
{
    public Register _register_Script;

    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }


    public void Update()
    {
        Username = _register_Script.username.ToString();
        Password = _register_Script.password.ToString();
        Email = _register_Script.email.ToString();
    }

    public void Data(string _username, string _password, string _email)
    {
        Username = _username;
        Password = _password;
        Email = _email;
    }

    
}
