using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;

    [SerializeField] private GameObject wood;
    [SerializeField] private GameObject concrete;
    [SerializeField] private GameObject metal;

    [SerializeField] private PopupNumber  woodNumber;
    [SerializeField] private PopupNumber  concreteNumber;
    [SerializeField] private PopupNumber  metalNumber;
    [SerializeField] private PopupNumber  soldierNumber;

    [SerializeField] private GameObject smoke;

    private Quaternion q = Quaternion.Euler(-90f, 0f, 0f);

    private void Awake() {
        SingletonSetup();
    }

    public void SpawnWood(Vector3 position)
    {
        Instantiate(wood, position, q);
    }

    public void SpawnConcrete(Vector3 position)
    {
        Instantiate(concrete, position, q);
    }

    public void SpawnMetal(Vector3 position)
    {
        Instantiate(metal, position, q);
    }

    public void SpawnSmoke(Vector3 position)
    {
        Instantiate(smoke, position, q);
    }

    public void SpawnWoodNumber(Vector3 position)
    {
        PopupNumber woodNum = Instantiate(woodNumber, position, Quaternion.identity);
    }

    public void SpawnConcreteNumber(Vector3 position)
    {
        PopupNumber concreteNum = Instantiate(concreteNumber, position, Quaternion.identity);
    }

    public void SpawnMetalNumber(Vector3 position)
    {
        PopupNumber metalNum = Instantiate(metalNumber, position, Quaternion.identity);
    }

    public void SpawnSoldierNumber(Vector3 position)
    {
        PopupNumber soldierNum = Instantiate(soldierNumber, position, Quaternion.identity);
    }



    private void SingletonSetup()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
}
