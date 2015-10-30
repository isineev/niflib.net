#if OpenTK
using OpenTK.Graphics;
using Color3 = OpenTK.Graphics.Color4;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Color3 = Microsoft.Xna.Framework.Color;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class NiLight : NiDynamicEffect
	{
		public float Dimmer;

		public Color3 AmbientColor;

		public Color3 DiffuseColor;

		public Color3 SpecularColor;

		public NiLight(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Dimmer = reader.ReadSingle();
			this.AmbientColor = reader.ReadColor3();
			this.DiffuseColor = reader.ReadColor3();
			this.SpecularColor = reader.ReadColor3();
		}
	}
}