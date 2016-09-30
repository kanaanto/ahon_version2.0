using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Behaviour
{
	public class DontDestroy : MonoBehaviour {

		void Awake()
		{
			GameObject [] objects = GameObject.FindGameObjectsWithTag ("Music");
			if (objects.Length > 1)
				Destroy (this.gameObject);

			DontDestroyOnLoad (this.gameObject);
		}
	}
}
