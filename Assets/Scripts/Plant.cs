using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantState
{
    Disable,Enable
}
public class Plant : MonoBehaviour
{
    // Start is called before the first frame update
    PlantState plantState= PlantState.Disable;
    public PlantType plantType=PlantType.Sunflower;

    private void Start()
    {
        TransitionToDisable();
    }

    private void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate(); break;
            case PlantState.Enable:
                EnableUpdate(); break;
        }
    }

    void DisableUpdate()
    {

    }
    void EnableUpdate()
    {

    }
    void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;
    }
    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
    }

}
