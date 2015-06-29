using UnityEngine;
using System.Collections;

public class CloudBackground : MonoBehaviour {

	public GameObject[] cloudPrefabs;

	public int numClouds = 5;

	public Vector3 cloudposmin;
	public Vector3 cloudposmax;

	public float cloudspeed;

	public float cloudScaleMin = 1.0f;
	public float cloudScaleMax = 3.0f;



	private GameObject[] cloudInstances;

	void Awake() {

		// Create an array to hold our cloud instances

		cloudInstances = new GameObject[numClouds];

		// Find the clouds anchor object
		GameObject anchor = GameObject.Find("Clouds");


		// Iterate through array and create each cloud

		GameObject cloud; 
		for(int i = 0; i<numClouds; i++){


			// Pick a random cloud prefab between 0 and cloudPrefabs.Lenght-1

			int prefabNum = Random.Range (0, cloudPrefabs.Lenght-1);


			// Instanciate a cloud and position it accordingly
			cloud = Instanciate(cloudPrefabs[prefabNum]);

			Vector3 cPos = Vector3.zero;
			cPos.x =Random.Range (cloudposmin.x, cloudposmax.x);
			cPos.y =Random.Range (cloudposmin.y, cloudposmax.y);

			float scaleU = Random.value;

			float scaleVal = Mathf.Lerp (cloudScaleMin, cloudScaleMax, scaleU);

			cPos.y = Mathf.Lerp (cloudposmin.y, cPos.y, scaleU);

			cPos.z = 100-(90*scaleU);
			
			// Scale the cloud

			cloud.transfom.position = cPos;
			cloud.transform.localScale = Vector3.one * scaleVal;
			
			// Make the cloud a child of the cloud anchor

			cloud.transform.parent = anchor.transform;

			// Add the cloud to our cloud instances

			cloudInstances[i] = cloud;

		}

	}
}
