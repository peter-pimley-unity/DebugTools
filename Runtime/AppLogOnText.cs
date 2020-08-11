
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



namespace org.peterpi.debugtools
{


	[RequireComponent(typeof(UnityEngine.UI.Text))]
	class AppLogOnText : MonoBehaviour
	{
		private Text m_t;


		[SerializeField]
		private int m_capacity = 20;

		private List<string> m_lines = new List<string>();


		private void Awake()
		{
			m_t = GetComponent<Text>();
			Debug.Assert(m_t != null);
			Application.logMessageReceived += Log;

			Debug.Log("test");
		}

		private void OnDestroy()
		{
			Application.logMessageReceived -= Log;
		}

		private void Log (string mesg, string stack, LogType lt)
		{
			m_lines.Add(mesg);
			int overflow = m_lines.Count - m_capacity;
			if (overflow > 0)
			{
				m_lines.RemoveRange(0, overflow);
			}

			string s = string.Join("\n", m_lines);
			m_t.text = s;
		}
	}


}


