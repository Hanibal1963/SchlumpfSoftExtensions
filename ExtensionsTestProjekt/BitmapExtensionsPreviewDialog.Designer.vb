<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BitmapExtensionsPreviewDialog
	Inherits System.Windows.Forms.Form

	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer

	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.PictureBox3 = New System.Windows.Forms.PictureBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'PictureBox1
		'
		Me.PictureBox1.Location = New System.Drawing.Point(24, 150)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(90, 90)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'PictureBox2
		'
		Me.PictureBox2.Location = New System.Drawing.Point(195, 150)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(90, 90)
		Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.PictureBox2.TabIndex = 1
		Me.PictureBox2.TabStop = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(21, 18)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(124, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Dateierweiterungssymbol"
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(168, 15)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(117, 20)
		Me.TextBox1.TabIndex = 3
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(21, 51)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(71, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Ordnersymbol"
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(168, 45)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(117, 25)
		Me.Button1.TabIndex = 5
		Me.Button1.Text = "Ordner auswählen"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(21, 84)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(70, 13)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "Dateisymbole"
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(168, 79)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(117, 22)
		Me.Button2.TabIndex = 7
		Me.Button2.Text = "Datei öffenen"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'NumericUpDown1
		'
		Me.NumericUpDown1.Location = New System.Drawing.Point(168, 115)
		Me.NumericUpDown1.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
		Me.NumericUpDown1.Name = "NumericUpDown1"
		Me.NumericUpDown1.Size = New System.Drawing.Size(117, 20)
		Me.NumericUpDown1.TabIndex = 8
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(21, 117)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(78, 13)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "Symbolnummer"
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(301, 45)
		Me.TextBox2.Multiline = True
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.TextBox2.Size = New System.Drawing.Size(290, 195)
		Me.TextBox2.TabIndex = 10
		Me.TextBox2.WordWrap = False
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(298, 18)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(74, 13)
		Me.Label5.TabIndex = 11
		Me.Label5.Text = "Base64 Code:"
		'
		'PictureBox3
		'
		Me.PictureBox3.BackColor = System.Drawing.SystemColors.ActiveBorder
		Me.PictureBox3.Location = New System.Drawing.Point(610, 47)
		Me.PictureBox3.Name = "PictureBox3"
		Me.PictureBox3.Size = New System.Drawing.Size(192, 192)
		Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox3.TabIndex = 12
		Me.PictureBox3.TabStop = False
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(607, 18)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(75, 13)
		Me.Label6.TabIndex = 13
		Me.Label6.Text = "Bild aus Code:"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(21, 252)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(80, 13)
		Me.Label7.TabIndex = 15
		Me.Label7.Text = "Bild in Website:"
		'
		'WebBrowser1
		'
		Me.WebBrowser1.Location = New System.Drawing.Point(24, 277)
		Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WebBrowser1.Name = "WebBrowser1"
		Me.WebBrowser1.Size = New System.Drawing.Size(261, 210)
		Me.WebBrowser1.TabIndex = 16
		'
		'BitmapExtensionsPreviewDialog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(821, 499)
		Me.Controls.Add(Me.WebBrowser1)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.PictureBox3)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.TextBox2)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.NumericUpDown1)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.PictureBox2)
		Me.Controls.Add(Me.PictureBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "BitmapExtensionsPreviewDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ImageExtensionsPreviewDialog"
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
	Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
	Friend WithEvents Label1 As Windows.Forms.Label
	Friend WithEvents TextBox1 As Windows.Forms.TextBox
	Friend WithEvents Label2 As Windows.Forms.Label
	Friend WithEvents Button1 As Windows.Forms.Button
	Friend WithEvents Label3 As Windows.Forms.Label
	Friend WithEvents Button2 As Windows.Forms.Button
	Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
	Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
	Friend WithEvents NumericUpDown1 As Windows.Forms.NumericUpDown
	Friend WithEvents Label4 As Windows.Forms.Label
	Friend WithEvents TextBox2 As Windows.Forms.TextBox
	Friend WithEvents Label5 As Windows.Forms.Label
	Friend WithEvents PictureBox3 As Windows.Forms.PictureBox
	Friend WithEvents Label6 As Windows.Forms.Label
	Friend WithEvents Label7 As Windows.Forms.Label
	Friend WithEvents WebBrowser1 As Windows.Forms.WebBrowser
End Class
