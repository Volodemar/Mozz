using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBaseData", menuName = "Sources/DataBaseData")]
public class DataBaseSource : ScriptableObject
{
	public List<ScenarioDataSource> ScenarioData;
}