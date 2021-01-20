using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    private ScreenBase[] screens;

    // Start is called before the first frame update
    void Start()
    {
        App.screenManager = this;
        screens = GetComponentsInChildren<ScreenBase>(true);
        Show<MenuScreen>();
    }

    public void Show<T>()
    {
        foreach(var screen in screens)
        {
            if(screen.GetType() == typeof(T))
            {
                screen.Show();
                break;
            }
        }
    }

    public void Hide<T>()
    {
        foreach(var screen in screens)
        {
            if(screen.GetType() == typeof(T))
            {
                screen.Hide();
                break;
            }
        }
    }
}
