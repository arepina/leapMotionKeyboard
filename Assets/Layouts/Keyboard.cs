using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private Dictionary<string, string> _numbersButtons;
    public Keyboard()
    {
        _numbersButtons = new Dictionary<string, string>();
        _numbersButtons.Add("1", "!");
        _numbersButtons.Add("2", "@");
        _numbersButtons.Add("3", "#");
        _numbersButtons.Add("4", "$");
        _numbersButtons.Add("5", "%");
        _numbersButtons.Add("6", "^");
        _numbersButtons.Add("7", "&");
        _numbersButtons.Add("8", "*");
        _numbersButtons.Add("9", "(");
        _numbersButtons.Add("0", ")");
        _numbersButtons.Add("-", "_");
        _numbersButtons.Add(",", "<");
        _numbersButtons.Add(".", ">");
        _numbersButtons.Add("?", "~");
        _numbersButtons.Add("'", "\"");
        _numbersButtons.Add(";", ":");
        _numbersButtons.Add("[", "{");
        _numbersButtons.Add("]", "}");
    }

    public Dictionary<string, string> getNumbersDict()
    {
        return _numbersButtons;
    }
}

