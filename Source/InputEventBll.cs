using Godot;
using System;

namespace BLL
{
	public enum KeyStatus { Pressed, Released, Hold };
    public enum InputAction { Up, Down, Left, Right, Start, Select, A, B, C, X, Y, Z, L, R };
	
	public static class InputEventBll
	{
		public static bool GetKey(InputAction action, KeyStatus keyStatus)
		{
			switch (keyStatus)
			{
				case KeyStatus.Pressed:
					return GetPressed(action);
				case KeyStatus.Hold:
					return GetHold(action);
				case KeyStatus.Released:
					return GetReleased(action);
				default:
					return false;
			}
		}

		private static bool GetPressed(InputAction action)
		{
			return Input.IsActionJustPressed(action.ToString());
		}
		private static bool GetHold(InputAction action)
		{
			return Input.IsActionPressed(action.ToString());
		}
		private static bool GetReleased(InputAction action)
		{
			return Input.IsActionJustReleased(action.ToString());
		}
	}
}
