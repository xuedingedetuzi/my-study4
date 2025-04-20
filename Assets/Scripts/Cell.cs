using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    public Plant currentPlant;
    private void OnMouseDown()
    {
        Handmanager.Instance.OnCellClick(this);
    }

    public bool AddPlant(Plant plant)
    {
        if(currentPlant!=null) return false;
        currentPlant = plant;
        currentPlant.transform.parent = transform;
        currentPlant.transform.position = transform.position;
        plant.TransitionToEnable();
        return true;
    }
}
