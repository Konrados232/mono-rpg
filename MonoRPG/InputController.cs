using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoRPG
{	
	public enum MouseInput
	{
		None,
		LeftButton,
		MiddleButton,
		RightButton
	}
	
	public class InputController
	{
		public Dictionary<MouseInput, bool> MousePressed { get; set; }
		public Dictionary<MouseInput, bool> MouseLocked { get; set; }		
		
		
		public InputController() 
		{
			MousePressed = new Dictionary<MouseInput, bool>();
			MousePressed.Add(MouseInput.LeftButton, false);
			MousePressed.Add(MouseInput.MiddleButton, false);
			MousePressed.Add(MouseInput.RightButton, false);
			
			MouseLocked = new Dictionary<MouseInput, bool>();
			MouseLocked.Add(MouseInput.LeftButton, false);
			MouseLocked.Add(MouseInput.MiddleButton, false);
			MouseLocked.Add(MouseInput.RightButton, false);
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
		
		/*
		public bool IsPressedSus(MouseState mouseState) 
		{
			if (mouseState.LeftButton == ButtonState.Pressed && !MouseLocked[MouseInput.LeftButton]) 
			{
				MouseLocked[MouseInput.LeftButton] = true;
				return true;
			}
			else if (mouseState.LeftButton == ButtonState.Released) 
			{
				MouseLocked[MouseInput.LeftButton] = false;
				return false;
			}
			
			return false;
		}
		*/
		
	}
}