using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTypeEffect : MonoBehaviour
{
    [SerializeField] private string content;

    private TextMeshProUGUI tmpro;

    private void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        content = tmpro.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence());
    }

    public void showText()
    {
        StartCoroutine(TypeSentence());
    }

    private IEnumerator TypeSentence()
    {
        tmpro.text = "";
        foreach (char letter in content.ToCharArray())
        {
            tmpro.text += letter;
            yield return null;
        }
    }
}
