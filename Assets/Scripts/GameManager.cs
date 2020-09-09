using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    GameObject playerMainCharacter, playerUnit;
    [SerializeField]
    bool isMainCharacterSelected;
    [SerializeField]
    Transform spawnPoint;

    public int shipsInFleet, playerLives;


    // Start is called before the first frame update
    void Start()
    {
        //Set amount of ships player starts with
        shipsInFleet = 3;
        playerLives = 3;
        //Set the main character of the player
        SetMainCharacter();
        SetMainCamera();
        SpawnUnits();
        
        
    }

    private void SetMainCamera()
    {

        Camera.main.transform.position = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isMainCharacterSelected == false)
            {
                SetMainCharacter();
                
            }
        }        
    }

    void SetMainCharacter() {
        playerMainCharacter = GameObject.Find("Player");

        if (playerMainCharacter != null)
        {
            Debug.Log("Player found");
            isMainCharacterSelected = true;
        }
        else
        {
            Debug.Log("Player NOT found!!");

        }
    }

    void SetNewCharacter(GameObject newCharacter) { 
        
    }

    void SpawnUnits() {
        for (int i = 0; i < shipsInFleet; i++)
        {
            Instantiate((GameObject)playerUnit, spawnPoint.position + RandomPointInCollider(), Quaternion.identity);
        }
    }

    Vector3 RandomPointInCollider() {
        return new Vector3(
            UnityEngine.Random.Range(-5, 5),
            UnityEngine.Random.Range(-5, 5),
            0
            );
    }
}
