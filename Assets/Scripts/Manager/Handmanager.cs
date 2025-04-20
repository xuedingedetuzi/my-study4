using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Handmanager Instance {  get; private set; }

    public List<Plant> plantPrefabList;

    private Plant currentPlant;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        FollowCursor();
    }
    public bool AddPlant(PlantType plantType)
    {
        if (currentPlant != null) return false; 
        Plant plantPrefab= GetPlantPrefab(plantType);
        if (plantPrefab == null) { print("²»´æÔÚ");return false; }
        currentPlant =GameObject.Instantiate(plantPrefab);
        return true;
    }

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach(Plant plant in plantPrefabList)
        {
            if(plant.plantType==plantType) return plant;
        }
        return null;
    }

    void FollowCursor()
    {
        if (currentPlant == null) return;

        Vector3 mouseWorldPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        currentPlant.transform.position = mouseWorldPosition;
    }

    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        bool isSuccess=cell.AddPlant(currentPlant);
        if (isSuccess)
        {
            currentPlant = null;
            Aduiomanager.Instance.PlayClip(Config.plant);
        }
    }
}
