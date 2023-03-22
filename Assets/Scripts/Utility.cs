using System;
using System.Collections;
using UnityEngine;

namespace BeastMaster
{
	public static class Utility
	{
        public static void Invoke(this MonoBehaviour mb, Action f, float delay)
        {
            mb.StartCoroutine(InvokeRoutine(f, delay));
        }

        private static IEnumerator InvokeRoutine(System.Action f, float delay)
        {
            yield return new WaitForSeconds(delay);
            f();
        }
    }
}