namespace IP_Monitor
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbVpnIP = new System.Windows.Forms.TextBox();
			this.lbVpnIP = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbVpnIP
			// 
			this.tbVpnIP.Location = new System.Drawing.Point(72, 29);
			this.tbVpnIP.Name = "tbVpnIP";
			this.tbVpnIP.Size = new System.Drawing.Size(204, 21);
			this.tbVpnIP.TabIndex = 0;
			// 
			// lbVpnIP
			// 
			this.lbVpnIP.AutoSize = true;
			this.lbVpnIP.Location = new System.Drawing.Point(12, 34);
			this.lbVpnIP.Name = "lbVpnIP";
			this.lbVpnIP.Size = new System.Drawing.Size(48, 12);
			this.lbVpnIP.TabIndex = 1;
			this.lbVpnIP.Text = "lbVpnIP";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(282, 28);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "btnSave";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 119);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lbVpnIP);
			this.Controls.Add(this.tbVpnIP);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbVpnIP;
		private System.Windows.Forms.Label lbVpnIP;
		private System.Windows.Forms.Button btnSave;
	}
}

