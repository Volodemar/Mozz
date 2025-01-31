using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Персонаж, в данном случае стрелояка
/// </summary>	
public class PlayerController : MonoBehaviour
{
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform arrow;

    private float _distance;

    private PathCreator _path;

    public static PlayerController Instance { get; private set; }

	private void Awake()
	{
        Instance = this;
	}

    public void Init(ScenarioController defaultScenario)
    {
        //Поворот спрайта для простоя 
        arrow.localEulerAngles = new Vector3(0f, 0f, 0f);

        this.transform.position = defaultScenario.StartPoint.position;

        line.gameObject.SetActive(false);
    }

    public void StartMove(ScenarioController scenario) 
    {
		// Отписка от прошлого пути если идем повторно
		if (_path != null)
			_path.pathUpdated -= OnPathChanged;

		_distance = 0;

        //Поворот спрайта для следования по пути 
        arrow.localEulerAngles = new Vector3(0f, 90f, 90f);

        line.gameObject.SetActive(true);

        _path = scenario.Path;

        _path.pathUpdated += OnPathChanged;

        StepMove();
    }

    public void StepMove(float forceSpeed = 0)
    {
        if (_path != null)
        {
            if(forceSpeed > 0)
                _distance += forceSpeed * Time.deltaTime;
            else
                _distance += speed * Time.deltaTime;
            
            this.transform.position = _path.path.GetPointAtDistance(_distance, endOfPathInstruction);
            this.transform.rotation = _path.path.GetRotationAtDistance(_distance, endOfPathInstruction);

            DrawLineRevert();
        }
    }

    void OnPathChanged() 
    {
        _distance = _path.path.GetClosestDistanceAlongPath(transform.position);
    }

    private void DrawLineRevert()
    {
        // Получаем точки на пути
        Vector3[] points = _path.path.localPoints;

        // Инициализируем переменные для хранения информации о ближайшей точке
        float closestDistance = float.MaxValue;
        int nearestIndex = -1;

        // Проходим по всем точкам пути, чтобы найти ближайшую
        for (int i = 1; i < points.Length; i++)
        {
            float distance = Vector3.Distance(this.transform.position, points[i]);
            if (distance < closestDistance)
            {
                closestDistance = distance;

                // Запоминаем индекс ближайшей точки
                nearestIndex = i; 
            }
        }

        // Количество точек от ближайшей до конца
        int pointCount = points.Length - nearestIndex; 

        // Получим точки прямой последовательности
        List<Vector3> linePoints = new List<Vector3>();
        linePoints.Add(this.transform.position);
        for (int i = 1; i < pointCount; i++)
        {
            linePoints.Add(points[nearestIndex + i]);           
        }      

        // Построим линию обратной последовательности чтобы текстура не двигалась при движении стрелочки
        linePoints.Reverse();
        line.positionCount = linePoints.Count;
        for (int i = 0; i < linePoints.Count; i++)
        {
            line.SetPosition(i, linePoints[i]);
        }

		float totalDistance = 0f;
		for (int i = 1; i < line.positionCount; i++)
		{
			totalDistance += Vector3.Distance(line.GetPosition(i - 1), line.GetPosition(i));
		}

		float tilingX = totalDistance * 10f;
		line.material.SetTextureScale("_MainTex", new Vector2(tilingX, 1));
    }
}
