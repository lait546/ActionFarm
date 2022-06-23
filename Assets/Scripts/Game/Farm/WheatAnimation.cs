using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatAnimation : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    [SerializeField] private Material material;

    [Range(0, 10)]
    [SerializeField] private float currentHeight;

    private Coroutine lastCoroutine;

    public void Start()
    {
        renderer.material = new Material(material);
        renderer.sharedMaterial.SetFloat("_BladeHeight", currentHeight);
    }

    public void ChangeHeight(float newHeight, float timeChange)
    {
        if (lastCoroutine != null)
            StopCoroutine(lastCoroutine);

        lastCoroutine = StartCoroutine(IChangeHeight(newHeight, timeChange));
    }

    public void SetHeight(float newHeight)
    {
        currentHeight = newHeight;
        renderer.sharedMaterial.SetFloat("_BladeHeight", newHeight);
    }

    private IEnumerator IChangeHeight(float newHeight, float timeChange)
    {
        float startTime = Time.realtimeSinceStartup, fraction = 0f, oldValue = currentHeight;
        

        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / timeChange);
            currentHeight = Mathf.Lerp(oldValue, newHeight, fraction);
            
            renderer.sharedMaterial.SetFloat("_BladeHeight", currentHeight);

            yield return new WaitForFixedUpdate();
        }
    }
}
