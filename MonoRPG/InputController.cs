using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoRPG
{	
	public class InputController
	{
		public Dictionary<MouseInput, bool> MousePressed { get; set; }
		public Dictionary<MouseInput, bool> MouseLocked { get; set; }		
		
		
		public InputController()
		{
			MousePressed = new Dictionary<MouseInput, bool>();
			MouseLocked = new Dictionary<MouseInput, bool>();
			
			foreach (MouseInput mouseButton in (MouseInput[]) Enum.GetValues(typeof(MouseInput)))
			{
				MousePressed.Add(mouseButton, false);
				MouseLocked.Add(mouseButton, false);
			}
		}
		

		// TO-DO check optimization
		public void UpdateInput(MouseState mouseState) 
		{
			
			if (mouseState.LeftButton == ButtonState.Pressed) 
			{
				MousePressed[MouseInput.LeftButton] = true;
			}
			else if (mouseState.LeftButton == ButtonState.Released) 
			{
				MousePressed[MouseInput.LeftButton] = false;
			}
			
			if (mouseState.MiddleButton == ButtonState.Pressed) 
			{
				MousePressed[MouseInput.MiddleButton] = true;
			}
			else if (mouseState.LeftButton == ButtonState.Released) 
			{
				MousePressed[MouseInput.MiddleButton] = false;
			}
			
			if (mouseState.RightButton == ButtonState.Pressed) 
			{
				MousePressed[MouseInput.RightButton] = true;
			}
			else if (mouseState.LeftButton == ButtonState.Released) 
			{
				MousePressed[MouseInput.RightButton] = false;
			}
		}
		
		public bool IsPressedOnce(MouseInput mouseInput) 
		{
			if (MousePressed[mouseInput] && !MouseLocked[mouseInput]) 
			{
				MouseLocked[mouseInput] = true;
				return true;
			}
			else if(!MousePressed[mouseInput])
			{
				MouseLocked[mouseInput] = false;
				return false;
			}
			// held and locked
			else
			{
				return false;
			}		
		}	
	}
}