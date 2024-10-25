namespace SnakeGame
{
	partial class FormSnakeGame
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			grpbxScore = new GroupBox();
			label1 = new Label();
			lblHighestScore = new Label();
			lblCurrentScore = new Label();
			timerGameLoop = new System.Windows.Forms.Timer(components);
			grpbxGameGrid = new GroupBox();
			grpbxScore.SuspendLayout();
			SuspendLayout();
			// 
			// grpbxScore
			// 
			grpbxScore.Controls.Add(label1);
			grpbxScore.Controls.Add(lblHighestScore);
			grpbxScore.Controls.Add(lblCurrentScore);
			grpbxScore.Location = new Point(0, 3);
			grpbxScore.Name = "grpbxScore";
			grpbxScore.Size = new Size(784, 85);
			grpbxScore.TabIndex = 0;
			grpbxScore.TabStop = false;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(67, 31);
			label1.Name = "label1";
			label1.Size = new Size(0, 20);
			label1.TabIndex = 2;
			// 
			// lblHighestScore
			// 
			lblHighestScore.AutoSize = true;
			lblHighestScore.Location = new Point(623, 31);
			lblHighestScore.Name = "lblHighestScore";
			lblHighestScore.Size = new Size(63, 20);
			lblHighestScore.TabIndex = 1;
			lblHighestScore.Text = "Highest:";
			// 
			// lblCurrentScore
			// 
			lblCurrentScore.AutoSize = true;
			lblCurrentScore.Location = new Point(12, 31);
			lblCurrentScore.Name = "lblCurrentScore";
			lblCurrentScore.Size = new Size(49, 20);
			lblCurrentScore.TabIndex = 0;
			lblCurrentScore.Text = "Score:";
			// 
			// timerGameLoop
			// 
			timerGameLoop.Tick += timerGameLoop_Tick;
			// 
			// grpbxGameGrid
			// 
			grpbxGameGrid.Location = new Point(0, 88);
			grpbxGameGrid.Name = "grpbxGameGrid";
			grpbxGameGrid.Size = new Size(784, 439);
			grpbxGameGrid.TabIndex = 1;
			grpbxGameGrid.TabStop = false;
			// 
			// FormSnakeGame
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(782, 526);
			Controls.Add(grpbxGameGrid);
			Controls.Add(grpbxScore);
			Name = "FormSnakeGame";
			Text = "Snake Game";
			KeyDown += FormSnakeGame_KeyDown;
			grpbxScore.ResumeLayout(false);
			grpbxScore.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox grpbxScore;
		private Label lblCurrentScore;
		private Label lblHighestScore;
		private System.Windows.Forms.Timer timerGameLoop;
		private GroupBox grpbxGameGrid;
		private Label label1;
	}
}