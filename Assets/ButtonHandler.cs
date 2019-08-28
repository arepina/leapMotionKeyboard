using UnityEngine;
using Leap.Unity.Interaction;
using System;
using TMPro;

[RequireComponent(typeof(InteractionBehaviour))]
public class ButtonHandler : MonoBehaviour
{
    private delegate string Delegate(string symbol);
    private delegate void RunnerDelegate(string symbol, Delegate del);
    private InteractionBehaviour _interactionBehaviour;
    private TextMesh _keyboardText;
    private static DateTime _previousSymbolTime;
    private static bool _isCapsLock;
    private static Keyboard _keyboard;

    void Start()
    {
        _interactionBehaviour = GetComponent<InteractionBehaviour>();
        _keyboardText = GameObject.FindWithTag("keyboardText").GetComponent<TextMesh>();
        _previousSymbolTime = DateTime.Now;
        _isCapsLock = false;
        _keyboard = new Keyboard();
    }

    void Update()
    {
        if (_interactionBehaviour.isPrimaryHovered)
            if ((DateTime.Now - _previousSymbolTime).TotalMilliseconds > 1500)
            {
                string currentSymbol = _interactionBehaviour.name;
                changeText(currentSymbol);
                _previousSymbolTime = DateTime.Now;
            }
    }

    private void changeText(string currentSymbol)
    {
        if (currentSymbol.Equals("Enter"))
            _keyboardText.text += "\n";
        else if (currentSymbol.Equals("Backspace"))
            _keyboardText.text = _keyboardText.text.Substring(0, _keyboardText.text.Length - 1);
        else if (currentSymbol.Equals("Capslock"))
        {
            Delegate changeCaps;
            if (!_isCapsLock)
                changeCaps = (symbol) => { _isCapsLock = true; return symbol.ToUpper(); };
            else
                changeCaps = (symbol) => { _isCapsLock = false; return symbol.ToLower(); };
            Delegate changeNumber = (number) => { return _isCapsLock ? _keyboard.getNumbersDict()[number] : number;  };
            changeCapsLock(changeCaps, changeNumber);
        }
        else
            _keyboardText.text += _isCapsLock ? currentSymbol.ToUpper() : currentSymbol.ToLower();
    }

    private void changeCapsLock(Delegate delegateButtons, Delegate delegateNumbers)
    {
        RunnerDelegate runner = (name, func) =>
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(name))
            {
                TextMeshPro buttonText = gameObject.GetComponent<TextMeshPro>();
                buttonText.text = func.Invoke(buttonText.text);
            }
        };
        runner.Invoke("keyboardNumbers", delegateNumbers);
        runner.Invoke("keyboardButtons", delegateButtons);
    }
}
