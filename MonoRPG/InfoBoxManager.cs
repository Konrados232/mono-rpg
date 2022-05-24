using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoRPG
{
	public class InfoBoxManager
	{
		public Vector2 TopLeftPos { get; set; }
		public List<InfoBox> InfoBoxList { get; private set; }
		public float OffsetBetweenInfo { get; set; }
		public int CurrentInfoCount { get; set; }
		public int MaxInfoCount { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public InfoBoxManager(Vector2 topLeftPos, List<InfoBox> infoBoxList, float offsetBetweenInfo, int maxInfoCount, int width, int height)
		{
			TopLeftPos = topLeftPos;
			InfoBoxList = infoBoxList;
			OffsetBetweenInfo = offsetBetweenInfo;
			CurrentInfoCount = 0;
			MaxInfoCount = maxInfoCount;
			Width = width;
			Height = height;
		}
		
		public void AddInfoBox(InfoBox infoBox) 
		{
			if (CurrentInfoCount == (MaxInfoCount - 1))
			{
				throw new InfoBoxException("Cannot add elements over limit.");
			}		
			
			InfoBoxList.Add(infoBox);
			CurrentInfoCount++;
		}
		
		public void AddInfoBoxAt(int index, InfoBox infoBox) 
		{	
			if (index < 0 || index > MaxInfoCount) 
			{
				throw new InfoBoxException("Cannot add elements at incorrect bounds.");
			}
			
			if (index < CurrentInfoCount) 
			{
				throw new InfoBoxException("Cannot add element below current count.");
			}
			
			
			InfoBoxList.Insert(index, infoBox);
			CurrentInfoCount++;
		}
		
		public void NormalizeInfoBoxPositions()
		{
			for (int i = 0; i < InfoBoxList.Count; i++)
			{
				InfoBoxList[i].Position = new Vector2(0, i * OffsetBetweenInfo);
			}
		}		
	}
}