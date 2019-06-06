using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IP_Monitor.Class
{
	/// <summary>
	/// 시작 프로그램 등록
	///		- 레지스트리 등록 방식
	///		- 등록 레지스트리 SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run
	/// </summary>
	class RegistStartProgram
	{
		private static string keyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

		/// <summary>
		/// 레지스트리 등록 여부 확인
		/// </summary>
		public static bool IsRegistered {
			get
			{
				using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath))
				{
					var resultValue = key.GetValue(Config.AppName);
					if (resultValue == null)
					{
						return false;
					}
					else
					{
						return true;
					}
				}
			}
		}

		/// <summary>
		/// 시작 프로그램 등록
		/// </summary>
		public static void SetStartProgram()
		{
			using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath))
			{
				if (!IsRegistered)
				{
					key.SetValue(Config.AppName, Config.AppStartupPath);
				}
			}
		}

		/// <summary>
		/// 시작 프로그램 삭제
		/// </summary>
		public static void RemoveStartProgram()
		{
			using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyPath))
			{
				if (IsRegistered)
				{
					key.DeleteValue(Config.AppName, false);//값이 없어도 예외 발생 안함
				}
			}
		}
	}
}
