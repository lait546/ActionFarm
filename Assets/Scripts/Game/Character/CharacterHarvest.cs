using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHarvest : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private float HarvestSpeed = 100f;
    [SerializeField] private float harvestDistance = 5f;
    private FarmCell lastFarmCell;
    public bool isHarvesting = false;


    void Update()
    {
        Harvesting();
    }

    public void Harvesting()
    {
        RaycastHit[] hit = Physics.RaycastAll(transform.position + new Vector3(0, 1f, 0), transform.position + (transform.forward * harvestDistance) + new Vector3(0, 1f, 0));

        Debug.DrawLine(transform.position + new Vector3(0,1f,0), transform.position + (transform.forward * harvestDistance) + new Vector3(0, 1f, 0), Color.green);

        if (hit.Length > 0)
        {
            if (hit[0].collider.gameObject.GetComponent<FarmCell>()) //is
            {
                if (lastFarmCell != hit[0].collider.gameObject.GetComponent<FarmCell>())
                {
                    if(lastFarmCell)
                        lastFarmCell.SetHarvesting(false, HarvestSpeed);

                    lastFarmCell = hit[0].collider.gameObject.GetComponent<FarmCell>();
                    lastFarmCell.SetHarvesting(true, HarvestSpeed);

                    if(lastFarmCell.CanHarvesting)
                        character.Anim.IsHarvest(true);
                    else
                        character.Anim.IsHarvest(false);

                    isHarvesting = true;
                }
                else
                {
                    lastFarmCell.SetHarvesting(true, HarvestSpeed);

                    if (lastFarmCell.CanHarvesting)
                        character.Anim.IsHarvest(true);
                    else
                        character.Anim.IsHarvest(false);

                    isHarvesting = true;
                }
            }
            else if(lastFarmCell != null && !hit[0].collider.gameObject.GetComponent<FarmCell>())
            {
                lastFarmCell.SetHarvesting(false, HarvestSpeed);
                isHarvesting = false;

                character.Anim.IsHarvest(false);

                lastFarmCell = null;
            }
        }
        else if (lastFarmCell != null)
        {
            lastFarmCell.SetHarvesting(false, HarvestSpeed);
            isHarvesting = false;
            character.Anim.IsHarvest(false);
            lastFarmCell = null;
        }
    }
}
