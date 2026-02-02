using TMPro;
using UnityEngine;

public class DialogueLines  : MonoBehaviour
{
    [SerializeField] string[] lines;
    [SerializeField] TMP_Text dialogueText;
    
    int currentLineIndex = 0;  

    public void ShowNextLine()
    {
    
            currentLineIndex++;
            dialogueText.text = lines[currentLineIndex];
        
    }

}
