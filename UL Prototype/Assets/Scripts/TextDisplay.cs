using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public float TextDuration;
    public float CurrentTextDuration;

    private int index;
    private Color firstWordColor = Color.red;
    public Color[] TextColor;
    public AudioSource[] TextVoice;
    public Image TextBackground;

    void Start()
    {
        textComponent.text = string.Empty;
        //StartDialogue();
    }

    void Update()
    {

        if (textComponent.text == lines[index] && lines[index] != string.Empty)
        {
            TextVoice[index].Stop();
            if (CurrentTextDuration >= TextDuration)
            {
                if (lines[index + 1] != string.Empty)
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                    textComponent.text = string.Empty;
                }
                CurrentTextDuration = 0;
            }
            else CurrentTextDuration += Time.deltaTime;
        }

        if (textComponent.text != string.Empty)
        {
            TextBackground.gameObject.SetActive(true);
        }
        else TextBackground.gameObject.SetActive(false);
        
    }
    public void StartDialogue()
    {
        index = 0;
        textComponent.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        this.textComponent.color = TextColor[index];
        TextVoice[index].Play();
        string line = lines[index];
        string[] words = line.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

        {
            // Set the color of the word to white
            textComponent.text +=word;
        }

        // Add a space between words
        if (i < words.Length - 1)
        {
            textComponent.text += " ";
        }

        yield return new WaitForSeconds(textSpeed);
    }
}

void NextLine()
{
        Debug.Log("NextLine");
    if (index < lines.Length - 1)
    {
        // Set the color of the first word in the new line
        TMP_TextInfo textInfo = textComponent.textInfo;
        if (textInfo.wordCount > 0)
        {
            TMP_WordInfo firstWordInfo = textInfo.wordInfo[0];
            TMP_CharacterInfo[] characterInfos = textInfo.characterInfo;
            int firstCharacterIndex = firstWordInfo.firstCharacterIndex;
            firstWordColor = characterInfos[firstCharacterIndex].color;
        }

        index++;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    else
    {
        gameObject.SetActive(false);
    }
}
string GetFirstWord(string text)
{
    if (string.IsNullOrEmpty(text))
        return string.Empty;

    string[] words = text.Split(' ');
    if (words.Length > 0)
        return words[0];

    return string.Empty;
}
}