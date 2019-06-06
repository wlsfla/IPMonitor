using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using IP_Monitor.Class;
using System.Windows.Forms;
using System.Diagnostics;

namespace IP_Monitor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			this.SetIniFile();

			timer = new Timer();
			timer.Interval = 1000 * int.Parse(Config.timerInterval);
			timer.Tick += Timer_Tick;

			
		}

		Timer timer;

		IPAddress monitorIP;

		private void SetIniFile()
		{
			if (Config.IsiniFileExist)
			{
				Config.LoadIni();
			}
			else
			{
				Config.Createini();
				Config.InitIniContent();
			}
		}

		private void SetIniValue()
		{
			this.lbVpnIP.Text = Config.conlbVpnIP;
			this.tbVpnIP.Text = Config.conTbVpnIP;
			this.btnSave.Text = Config.conBtnSave;
		}
		
		/// <summary>
		/// 타이머 주기마다 실행할 작업
		/// </summary>
		private void Timer_Tick(object sender, EventArgs e)
		{
			IPList_up.GetLocalIPs();

			foreach (IPAddress ip in IPList_up.ipList)
			{
				if (ip.ToString() == monitorIP.ToString())
				{
					this.ExecCMD();		
					break;
				}
			}
		}

		/// <summary>
		/// 명령어 실행
		/// </summary>
		private void ExecCMD()
		{
			ProcessStartInfo pinfo = new ProcessStartInfo();
			pinfo.FileName = "cmd";
			pinfo.CreateNoWindow = true; // cmd창 No-True, Yes-False
			pinfo.UseShellExecute = false;
			pinfo.RedirectStandardError = false;
			pinfo.RedirectStandardInput = false;
			pinfo.RedirectStandardOutput = false;

			using (Process p = new Process())
			{
				p.StartInfo = pinfo;
				p.Start();
				p.StandardInput.Write(Config.timerCMD + Environment.NewLine);// 설정된 cmd 명령어 실행
				p.WaitForExit();// 실행 후 종료될때까지 쓰레드 정지
			}
		}

		/// <summary>
		/// ip 입력 버튼
		/// </summary>
		private void btnSave_Click(object sender, EventArgs e)
		{
			this.SetMonitoringIP();
		}

		/// <summary>
		/// 모니터일 IP를 변수에 저장
		/// 오류 -> 알림 메시지
		/// </summary>
		private void SetMonitoringIP()
		{
			//this.monitorIP = IPAddress.Parse(this.tbVpnIP.Text);
			if (!IPAddress.TryParse(this.tbVpnIP.Text, out this.monitorIP))
			{
				MessageBox.Show(Config.msgIPParseError);
				this.tbVpnIP.Text = string.Empty;

				return;
			}

			timer.Start();
		}

	}
}
