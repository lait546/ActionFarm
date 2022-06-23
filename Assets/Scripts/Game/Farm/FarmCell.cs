using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmCell : MonoBehaviour
{
    [SerializeField] private WheatAnimation wheatAnim;
    [SerializeField] private const float progressHarvest_MAX = 100f;
    [SerializeField] private float progressHarvest = 100f, growthTime = 10f, growthMaxHeight = 4f;
    public bool CanHarvesting = true, isActiveHarvesting = false;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private ParticleSystem harvestParticle;
    [SerializeField] private LootItem lootItem;

    private Coroutine lastCoroutine;

    public void SetHarvesting(bool value, float harvestSpeed)
    {

        if (lastCoroutine != null && isActiveHarvesting && !value)
        {
            StopCoroutine(lastCoroutine);
            isActiveHarvesting = false;
        }

        if (value && CanHarvesting && !isActiveHarvesting)
        {
            isActiveHarvesting = true;
            lastCoroutine = StartCoroutine(IHarvesting(harvestSpeed));
        }
    }

    private IEnumerator IHarvesting(float harvestSpeed)
    {
        while (CanHarvesting)
        {
            progressHarvest = Mathf.Lerp(progressHarvest, progressHarvest - harvestSpeed, harvestSpeed * Time.deltaTime);

            if (progressHarvest <= 0)
            {
                CanHarvesting = false;
                wheatAnim.SetHeight(0);
                SetActiveBoxCollider(false);
                Instantiate(harvestParticle, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                Instantiate(lootItem, transform.position + new Vector3(0,1f,0), Quaternion.identity);
                Growth();
                yield break;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void Growth()
    {
        wheatAnim.ChangeHeight(growthMaxHeight, growthTime);
        StartCoroutine(IGrowth());
    }

    private IEnumerator IGrowth()
    {
        float startTime = Time.realtimeSinceStartup, fraction = 0f, oldValue = progressHarvest;
        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / growthTime);
            progressHarvest = Mathf.Lerp(oldValue, progressHarvest_MAX, fraction);
            
            if (progressHarvest >= progressHarvest_MAX)
            {
                CanHarvesting = true;
                isActiveHarvesting = false;
                SetActiveBoxCollider(true);
                yield break;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void SetActiveBoxCollider(bool value)
    {
        boxCollider.enabled = value;
    }
}
