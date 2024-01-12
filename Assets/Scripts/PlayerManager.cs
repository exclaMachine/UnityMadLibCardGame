using UnityEngine;
using UnityEngine.UI; // Required for UI classes

public class PlayerManager : MonoBehaviour
{
    public GameObject nounPrefab;
    public GameObject verbPrefab;
    public GameObject prepositionPrefab;
    public GameObject noun2Prefab;

    public Transform[] playerAreas; // Assign in the Inspector, each area corresponds to a player

    public void SetupPlayer(int playerIndex)
    {
        if (playerIndex < 0 || playerIndex >= playerAreas.Length)
        {
            Debug.LogError("Invalid player index");
            return;
        }

        Transform playerArea = playerAreas[playerIndex];

        Instantiate(nounPrefab, playerArea);
        Instantiate(verbPrefab, playerArea);
        Instantiate(prepositionPrefab, playerArea);
        Instantiate(noun2Prefab, playerArea);

        // Additional setup as needed
    }
}
