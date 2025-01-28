using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleView : MonoBehaviour
{
    private XRNode inputSource;
    private InputDevice device;

    public Transform externalViewPoint;
    public Transform roomViewPoint;

    private bool isInExternalView = false;

    private float timeSinceLastSwitch = 0f;
    private float switchCooldown = 1f;

    void Start()
    {
        inputSource = XRNode.RightHand;
    }

    void Update()
    {
        device = InputDevices.GetDeviceAtXRNode(inputSource);

        bool secondaryButtonPressed;
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonPressed) && secondaryButtonPressed)
        {
            if (timeSinceLastSwitch >= switchCooldown)
            {
                TogglePlayerView();
                timeSinceLastSwitch = 0f;
            }
        }
        timeSinceLastSwitch += Time.deltaTime;
    }

    void TogglePlayerView()
    {
        if (isInExternalView)
        {
            transform.position = roomViewPoint.position;
            transform.rotation = roomViewPoint.rotation;
        }
        else
        {
            transform.position = externalViewPoint.position;
            transform.rotation = externalViewPoint.rotation;
        }
        isInExternalView = !isInExternalView;
    }
}
