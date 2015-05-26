﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance { get; private set; }

	// ---- Instance ----

	public GameObject[] roomPrefabs;
	public GameObject tubePrefab;

	public int graphRecursions;
	public Room graphRoot;

	private void Awake()
	{
		instance = this;

		Build ();
	}

	private void Build()
	{
		// Branch from the root room.
		graphRoot.Branch(null, graphRecursions);
		graphRoot.gameObject.SetActive(true);
		graphRoot.ActivateConnections();
	}

	public GameObject GetRandomRoomPrefab()
	{
		return instance.roomPrefabs[Random.Range (0, instance.roomPrefabs.Length)];
	}
}
