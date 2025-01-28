using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeLightColor : MonoBehaviour
{
    private XRNode inputSource; 
    private InputDevice device; 

    public Light lightToChange; 

    void Start()
    {
        inputSource = XRNode.LeftHand;
    }

    void Update()
    {
        device = InputDevices.GetDeviceAtXRNode(inputSource);

        bool primaryButtonPressed;
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonPressed) && primaryButtonPressed)
        {
            if (lightToChange != null)
            {
                lightToChange.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}
