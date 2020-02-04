using UnityEngine;

public enum Orientation {Portrait, Landscape, None}

[System.Serializable]
public class Panel
{
    public Transform background;

    public void enable(bool active, bool switchBackground = false)
    {
        if(switchBackground)
            background.gameObject.SetActive(active);
    }
}

