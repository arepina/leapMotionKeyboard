using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]
public class ButtonHandler : MonoBehaviour
{
    private InteractionBehaviour _intObj;
    private TextMesh _keyboard;

    void Start()
    {
        _intObj = GetComponent<InteractionBehaviour>();
        _keyboard = GameObject.FindWithTag("keyboardText").GetComponent<TextMesh>();
        //_intObj.OnPerControllerHoverBegin += OnPerControllerHoverBegin;
    }

    void Update()
    {
        if (_intObj.isPrimaryHovered) //_intObj.isHovered
        {
            _keyboard.text = _keyboard.text + this._intObj.name;
        }
    }

    //private void OnPerControllerHoverBegin(InteractionController obj)
    //{
    //    debug.log("pos=" + obj.position + " primaryhoveredobject=" + obj.primaryhoveredobject + " tag=" + obj.tag + " velocity=" + obj.velocity);
    //    Pos=(0.1, 1.5, 0.3) primaryHoveredObject=i(Leap.Unity.Interaction.InteractionButton) tag=Untagged velocity = (-0.1, 0.0, 0.0)
    //    Pos=(0.0, 1.5, 0.3) primaryHoveredObject=u(Leap.Unity.Interaction.InteractionButton) tag=Untagged velocity = (-0.1, -0.3, 0.3)
    //    Pos=(0.1, 1.4, 0.3) primaryHoveredObject=j(Leap.Unity.Interaction.InteractionButton) tag=Untagged velocity = (-0.1, 0.0, 0.0)
    //    Pos=(0.1, 1.4, 0.3) primaryHoveredObject=k(Leap.Unity.Interaction.InteractionButton) tag=Untagged velocity = (-0.1, -0.5, 0.7)
    //}
}
