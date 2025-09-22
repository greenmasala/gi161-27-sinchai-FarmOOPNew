using OpenCover.Framework.Model;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Chicken chicken;
    public Cow cow;
    public Pig pig;
    public List<Animal> animals = new List<Animal>();
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chicken.Init("KFC", 10, 5);
        cow.Init("Burger King", 15, 25);
        pig.Init("Porkshop", 15, 3);
        animals.Add(chicken);
        animals.Add(cow);
        animals.Add(pig);

        Debug.Log($"Welcome to the farm! There are {animals.Count} animals here!");

        foreach (Animal animal in animals)
        {
            animal.GetStatus();
        }

        foreach (Animal animal in animals)
        {
            animal.MakeSound("");
            animal.Feed(5);
        }

        chicken.Feed("fried chicken", 10);
        chicken.Sleep();
        chicken.GetStatus();

        cow.Feed("grass", 5);
        cow.Moo();
        cow.GetStatus();

        pig.Feed("porkshop", 15);
        pig.GetStatus();
    }
}
