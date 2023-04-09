Imports System.Drawing
Imports System.Windows.Forms
Imports ExtensionsTestProjekt.Extensions

Public Class BitmapExtensionsPreviewDialog

	Private file As String
	Private Const HTMLCODE = "<html lang='de' xmlns='http://www.w3.org/1999/xhtml'><head><meta charset='utf-8' /><title>Testseite</title></head><body style='background-color:dimgray'><h1>Testseite</h1><p><!--BITMAP--></p></body></html>"

	Public Sub New()
		' Dieser Aufruf ist für den Designer erforderlich.
		InitializeComponent()
		' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
		WebBrowser1.DocumentText = HTMLCODE
	End Sub

	Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
		Dim ext As String = CType(sender, TextBox).Text
		Dim bm As Bitmap = Nothing
		NumericUpDown1.Maximum = 0
		bm = bm.FromFilePathOrExt(ext)
		PictureBox1.Image = bm
		bm = bm.FromFilePathOrExt(ext, IconSizes.x32)
		PictureBox2.Image = bm
		TextBox2.Text = bm.ToBase64
		PictureBox3.Image = bm.FromBase64(TextBox2.Text)
		WebBrowser1.DocumentText = HTMLCODE.Replace("<!--BITMAP-->", bm.ToHtml())
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim bm As Bitmap = Nothing
		NumericUpDown1.Maximum = 0
		Dim result As DialogResult = FolderBrowserDialog1.ShowDialog
		If Not result = DialogResult.OK Then
			Exit Sub
		End If
		bm = bm.FromFilePathOrExt(FolderBrowserDialog1.SelectedPath)
		PictureBox1.Image = bm
		bm = bm.FromFilePathOrExt(FolderBrowserDialog1.SelectedPath, IconSizes.x32)
		PictureBox2.Image = bm
		TextBox2.Text = bm.ToBase64
		PictureBox3.Image = bm.FromBase64(TextBox2.Text)
		WebBrowser1.DocumentText = HTMLCODE.Replace("<!--BITMAP-->", bm.ToHtml())
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim bm As Bitmap = Nothing
		NumericUpDown1.Maximum = 0
		Dim result As DialogResult = OpenFileDialog1.ShowDialog
		If result = DialogResult.OK Then
			file = OpenFileDialog1.FileName
		Else
			Exit Sub
		End If
		NumericUpDown1.Maximum = bm.GetFileIcons(file)
		bm = bm.ExtractIcon(file, 0)
		PictureBox1.Image = bm
		bm = bm.ExtractIcon(file, 0, IconSizes.x32)
		PictureBox2.Image = bm
		TextBox2.Text = bm.ToBase64
		PictureBox3.Image = bm.FromBase64(TextBox2.Text)
		WebBrowser1.DocumentText = HTMLCODE.Replace("<!--BITMAP-->", bm.ToHtml())
	End Sub

	Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
		Dim bm As Bitmap = Nothing
		bm = bm.ExtractIcon(file, CInt(NumericUpDown1.Value))
		PictureBox1.Image = bm
		bm = bm.ExtractIcon(file, CInt(NumericUpDown1.Value), IconSizes.x32)
		PictureBox2.Image = bm
		TextBox2.Text = bm.ToBase64
		PictureBox3.Image = bm.FromBase64(TextBox2.Text)
		WebBrowser1.DocumentText = HTMLCODE.Replace("<!--BITMAP-->", bm.ToHtml())
	End Sub


End Class
