using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager instance;
    public List<Panel> panels;

    private Panel thisPanel;
    private List<Panel> history;

    void Start()
    {
        instance = this;
        history = new List<Panel>();

        //close all panels
        //foreach (Panel p in panels)
        //{
        //    p.enable(false, true);
        //}

        //open first panel
        thisPanel = panels[0];
        switchPanel(thisPanel);

        if (thisPanel.background.gameObject != null)
            thisPanel.background.gameObject.SetActive(true);
    }

    void Update()
    {

    }

    public void nextPanel()
    {
        //check what the next panel is gonna be
        if (panels.Count > panels.IndexOf(thisPanel))
        {
            switchPanel(panels[panels.IndexOf(thisPanel) + 1]);
        }
        else
        {
            Debug.Log("We can't go a panel further");
        }
    }

    public void previous()
    {
        if (history.Count > 1)
        {
            //remove last panel
            history.Remove(history[history.Count - 1]);
            //switch to previous panel
            switchPanel(history[history.Count - 1], false);
        }

    }

    public void goToPanel(Transform panelToSwitchTo)
    {
        bool panelFound = false;
        foreach (Panel p in panels)
        {
            switchPanel(p);
            panelFound = true;
        }
        if (!panelFound)
        {
            Debug.Log("Panel does not exist in panelList");
        }
    }

    public void goToPanel(int panelToSwitchTo)
    {
        if (panelToSwitchTo < panels.Count)
        {
            switchPanel(panels[panelToSwitchTo]);
        }
        else
        {
            Debug.Log("Panel does not exist in panelList");
        }
    }

    private void switchPanel(Panel panelToSwitchTo, bool addToHistory = true)
    {
        bool switchBackground = false;
        if (panelToSwitchTo.background != thisPanel.background)
        {
            switchBackground = true;
            thisPanel.background.gameObject.SetActive(false);
        }
        foreach (Panel p in panels)
        {
            if (p == panelToSwitchTo)
            {
                //enable correct panel
                p.enable(true, switchBackground);
                thisPanel = p;
                if (addToHistory)
                {
                    if (history.Count != 0)
                    {
                        if (history[history.Count - 1] != null && history[history.Count - 1] != p)
                            history.Add(p);
                    }
                    else
                    {
                        history.Add(p);
                    }
                }
            }
            else
            {
                //disable other panels
                p.enable(false);
            }

        }
    }
}

