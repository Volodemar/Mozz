using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка выбора пути назначения
/// </summary>	
public class UIButtonStartScenario : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private ScenarioDataSource _scenario;

    public void Init(ScenarioDataSource scenario)
    {
        _scenario = scenario;
        text.text = _scenario.ScenarioName;
    }

    public void OnClickButton()
    {
        UIManager.Instance.UIWindowHUD.Show();

        LevelController.Instance.StartScenario(_scenario);
    }
}
