using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject InstructionsPanel;
    [SerializeField] public GameObject MainMenuPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void ShowInstructions(){
        InstructionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void HideInstructions(){
        InstructionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
