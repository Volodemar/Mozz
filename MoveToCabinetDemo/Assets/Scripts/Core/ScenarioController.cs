using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Описание нового класса
/// </summary>	
public class ScenarioController : MonoBehaviour
{
    [SerializeField] private PathCreator    path;
    [SerializeField] private Transform      startPoint;
    [SerializeField] private Transform      endPoint;

    public PathCreator Path => path;
    public Transform StartPoint => startPoint;
    public Transform EndPoint => endPoint;
}
