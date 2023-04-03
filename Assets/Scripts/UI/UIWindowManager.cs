using System.Collections.Generic;

using UnityEngine;

public class UIWindowManager : MonoBehaviour
{
	private static UIWindowManager s_instance;

	[SerializeField] private UIWindow _startingView;

	[SerializeField] private UIWindow[] _views;

	private UIWindow _currentView;

	private readonly Stack<UIWindow> _history = new Stack<UIWindow>();

	public static T GetView<T>() where T : UIWindow
	{
		for (int i = 0; i < s_instance._views.Length; i++)
		{
			if (s_instance._views[i] is T tView)
			{
				return tView;
			}
		}

		return null;
	}

	public static void Show<T>(bool remember = true) where T : UIWindow
	{
		for (int i = 0; i < s_instance._views.Length; i++)
		{
			if (s_instance._views[i] is T)
			{
				if (s_instance._currentView != null)
				{
					if (remember)
					{
						s_instance._history.Push(s_instance._currentView);
					}

					s_instance._currentView.Hide();
				}

				s_instance._views[i].Show();

				s_instance._currentView = s_instance._views[i];
			}
		}
	}

	public static void Show(UIWindow view, bool remember = true)
	{
		if (s_instance._currentView != null)
		{
			if (remember)
			{
				s_instance._history.Push(s_instance._currentView);
			}

			s_instance._currentView.Hide();
		}

		view.Show();

		s_instance._currentView = view;
	}

	public static void ShowLast()
	{
		if (s_instance._history.Count != 0)
		{
			Show(s_instance._history.Pop(), false);
		}
	}

	private void Awake() => s_instance = this;

	private void Start()
	{
		for (int i = 0; i < _views.Length; i++)
        {
            _views[i].Initialize();

			_views[i].Hide();
		}

		if (_startingView != null)
		{
			Show(_startingView, true);
		}
	}
}
