using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LunaEditor.Properties;
using Microsoft.Win32;
using Microsoft.Xna.Framework.Graphics;

namespace LunaEditor
{
    internal static class UIHelpers
    {
        public static RegistryKey BaseRegisteryKey = Registry.LocalMachine;
        public static string SubKey = "SOFTWARE\\LUNA";

        public static void Error(string errorMessage)
        {
            System.Windows.Forms.MessageBox.Show(errorMessage, Resources.txtError, MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error);
        }

        public static System.Drawing.Image Texture2Image(Texture2D texture)
        {
            if (texture == null)
            {
                return null;
            }

            if (texture.IsDisposed)
            {
                return null;
            }

            //Memory stream to store the bitmap data.
            MemoryStream ms = new MemoryStream();

            //Save the texture to the stream.
            texture.SaveAsPng(ms, texture.Width, texture.Height);

            //Seek the beginning of the stream.
            ms.Seek(0, SeekOrigin.Begin);

            //Create an image from a stream.
            System.Drawing.Image bmp2 = System.Drawing.Bitmap.FromStream(ms);

            //Close the stream, we nolonger need it.
            ms.Close();
            ms = null;
            return bmp2;
        }

        public static void Image2Texture(System.Drawing.Image image,
                                         GraphicsDevice graphics,
                                         ref Texture2D texture)
        {
            if (image == null)
            {
                return;
            }

            if (texture == null || texture.IsDisposed ||
                texture.Width != image.Width ||
                texture.Height != image.Height ||
                texture.Format != SurfaceFormat.Color)
            {
                if (texture != null && !texture.IsDisposed)
                {
                    texture.Dispose();
                }

                texture = new Texture2D(graphics, image.Width, image.Height, false, SurfaceFormat.Color);
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (graphics.Textures[i] == texture)
                    {
                        graphics.Textures[i] = null;
                        break;
                    }
                }
            }

            //Memory stream to store the bitmap data.
            MemoryStream ms = new MemoryStream();

            //Save to that memory stream.
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            //Go to the beginning of the memory stream.
            ms.Seek(0, SeekOrigin.Begin);

            //Fill the texture.
            texture = Texture2D.FromStream(graphics, ms, image.Width, image.Height, false);

            //Close the stream.
            ms.Close();
            ms = null;
        }

        public static void WriteSetting(string key, object value)
        {
            RegistryKey rk = BaseRegisteryKey.CreateSubKey(SubKey);
            try
            {
                rk.SetValue(key.ToUpper(), value);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error {0}",e);
            }
        }

        public static string ReadSetting(string key)
        {
            RegistryKey rk = BaseRegisteryKey.OpenSubKey(SubKey);

            if (rk == null)
            {
                return null;
            }

            try
            {
                return (string) rk.GetValue(key.ToUpper());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}",e);
                return null;
            }
        }
    }
}
