'
'****************************************************************************************************************
'ImageExtensionsTest.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'


Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports ExtensionsTestProjekt.Extensions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class BitmapExtensionsTest

	<TestMethod()>
	Public Sub TestMethod()


		Dim pd As New BitmapExtensionsPreviewDialog
		pd.ShowDialog


	End Sub

End Class
