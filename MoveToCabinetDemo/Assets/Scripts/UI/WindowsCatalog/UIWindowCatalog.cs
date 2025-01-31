using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Окно каталога с выбором точек пути
/// </summary>	
public class UIWindowCatalog : UIBaseWindow
{
    [SerializeField] private Transform content;
    [SerializeField] private UIButtonStartScenario buttonPrefab;

    private bool isInit;

	public override void Show()
    {    
        Init();

        base.Show();
    }

	public override void Hide()
    {    
        base.Hide();
    }

    private void Init()
    {
        if(isInit)
            return;

        // Удалим старые данные если они есть
        foreach(Transform tr in content)
            Destroy(tr.gameObject);

        //Заполним контент кнопками
        foreach(var scenarioData in LevelController.Instance.DataBase.ScenarioData)
        {
            var buttion = Instantiate(buttonPrefab, content);
		
		    buttion.Init(scenarioData);
        }

        isInit = true;
    }
}
