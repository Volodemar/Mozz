using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Описание нового класса
/// </summary>	
public class LevelController : MonoBehaviour
{
	[field: SerializeField] public SpriteRenderer Map { get; private set; }
	
	//Т.к. демо проект, нет смысла в мудреной структуре, уровень будет выступать источником данных вместо GameManager или Zenject
	[field: SerializeField] public DataBaseSource DataBase { get; private set; }

    public static LevelController Instance { get; private set; }

	private ScenarioController _currentScenario = null;

	private void Awake()
	{
        Instance = this;
	}

	private void Start()
	{
		ScenarioController defaultScenario = DataBase.ScenarioData[0].ScenarioPrefab;

		SetMap(DataBase.ScenarioData[0].ScenarioMap);

		PlayerController.Instance.Init(defaultScenario);

		UIManager.Instance.ForcedCloseAllWindows();
	}

	public void StartScenario(ScenarioDataSource scenarioData)
	{
		if(_currentScenario != null)
			Destroy(_currentScenario.gameObject);

		_currentScenario = Instantiate(scenarioData.ScenarioPrefab, this.transform);
		
		PlayerController.Instance.StartMove(_currentScenario);
	}

	public void SetMap(Sprite mapSprite)
	{
		Map.sprite = mapSprite;
	}
}
