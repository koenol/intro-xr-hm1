using UnityEngine;

public class RenderQueue : MonoBehaviour
{
    public int newRenderQueue = 3000; // Set the desired render queue value

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Material material = renderer.material;
            material.renderQueue = newRenderQueue;
        }
    }
}
