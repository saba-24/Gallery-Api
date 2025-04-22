using Gallery_Api.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Gallery_Api.PublicClasses
{
	public class UploadHandler
	{

		public string Upload(IFormFile file)
		{
			

			List<string> ValidExtensions = new List<string>() {".jpg", ".png"};
			string extension = Path.GetExtension(file.FileName);
			
			//prevent non image files
			if (!ValidExtensions.Contains(extension)) {
				return "Invalid Extension";
			}
			long size = file.Length;

			//prevent files bigger than 15mb
			if (size > (15 * 1024 * 1024))
			{
				return "File Too Big";
			}

			//create name for file
			string FileName = Guid.NewGuid().ToString() + extension;

			//create path for file
			string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

			//copy file 
			FileStream stream = new FileStream(Path.Combine(path, FileName), FileMode.Create);
			file.CopyTo(stream);

			stream.Dispose();
			stream.Close();

			return FileName;
		}
	}
}
