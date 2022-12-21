using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialog : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Button nextButton;

    // Dialog lines and character names
    [SerializeField] public string[] dialogLines;
    [SerializeField] private GameObject Player;
    public bool active = false;
    // Index of the current dialog line
    private int currentLine = 0;

    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && active)
        {
            NextLine();
        }
    }
    public void ShowDialog(string[] dialogLines, string characterName)
    {
        currentLine = 0;
        this.dialogLines = dialogLines;
        nameText.text = characterName;
        // Set the dialog text and character name
        dialogText.text = dialogLines[currentLine];
        // Set the dialog box to active
        gameObject.SetActive(true);
        active = true;
        Player.GetComponent<Player>().inDialog = true;
    }
    public void NextLine()
    {
        // Advance to the next line of dialog
        currentLine++;

        // Check if we have reached the end of the dialog
        if (currentLine >= dialogLines.Length)
        {
            // End the dialog
            gameObject.SetActive(false);
            Player.GetComponent<Player>().inDialog = false;
            return;
        }

        // Update the dialog text and character portrait
        dialogText.text = dialogLines[currentLine];
    }
}
