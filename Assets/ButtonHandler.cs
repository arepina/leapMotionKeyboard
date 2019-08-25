using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;
using System;

[RequireComponent(typeof(InteractionBehaviour))]
public class ButtonHandler : MonoBehaviour
{
    private InteractionBehaviour _intObj;

    void Start()
    {
        Debug.Log("Start");
        _intObj = GetComponent<InteractionBehaviour>();
        _intObj.OnHoverBegin += onHoverBegin;
        _intObj.OnPerControllerHoverBegin += OnPerControllerHoverBegin;
    }

    private void OnPerControllerHoverBegin(InteractionController obj)
    {
        Debug.Log((InteractionController)obj.intHand);
    }

    private void onHoverBegin()
    {
        Debug.Log("onHoverBegin");
    }

    public void setText(string text)
    {
        Debug.Log("setText");
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }
}
