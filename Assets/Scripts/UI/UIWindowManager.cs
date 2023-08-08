using System.Collections.Generic;

using UnityEngine;

public class UIWindowManager : MonoBehaviour
{
	private static UIWindowManager _instance;

	[SerializeField] private UIWindow _startingView;

	[SerializeField] private UIWindow[] _views;

	private UIWindow _currentView;

	private readonly Stack<UIWindow> _history = new Stack<UIWindow>();

	public static T GetView<T>() where T : UIWindow
	{
		for (int i = 0; i < _instance._views.Length; i++)
		{
			if (_instance._views[i] is T tView)
			{
				return tView;
			}
		}

		return null;
	}

	public static void Show<T>(bool remember = true) where T : UIWindow
	{
		for (int i = 0; i < _instance._views.Length; i++)
		{
			if (_instance._views[i] is T)
			{
				if (_instance._currentView != null)
				{
					if (remember)
					{
						_instance._history.Push(_instance._currentView);
					}

					_instance._currentView.Hide();
				}

				_instance._views[i].Show();

				_instance._currentView = _instance._views[i];
			}
		}
	}

	public static void Show(UIWindow view, bool remember = true)
	{
		if (_instance._currentView != null)
		{
			if (remember)
			{
				_instance._history.Push(_instance._currentView);
			}

			_instance._currentView.Hide();
		}

		view.Show();

		_instance._currentView = view;
	}

	public static void ShowLast()
	{
		if (_instance._history.Count != 0)
		{
			Show(_instance._history.Pop(), false);
		}
	}

	private void Awake() => _instance = this;

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
