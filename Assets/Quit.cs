using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class QuitGame : MonoBehaviour
{
    private XRNode inputSource;
    private InputDevice device;

    void Start()
    {
        inputSource = XRNode.RightHand; 
    }

    void Update()
    {
        device = InputDevices.GetDeviceAtXRNode(inputSource);

        bool primaryButtonPressed;
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonPressed) && primaryButtonPressed)
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
