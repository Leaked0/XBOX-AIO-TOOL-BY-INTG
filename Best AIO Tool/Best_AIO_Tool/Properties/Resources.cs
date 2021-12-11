using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Best_AIO_Tool.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					ResourceManager resourceManager = (resourceMan = new ResourceManager("Best_AIO_Tool.Properties.Resources", typeof(Resources).Assembly));
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap RickLOL
		{
			get
			{
				object @object = ResourceManager.GetObject("RickLOL", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap rsz_1606024
		{
			get
			{
				object @object = ResourceManager.GetObject("rsz_1606024", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap rsz_1909639_1
		{
			get
			{
				object @object = ResourceManager.GetObject("rsz_1909639_1", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal Resources()
		{
		}
	}
}
