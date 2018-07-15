namespace SimpleSpy {
   partial class FormMain {
      /// <summary>
      /// 필수 디자이너 변수입니다.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// 사용 중인 모든 리소스를 정리합니다.
      /// </summary>
      /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form 디자이너에서 생성한 코드

      /// <summary>
      /// 디자이너 지원에 필요한 메서드입니다. 
      /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
      /// </summary>
      private void InitializeComponent() {
         this.pbxCap = new System.Windows.Forms.PictureBox();
         this.tbxSpy = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.pbxCap)).BeginInit();
         this.SuspendLayout();
         // 
         // pbxCap
         // 
         this.pbxCap.Location = new System.Drawing.Point(12, 12);
         this.pbxCap.Name = "pbxCap";
         this.pbxCap.Size = new System.Drawing.Size(64, 64);
         this.pbxCap.TabIndex = 0;
         this.pbxCap.TabStop = false;
         this.pbxCap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxCap_Paint);
         this.pbxCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxSpy_MouseDown);
         this.pbxCap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxCap_MouseMove);
         this.pbxCap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxSpy_MouseUp);
         // 
         // tbxSpy
         // 
         this.tbxSpy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tbxSpy.BackColor = System.Drawing.SystemColors.Window;
         this.tbxSpy.Location = new System.Drawing.Point(82, 12);
         this.tbxSpy.Multiline = true;
         this.tbxSpy.Name = "tbxSpy";
         this.tbxSpy.ReadOnly = true;
         this.tbxSpy.Size = new System.Drawing.Size(656, 64);
         this.tbxSpy.TabIndex = 2;
         // 
         // FormMain
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(750, 88);
         this.Controls.Add(this.tbxSpy);
         this.Controls.Add(this.pbxCap);
         this.HelpButton = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FormMain";
         this.Text = "Simple Spy - Drag crosshair!!!";
         this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FormMain_HelpButtonClicked);
         ((System.ComponentModel.ISupportInitialize)(this.pbxCap)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pbxCap;
      private System.Windows.Forms.TextBox tbxSpy;
   }
}

