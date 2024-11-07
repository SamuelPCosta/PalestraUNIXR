using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    public GameObject[] Screens;
    [SerializeField] private int index = 0;

    void Start()
    {
        index = 0;
    }

    public void Decrease()
    {
        index = (index - 1 < 0) ? Screens.Length - 1 : --index;
        RefreshScreen();
    }

    public void Increase()
    {
        index = (index + 1 >= Screens.Length) ? 0 : ++index;
        RefreshScreen();
    }

    private void RefreshScreen()
    {
        for (int i = 0; i < Screens.Length; i++)
            if(Screens[i] != null)
                Screens[i].SetActive(i == index);
    }
}
