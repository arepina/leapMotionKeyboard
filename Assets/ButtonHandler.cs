using UnityEngine;
using Leap.Unity.Interaction;
using System;

[RequireComponent(typeof(InteractionBehaviour))]
public class ButtonHandler : MonoBehaviour
{
    private InteractionBehaviour _interactionBehaviour;
    private TextMesh _keyboard;
    private static string _currentSymbol;
    private static int _previousSymbolTimeS;

    void Start()
    {
        _interactionBehaviour = GetComponent<InteractionBehaviour>();
        _keyboard = GameObject.FindWithTag("keyboardText").GetComponent<TextMesh>();
        _currentSymbol = "";
        _previousSymbolTimeS = DateTime.Now.Second;
    }

    void Update()
    {
        if (_interactionBehaviour.isPrimaryHovered)
        {
            if (!_currentSymbol.Equals(this._interactionBehaviour.name)) // changed the letter
            {
                //TODO add a delay for click on the letter
                Debug.Log("Different");
                _currentSymbol = this._interactionBehaviour.name;
                _keyboard.text = _keyboard.text + _currentSymbol;
                _previousSymbolTimeS = DateTime.Now.Second;
            }
            else if(Math.Abs(DateTime.Now.Second - _previousSymbolTimeS) > 1) // same letter one more time, 1 second delay
            {
                Debug.Log("Same " + _currentSymbol + " " + Math.Abs(DateTime.Now.Second - _previousSymbolTimeS));
                _keyboard.text = _keyboard.text + _currentSymbol;
                _previousSymbolTimeS = DateTime.Now.Second;
            }
            else
            {
                Debug.Log("!Same " + _currentSymbol + " " + Math.Abs(DateTime.Now.Second - _previousSymbolTimeS));
            }
        }
    }
}
