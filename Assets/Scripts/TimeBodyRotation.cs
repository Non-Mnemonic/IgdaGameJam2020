using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBodyRotation : MonoBehaviour
{
	bool isRewinding = false;

	public float recordTime = 5f;

	List<PointInTime> pointsInTime;

	// Use this for initialization
	void Start()
	{
		pointsInTime = new List<PointInTime>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
			StartRewind();
		if (Input.GetKeyUp(KeyCode.Return))
			StopRewind();
	}

	void FixedUpdate()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime;
			if(pointsInTime.Count > 30)
			{
				pointInTime = pointsInTime[30];
				transform.position = pointInTime.position;
				transform.rotation = pointInTime.rotation;
				pointsInTime.RemoveRange(0, 30);
			}
			else if (pointsInTime.Count > 10)
			{
				pointInTime = pointsInTime[10];
				transform.position = pointInTime.position;
				transform.rotation = pointInTime.rotation;
				pointsInTime.RemoveRange(0, 10);
			}
			else
			{
				pointInTime = pointsInTime[0];
				transform.position = pointInTime.position;
				transform.rotation = pointInTime.rotation;
				pointsInTime.RemoveAt(0);
			}
		}
		else
		{
			StopRewind();
		}

	}

	void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind()
	{
		isRewinding = true;
	}

	public void StopRewind()
	{
		isRewinding = false;
	}
}
