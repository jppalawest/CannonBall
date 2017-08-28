using UnityEngine;

public class ButtonController : MonoBehaviour 
{
    public SceneFader fader;

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}

