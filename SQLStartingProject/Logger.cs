using System;
using System.Configuration;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SQLStartingProject
{
	public static class Logger
	{
		static readonly string logFileFatal = ConfigurationManager.AppSettings["LoggerFatal"];
		static readonly string logFileError = ConfigurationManager.AppSettings["LoggerError"];
		static readonly string logFileWarn = ConfigurationManager.AppSettings["LoggerWarn"];
		static readonly string logFileInfo = ConfigurationManager.AppSettings["LoggerInfo"];
		static readonly string logFileDebug = ConfigurationManager.AppSettings["LoggerDebug"];
		static readonly string logFileTrace = ConfigurationManager.AppSettings["LoggerTrace"];

		static readonly int logLevel = Convert.ToInt32(ConfigurationManager.AppSettings["logLevel"]);

		public static void LogError(string error)
		{
			try
			{
				if (logLevel <= 5)
				{
					var fi = new FileInfo(logFileError);
					if (!fi.Directory.Exists)
					{
						Directory.CreateDirectory(fi.DirectoryName);
					}

					using (var file = new StreamWriter(logFileError, append: true))
					{
						file.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss.ffffff}\n{error}");
						file.WriteLine();
					}
					HttpWebRequest request = WebRequest.Create("https://api.telegram.org/bot5138031995:AAEd6zuARIEtInH2R6861P-2mVFQRsskaAE/sendMessage?chat_id=5204643186&text=NewError:_" + error) as HttpWebRequest;

					//object response = request.GetResponse();
					//var json = JsonConvert.DeserializeObject<WebResponseJSON>((string)response);
					//if (!json.OK.Value)
					//{
					//	using (var file = new StreamWriter(logFileError, append: true))
					//	{
					//		file.WriteLine("Message not sent to Telegram");
					//		file.WriteLine();
					//	}
					//}
				}
			}
			catch(Exception ex)
            {
				throw;
            }
		}

		public static void LogError(Exception ex)
		{
			try
			{
				if (logLevel <= 5)
				{
					var fi = new FileInfo(logFileError);
					if (!fi.Directory.Exists)
					{
						Directory.CreateDirectory(fi.DirectoryName);
					}

					using (var file = new StreamWriter(logFileError, append: true))
					{
						file.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss.ffffff}\n{ex}");
						file.WriteLine();
					}

				}
				HttpWebRequest request = WebRequest.Create("https://api.telegram.org/bot5138031995:AAEd6zuARIEtInH2R6861P-2mVFQRsskaAE/sendMessage?chat_id=5204643186&text=NewError:_" + ex.Message) as HttpWebRequest;

				object response = request.GetResponse();
				//var json = JsonConvert.DeserializeObject<WebResponseJSON>((string)response);
				//if (!json.OK.Value)
				//{
				//	using (var file = new StreamWriter(logFileError, append: true))
				//	{
				//		file.WriteLine("Message not sent to Telegram");
				//		file.WriteLine();
				//	}
				//}
			}
			catch
            {
				throw;

            }
		}

		public static void LogWarn(Exception ex)
        {
			try
			{
				if (logLevel <= 4)
				{
					var fi = new FileInfo(logFileWarn);
					if (!fi.Directory.Exists)
					{
						Directory.CreateDirectory(fi.DirectoryName);
					}

					using (var file = new StreamWriter(logFileWarn, append: true))
					{
						file.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss.ffffff}\n{ex}");
						file.WriteLine();
					}
					HttpWebRequest request = WebRequest.Create("https://api.telegram.org/bot5138031995:AAEd6zuARIEtInH2R6861P-2mVFQRsskaAE/sendMessage?chat_id=5204643186&text=NewWarn:_" + ex.Message) as HttpWebRequest;

                    object response = request.GetResponse();
                    //var json = JsonConvert.DeserializeObject<WebResponseJSON>((string)response);
                    //if (!json.OK.Value)
                    //{
                    //	using (var file = new StreamWriter(logFileError, append: true))
                    //	{
                    //		file.WriteLine("Message not sent to Telegram");
                    //		file.WriteLine();
                    //	}
                    //}
                }
			}
			catch
            {
				throw;
            }
		}

		public static void LogWarn(string warn)
        {
			try
			{
				if (logLevel <= 4)
				{
					var fi = new FileInfo(logFileWarn);
					if (!fi.Directory.Exists)
					{
						Directory.CreateDirectory(fi.DirectoryName);
					}

					using (var file = new StreamWriter(logFileWarn, append: true))
					{
						file.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss.ffffff}\n{warn}");
						file.WriteLine();
					}
					HttpWebRequest request = WebRequest.Create("https://api.telegram.org/bot5138031995:AAEd6zuARIEtInH2R6861P-2mVFQRsskaAE/sendMessage?chat_id=5204643186&text=NewWarn:_" + warn) as HttpWebRequest;

					object response = request.GetResponse();
					//var json = JsonConvert.DeserializeObject<WebResponseJSON>((string)response);
					//if (!json.OK.Value)
					//{
					//	using (var file = new StreamWriter(logFileError, append: true))
					//	{
					//		file.WriteLine("Message not sent to Telegram");
					//		file.WriteLine();
					//	}
					//}
				}
			}
			catch
            {
				throw;
            }
		}

		public static void LogInfo(string info)
		{
			try
			{
				if (logLevel <= 3)
				{
					var fi = new FileInfo(logFileInfo);
					if (!fi.Directory.Exists)
					{
						Directory.CreateDirectory(fi.DirectoryName);
					}

					using (var file = new StreamWriter(logFileInfo, append: true))
					{
						file.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss.ffffff}\n{info}");
						file.WriteLine();
					}
				}
			}
			catch
            {
				throw;
            }
        }
	}
}
