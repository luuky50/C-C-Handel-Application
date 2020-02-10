using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
internal class SceneInProject
{
    public List<QuestionInteractable> allQuestionsOfScene = new List<QuestionInteractable>();
    public List<MediaInteractable> mediaInteractablesOfScene = new List<MediaInteractable>();
    
   public Texture2D _360Image { get; set; }
}