using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GlobalVariables
{
    public static int PlanetIndex { get; set; }
}

public class EnterButton : MonoBehaviour
{
    public void EnterSolarScene(int index)
    {
        SceneManager.LoadScene("SolarScene");
        GlobalVariables.PlanetIndex = index;
    }
}
