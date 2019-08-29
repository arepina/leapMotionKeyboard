using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private Dictionary<string, string> _dictionary;
    public Keyboard()
    {
        _dictionary = new Dictionary<string, string>();
        _dictionary.Add("1", "!");
        _dictionary.Add("2", "@");
        _dictionary.Add("3", "#");
        _dictionary.Add("4", "$");
        _dictionary.Add("5", "%");
        _dictionary.Add("6", "^");
        _dictionary.Add("7", "&");
        _dictionary.Add("8", "*");
        _dictionary.Add("9", "(");
        _dictionary.Add("0", ")");
        _dictionary.Add("-", "_");
        _dictionary.Add(",", "<");
        _dictionary.Add(".", ">");
        _dictionary.Add("?", "~");
        _dictionary.Add("'", "`");
        _dictionary.Add(";", ":");
        _dictionary.Add("[", "{");
        _dictionary.Add("]", "}");
        _dictionary.Add("+", "€");
        _dictionary.Add("=", "=");
        _dictionary.Add("/", "\"");
        _dictionary.Add("\\", "©");
        _dictionary.Add("|", "±");
    }

    public Dictionary<string, string> getNumbersDict()
    {
        return _dictionary;
    }

    public GameObject[] getKeyboardNumbers()
    {
        return GameObject.FindGameObjectsWithTag("keyboardNumbers");
    }

    public GameObject[] getKeyboardButtons()
    {
        return GameObject.FindGameObjectsWithTag("keyboardButtons");
    }
}

