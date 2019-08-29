using UnityEngine;
using Leap.Unity.Interaction;
using System;
using TMPro;
using System.Linq;

[RequireComponent(typeof(InteractionBehaviour))]
public class ButtonHandler : MonoBehaviour
{
    private delegate string Delegate(string symbol);
    private InteractionBehaviour _interactionBehaviour;
    private TextMesh _keyboardText;
    private static bool _isCapsLock;
    private static DateTime _previousSymbolTime;
    private static Keyboard _keyboard;
    private const int DELAY = 1500;
    private Delegate _numbersDelegate;
    private Delegate _charactersDelegate;
    private Delegate _capsDelegate;

    void Start()
    {
        _interactionBehaviour = GetComponent<InteractionBehaviour>();
        _keyboardText = GameObject.FindWithTag("keyboardText").GetComponent<TextMesh>();
        _previousSymbolTime = DateTime.Now;
        _isCapsLock = false;
        _keyboard = new Keyboard();
        _numbersDelegate = symbol =>
        {
            return _isCapsLock ?
                    _keyboard.getNumbersDict().ToDictionary(x => x.Value, x => x.Key)[symbol] :
                    _keyboard.getNumbersDict()[symbol];
        };
        _charactersDelegate = symbol =>
        {
            return _isCapsLock?
                    symbol.ToLower() :
                    symbol.ToUpper();
        };
        _capsDelegate = symbol =>
        {
            return _isCapsLock ? symbol.ToUpper() : symbol.ToLower();
        };
    }

    void Update()
    {
        if (_interactionBehaviour.isPrimaryHovered)
        {
            if ((DateTime.Now - _previousSymbolTime).TotalMilliseconds > DELAY)
            {
                string currentSymbol = _interactionBehaviour.rigidbody.name;
                string tag = _interactionBehaviour.tag;
                processClick(currentSymbol, tag);
                _previousSymbolTime = DateTime.Now;
            }
        }
    }

    private void processClick(string currentSymbol, string tag)
    {
        if (currentSymbol.Equals("Enter"))
        {
            _keyboardText.text += "\n";
        }
        else if (currentSymbol.Equals("Backspace"))
        {
            _keyboardText.text = _keyboardText.text.Substring(0, _keyboardText.text.Length - 1);
        }
        else if (currentSymbol.Equals("Capslock"))
        {
            processCapsLock();
        }
        else
        {
            processCommonText(currentSymbol, tag);
        }
    }

    private void processCapsLock()
    {
        foreach (GameObject gameObject in _keyboard.getKeyboardNumbers())
        {
            TextMeshPro buttonText = gameObject.GetComponent<TextMeshPro>();
            buttonText.text = _numbersDelegate.Invoke(buttonText.text);
        }
        foreach (GameObject gameObject in _keyboard.getKeyboardButtons())
        {
            TextMeshPro buttonText = gameObject.GetComponent<TextMeshPro>();
            buttonText.text = _charactersDelegate.Invoke(buttonText.text);
        }
        _isCapsLock = !_isCapsLock;
    }

    private void processCommonText(string symbol, string tag)
    {
        if (!tag.Equals("number"))
        {
            _keyboardText.text += _capsDelegate.Invoke(symbol);
        }
        else
        {
            _keyboardText.text += !_isCapsLock ? symbol : _keyboard.getNumbersDict()[symbol];
        }
    }
}
