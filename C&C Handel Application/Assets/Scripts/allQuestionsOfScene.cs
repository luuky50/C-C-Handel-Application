using UnityEngine;
using System.Collections;

internal class QuestionInteractable
{
    public Vector3 positionInteractable { get; set; }
    public string Question { get; set; }
    public string AnswerOne { get; set; }
    public string AnswerTwo { get; set; }
    public string AnswerThree { get; set; }
    public string AnswerFour { get; set; }

    public int GoodAnswer;
}