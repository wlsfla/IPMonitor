﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace IP_Monitor
{
	static class Program
	{
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// 중복 실행 설정
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
 
			//bool bNew;
			//Mutex mutex = new Mutex(true, "MutexName", out bNew);
			//if (bNew)
			//{
			//	Application.EnableVisualStyles();
			//	Application.SetCompatibleTextRenderingDefault(false);
			//	Application.Run(new MainForm());
			//	mutex.ReleaseMutex();
			//}
			//else
			//{
			//	MessageBox.Show(Class.Config.msgMutex);
			//	Application.Exit();
			//}

		}
	}
}
