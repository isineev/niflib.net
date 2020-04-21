/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

namespace Niflib
{
	#if OpenTK
	using Color3 = OpenTK.Graphics.Color4;
	#elif SharpDX
	using SharpDX;
	#elif MonoGame
	using Microsoft.Xna.Framework;
	using Color3 = Microsoft.Xna.Framework.Color;
	#endif
	using System;
	using System.IO;
	
    /// <summary>
    /// Class NiMaterialProperty.
    /// </summary>
    public class NiMaterialProperty : NiProperty
	{
        /// <summary>
        /// The flags
        /// </summary>
        public ushort Flags;

        /// <summary>
        /// The ambient color
        /// </summary>
        public Color3 AmbientColor;

        /// <summary>
        /// The diffuse color
        /// </summary>
        public Color3 DiffuseColor;

        /// <summary>
        /// The specular color
        /// </summary>
        public Color3 SpecularColor;

        /// <summary>
        /// The emissive color
        /// </summary>
        public Color3 EmissiveColor;

        /// <summary>
        /// The glossiness
        /// </summary>
        public float Glossiness;

        /// <summary>
        /// The alpha
        /// </summary>
        public float Alpha;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiMaterialProperty" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiMaterialProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_10_0_1_2)
			{
				this.Flags = reader.ReadUInt16();
			}
			this.AmbientColor = reader.ReadColor3();
			this.DiffuseColor = reader.ReadColor3();
			this.SpecularColor = reader.ReadColor3();
			this.EmissiveColor = reader.ReadColor3();
			this.Glossiness = reader.ReadSingle();
			this.Alpha = reader.ReadSingle();
		}

        /// <summary>
        /// Writes NiMaterialProperty to binary stream.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void WriteNiMaterialProperty(BinaryWriter writer)
        {
            base.WriteNiProperty(writer);

            if (base.Version <= eNifVersion.VER_10_0_1_2)
            {
                writer.Write((ushort)this.Flags);
            }

            writer.WriteColor3(this.AmbientColor);
            writer.WriteColor3(this.DiffuseColor);
            writer.WriteColor3(this.SpecularColor);
            writer.WriteColor3(this.EmissiveColor);
            writer.Write((float)this.Glossiness);
            writer.Write((float)this.Alpha);
        }

    }
}
