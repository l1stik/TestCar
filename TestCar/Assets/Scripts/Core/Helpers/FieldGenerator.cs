using System;
using UnityEditor;
using UnityEngine;

namespace Core.Helpers {
    public class FieldGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _fieldPrefab;

        private void Start() {
            Generate();
        }

        private void Generate() {
            var startPosition = Vector3.zero;
            for (int i = 2; i < 12; i++) {
                var x = _fieldPrefab.transform.localScale.x * i;
                for (int j = 2; j < 12; j++) {
                    var instance = Instantiate(_fieldPrefab);
                    var z = _fieldPrefab.transform.localScale.x * j;
                    instance.transform.position = new Vector3(x, startPosition.y, z);
                }
            }
        }
    }
}