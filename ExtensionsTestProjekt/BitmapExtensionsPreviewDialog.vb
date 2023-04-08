Imports System.Drawing
Imports System.Windows.Forms
Imports ExtensionsTestProjekt.Extensions

Public Class BitmapExtensionsPreviewDialog

	Private file As String

	Public Sub New()

		' Dieser Aufruf ist für den Designer erforderlich.
		InitializeComponent()

		' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

	End Sub

	Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
		Dim ext As String = CType(sender, TextBox).Text
		Dim bm As Bitmap = Nothing
		bm = bm.FromFilePathOrExt(ext)
		PictureBox1.Image = bm
		bm = bm.FromFilePathOrExt(ext, IconSizes.x32)
		PictureBox2.Image = bm
		NumericUpDown1.Maximum = 0
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim bm As Bitmap = Nothing
		Dim result As DialogResult = FolderBrowserDialog1.ShowDialog
		If result = DialogResult.OK Then
			bm = bm.FromFilePathOrExt(FolderBrowserDialog1.SelectedPath)
			PictureBox1.Image = bm
			bm = bm.FromFilePathOrExt(FolderBrowserDialog1.SelectedPath, IconSizes.x32)
			PictureBox2.Image = bm
		End If
		NumericUpDown1.Maximum = 0
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim bm As Bitmap = Nothing
		Dim result As DialogResult = OpenFileDialog1.ShowDialog
		If result = DialogResult.OK Then
			file = OpenFileDialog1.FileName
		Else
			NumericUpDown1.Maximum = 0
			Exit Sub
		End If
		PictureBox1.Image = bm.ExtractIcon(file, 0)
		PictureBox2.Image = bm.ExtractIcon(file, 0, IconSizes.x32)
		NumericUpDown1.Maximum = bm.GetFileIcons(file) - 1
	End Sub

	Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
		Dim bm As Bitmap = Nothing
		PictureBox1.Image = bm.ExtractIcon(file, CInt(NumericUpDown1.Value))
		PictureBox2.Image = bm.ExtractIcon(file, CInt(NumericUpDown1.Value), IconSizes.x32)
	End Sub


End Class
