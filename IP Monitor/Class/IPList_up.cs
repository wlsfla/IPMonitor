using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace IP_Monitor.Class
{
	/// <summary>
	/// GetLocalIPs() 함수 => 메인함수
	///		- iplist 변수 초기화
	///		- PC 모든 인터페이스의 ip 목록을 iplist 변수에 저장
	/// 
	/// 외부에서 iplist변수에 접근
	/// </summary>
	class IPList_up
	{
		/// <summary>
		/// state가 Up인 ip리스트
		/// </summary>
		public static List<IPAddress> ipList { get; set; }

		/// <summary>
		/// ipList 변수 초기화
		/// </summary>
		private static void InitIPList()
		{
			if (ipList != null) //null이 아니면 list clear
			{
				ipList.Clear();
			}
			else //iplist가 null이면 메모리 할당
			{
				ipList = new List<IPAddress>();
			}
		}

		/// <summary>
		/// 로컬 ip 목록 get => list
		/// </summary>
		public static void GetLocalIPs()
		{
			InitIPList();
			var networks = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface net in networks)
			{
				//Console.WriteLine("net.Id: {0}", net.Id); // 네트워크의 고유id
				//Console.WriteLine("net.Name: {0}", net.Name); // 표기되는 이름
				//Console.WriteLine("net.OperationalStatus: {0}", net.OperationalStatus); // 연결됐습니까?
				//Console.WriteLine("net.NetworkInterfaceType: {0}", net.NetworkInterfaceType); // 구분용
				//Console.WriteLine("net.Description: {0}", net.Description); // 장치설명
				//Console.WriteLine("net.IPv4 Address: {0}", net.GetIPProperties().UnicastAddresses[1].Address.ToString());

				if (net.OperationalStatus == OperationalStatus.Up)
				{
					ipList.Add(net.GetIPProperties().UnicastAddresses[1].Address);
				}
			}
		}
	}
}
