using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "SObject/Unit")]
public class UnitSO : ScriptableObject
{
    [Header("Default")]
    public int uid;
    public string displayName;
    public string description;
    public GameObject prefab;

}
