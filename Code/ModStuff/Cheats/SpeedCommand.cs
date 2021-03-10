﻿using System;
using UnityEngine;
using ModStuff.Utility;

namespace ModStuff.Cheats
{
	public class SpeedCommand : Singleton<SpeedCommand>
	{
		public string RunCommand(string[] args)
		{
			if (args.Length > 0)
			{
				Moveable moveableData = Core.GetObjComp<Moveable>("PlayerEnt");
				RollAction rollData = Core.GetObjComp<RollAction>("PlayerEnt");

				float defMoveSpeed = 4f;
				float defRollSpeed = 5f;

				if (moveableData != null)
				{
					// If number specified
					if (float.TryParse(args[0], out float speed))
					{
						moveableData._moveSpeed = speed;
						rollData._speed = speed + 1;

						return DebugManager.LogToConsole("Set move speed to <in>" + speed + "</in>");
					}
					// If resetting to default
					else if (args[0] == "reset" || args[0] == "default")
					{
						moveableData._moveSpeed = defMoveSpeed;
						rollData._speed = defRollSpeed;

						return DebugManager.LogToConsole("Reset move speed to default (" + defMoveSpeed + ").");
					}

					else return DebugManager.LogToConsole("<in>" + args[0] + "</in> is not a valid speed value. Use <out>help speed</out> for more info.", DebugManager.MessageType.Error);
				}
			}

			return DebugManager.LogToConsole(GetHelp());
		}

		public string GetHelp()
		{
			string description = "<in>speed</in> lets you change Ittle's speed. You can move faster or slower. Also affects roll speed. A negative speed value will let you move in reverse.\n\n";
			string usage = "<out>speed [int]{speed}</out> OR <out>speed [string]{reset/default}</out>";
			string examples = "<out>speed 15</out>, <out>speed -5</out>, <out>speed reset</out>";

			return description + usage + examples;
		}
	}
}