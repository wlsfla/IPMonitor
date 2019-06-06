using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace IP_Monitor.Class
{
	/// <summary>
	/// ini 파일 생성
	/// 설정 변경 등등
	/// 
	/// ini 설정값 추가 시
	///		- InitIniContent(), LoadIni(), SaveIni() 함수 수정
	///		- 관련 변수 수정
	///		- 섹션 이름(필요시), ini 설정값 열거, 컨트롤(=할당할 키) 이름 열거
	/// </summary>
	public partial class Config
	{
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		/// <summary>
		/// 프로그램 이름(전체 경로)
		/// </summary>
		public static string AppName {
			get
			{
				return System.Windows.Forms.Application.ExecutablePath;
			}
		}

		/// <summary>
		/// 프로그램 시작 폴더 전체 경로
		/// </summary>
		public static string AppStartupPath {
			get
			{
				return System.Windows.Forms.Application.StartupPath;
			}
		}

		/// <summary>
		/// ini 파일명, 파일 경로 생성
		/// </summary>
		private static string IniFullPath {
			get
			{
				return Path.ChangeExtension(AppName, "ini");
			}
		}

		private static string IniDirPath {
			get
			{
				return Path.GetDirectoryName(IniFullPath);
			}
		}

		/// <summary>
		/// Ini 파일 존재여부 확인
		/// </summary>
		public static bool IsiniFileExist {
			get
			{
				FileInfo fi = new FileInfo(IniFullPath);
				if (fi.Exists)
				{
					//파일이 있으면
					return true;
				}
				else
				{
					//파일이 없으면
					return false;
				}
			}
		}

		/// <summary>
		/// ini 파일 생성
		/// </summary>
		public static void Createini()
		{
			FileInfo fi = new FileInfo(IniFullPath);
			fi.Create();
		}

		/// <summary>
		/// 설정파일 기본값으로 초기화
		/// </summary>
		public static void InitIniContent()
		{
			WritePrivateProfileString(CONTROL, sconlbVpnIP, "VPN IP: ", IniFullPath);
			WritePrivateProfileString(CONTROL, sconTbVpnIP, "", IniFullPath);
			WritePrivateProfileString(CONTROL, sconBtnSave, "Save", IniFullPath);

			WritePrivateProfileString(MSG, smsgMutex, "이미 실행중입니다.", IniFullPath);
			WritePrivateProfileString(MSG, sMsgIPParseError, "입력된 IP 주소가 잘못되었습니다.", IniFullPath);

			WritePrivateProfileString(TIMER, stimerCMD, "shutdown -f -t", IniFullPath);
			WritePrivateProfileString(TIMER, stimerInterval, "60", IniFullPath);
		}

		/// <summary>
		/// 설정 불러오기
		/// </summary>
		public static void LoadIni()
		{
			int length = 1024;
			StringBuilder buf = new StringBuilder(length);

			// Control
			GetPrivateProfileString(CONTROL, sconlbVpnIP, string.Empty, buf, length, IniFullPath);
			conlbVpnIP = buf.ToString();

			GetPrivateProfileString(CONTROL, sconTbVpnIP, string.Empty, buf, length, IniFullPath);
			conTbVpnIP = buf.ToString();

			GetPrivateProfileString(CONTROL, sconBtnSave, string.Empty, buf, length, IniFullPath);
			conBtnSave = buf.ToString();

			// MSG
			GetPrivateProfileString(MSG, smsgMutex, string.Empty, buf, length, IniFullPath);
			msgMutex = buf.ToString();

			GetPrivateProfileString(MSG, sMsgIPParseError, string.Empty, buf, length, IniFullPath);
			msgIPParseError = buf.ToString();

			// Timer
			GetPrivateProfileString(TIMER, stimerCMD, string.Empty, buf, length, IniFullPath);
			timerCMD = buf.ToString();

			GetPrivateProfileString(TIMER, stimerInterval, string.Empty, buf, length, IniFullPath);
			timerInterval = buf.ToString();
		}

		/// <summary>
		/// 설정 저장
		/// </summary>
		public static void SaveIni()
		{
			// Control
			WritePrivateProfileString(CONTROL, sconlbVpnIP, conlbVpnIP, IniFullPath);
			WritePrivateProfileString(CONTROL, sconTbVpnIP, conTbVpnIP, IniFullPath);
			WritePrivateProfileString(CONTROL, sconBtnSave, conBtnSave, IniFullPath);

			// MSG
			WritePrivateProfileString(MSG, smsgMutex, msgMutex, IniFullPath);
			WritePrivateProfileString(MSG, sMsgIPParseError, msgIPParseError, IniFullPath);

			// Timer
			WritePrivateProfileString(TIMER, stimerCMD, timerCMD, IniFullPath);
			WritePrivateProfileString(TIMER, stimerInterval, timerInterval, IniFullPath);
		}
	}

	/// <summary>
	/// 컨트롤(=할당할 키) 이름 열거
	/// </summary>
	public partial class Config
	{
		static string sconlbVpnIP = "lbVpnIP";
		static string sconTbVpnIP = "tbVpnIP";
		static string sconBtnSave = "btnSave";
		static string smsgMutex = "mutexMsg";
		static string stimerCMD = "cmd";
		static string stimerInterval = "interval";
		static string sMsgIPParseError = "interval";
	}

	/// <summary>
	/// 섹션 이름 열거
	/// </summary>
	public partial class Config
	{
		static string CONTROL = "CONTROL";
		static string TIMER = "TIMER";
		static string MSG = "MSG";
	}

	/// <summary>
	/// ini 설정값 열거
	/// </summary>
	public partial class Config
	{
		/// <summary>
		/// 라벨 컨트롤
		/// </summary>
		public static string conlbVpnIP = string.Empty;

		/// <summary>
		/// IP 컨트롤
		/// </summary>
		public static string conTbVpnIP = string.Empty;

		/// <summary>
		/// 저장 버튼 컨트롤
		/// </summary>
		public static string conBtnSave = string.Empty;

		/// <summary>
		/// 중복실행 시 메시지
		/// </summary>
		public static string msgMutex = string.Empty;

		/// <summary>
		/// IP 주소 파싱 오류 메시지
		/// </summary>
		public static string msgIPParseError = string.Empty;

		/// <summary>
		/// 조건에 안맞을 시 실행할 커맨드
		/// </summary>
		public static string timerCMD = string.Empty;

		/// <summary>
		/// 타이머 실행 주기(단위 : 초)
		/// </summary>
		public static string timerInterval = string.Empty;
	}
}
