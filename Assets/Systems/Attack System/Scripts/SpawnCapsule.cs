using UnityEngine;

public class SpawnCapsule : MonoBehaviour
{
    public static SpawnCapsule instance;
    [SerializeField] GameObject playerCapsule;
    [HideInInspector] private GameObject[] capsuleLocations;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        capsuleLocations = new GameObject[GameObject.Find("AttackAreas").transform.childCount];
    }

    public void Activate(Transform spawnPosition, int location, int offsetx, int offsety, int offsetz)
    {
        capsuleLocations[location] = Instantiate(playerCapsule, new Vector3(spawnPosition.transform.position.x + offsetx, spawnPosition.transform.position.y + offsety, spawnPosition.transform.position.z + offsetz), Quaternion.identity, spawnPosition);
    }
    public void Deactivate(int location)
    {
        Destroy(capsuleLocations[location].gameObject);
    }
}
