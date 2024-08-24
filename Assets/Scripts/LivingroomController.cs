using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class LivingroomController : MonoBehaviour
{
    [SerializeField]
    private GameObject House;
    [SerializeField]
    private GameObject Furniture;
    [SerializeField]
    private GameObject Player;

    private Animator HouseAnimator;
    private Animator FurnitureAnimator;

    private float startTime;
    void Start()
    {
        startTime = Time.time;

        PlaySimulation();
    }
    void Update()
    {
        Vector3 playerPosition = Player.transform.position;
        if (playerPosition.x < 11 && playerPosition.z < 4.2)
        {
            StopSimulation();
            Debug.Log("Win");
        }
        else if (playerPosition.x < 7.5)
        {
            StopSimulation();
            Debug.Log("Jangan Keluar Ruangan");
        }
        else if (Time.time - startTime >= 20f)
        {
            StopSimulation();
            Debug.Log("Cari Tempat Berlindung");
        }
        else
        Debug.Log("Player Position: X = " + playerPosition.x + " --- Y = " + playerPosition.y + " --- Z = " + playerPosition.z);
    }

    private void PlaySimulation()
    {
        HouseAnimator = House.GetComponent<Animator>();
        FurnitureAnimator = Furniture.GetComponent<Animator>();

        HouseAnimator.enabled = true;
        FurnitureAnimator.enabled = true;

        HouseAnimator.Play("FurnitureAnimator");
        FurnitureAnimator.Play("LivingroomAnimation");
    }

    private void StopSimulation()
    {
        HouseAnimator.enabled = false;
        FurnitureAnimator.enabled = false;
    }
}
