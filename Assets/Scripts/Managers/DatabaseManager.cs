using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    private Database database;
    public NeedsController needsController;

    private void Awake()
    {
        database = new Database();

        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one DatabaseManager in the Scene");
    }

    private void Update()
    {
        if (TimingManager.gameHourTimer < 0)
        {
            Pet pet = new Pet(
                needsController.lastTimeFood.ToString(),
                needsController.lastTimeHappy.ToString(),
                needsController.lastTimeGainedEnergy.ToString(),
                needsController.lastTimeCoin.ToString(),
                needsController.food,
                needsController.happiness,
                needsController.energy,
                needsController.coins
                );
            SavePet(pet);
        }
    }
    private void Start()
    {
        Pet pet = LoadPet();
        if (pet != null) 
        {
            needsController.Initialize
                (
                pet.food,
                pet.happiness,
                pet.energy,
                pet.coins,
                10, 10, 10,15,
                DateTime.Parse(pet.lastTimeFood),
                DateTime.Parse(pet.lastTimeHappy),
                DateTime.Parse(pet.lastTimeGainedEnergy),
                DateTime.Parse(pet.lastTimeCoin)
                );
        };
    }

    public void SavePet(Pet pet)
    {
        database.SaveData("pet", pet);
    }

    public Pet LoadPet()
    {
        Pet returnValue = null;
        database.LoadData<Pet>("pet", (pet) =>
         {
             returnValue = pet;
         });
        return returnValue;
    }
}
