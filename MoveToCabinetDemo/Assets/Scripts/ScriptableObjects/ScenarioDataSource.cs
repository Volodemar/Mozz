using UnityEngine;

/// <summary>
/// Данные сценария
/// </summary>	
[CreateAssetMenu(fileName = "ScenarioData", menuName = "Sources/ScenarioData")]
public class ScenarioDataSource : ScriptableObject
{
    [field: SerializeField] public string ScenarioName { get; private set; }
    [field: SerializeField] public Sprite ScenarioMap { get; private set; }
    [field: SerializeField] public ScenarioController ScenarioPrefab { get; private set; }

}
