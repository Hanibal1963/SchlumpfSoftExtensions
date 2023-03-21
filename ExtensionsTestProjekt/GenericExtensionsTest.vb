'
'****************************************************************************************************************
'GenericExtensionsTest.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'


Imports System.Text
Imports ExtensionsTestProjekt.Extensions


<TestClass()>
Public Class GenericExtensionsTest







	''' <summary>
	''' Testet die Funktion FindByContains für IEnumerable(Of String)
	''' </summary>
	<TestMethod> Public Sub IEnumerableFindByContains_TestMethod()

		Dim var As IEnumerable(Of String) = {"Hallo Welt !!", "a", "b", "c", "welt"}
		Dim result As String

		Debug.Print("Es wird in der Variablen " & var.ToString & " ( ) nach dem Begriff """ & var.Last & """ gesucht ..." & vbCrLf)

		Debug.Print("Groß und Kleinschreibung wird ignoriert:")
		result = String.Join(" ,", var.FindByContains(var.Last, True))
		Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)

		Debug.Print("Groß und Kleinschreibung wird eingehalten:")
		result = String.Join(" ,", var.FindByContains(var.Last, False))
		Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)

	End Sub


	''' <summary>
	''' Testet die Funktion FindExact für IEnumerable(Of String) 
	''' </summary>
	<TestMethod> Public Sub IEnumerableFindExact_TestMethod()

		Dim var As IEnumerable(Of String) = {"Hallo", "Welt", "!!", "a", "b", "c", "welt"}
		Dim result As String

		Debug.Print("Es wird in der Variablen " & var.ToString & " ( ) nach dem Begriff """ & var.Last & """ gesucht ..." & vbCrLf)

		Debug.Print("Groß und Kleinschreibung wird ignoriert:")
		result = String.Join(" ,", var.FindExact(var.Last, StringComparison.OrdinalIgnoreCase))
		Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)

		Debug.Print("Groß und Kleinschreibung wird eingehalten:")
		result = String.Join(" ,", var.FindExact(var.Last, StringComparison.Ordinal))
		Debug.Print("Es wurde ""{0}"" gefunden.", result)

	End Sub


	''' <summary>
	''' Testet die Funktion CountNonEmptyItems für IEnumerable(Of String)
	''' </summary>
	<TestMethod> Public Sub IEnumerableCountNonEmptyItems_TestMethod()

		Dim var As IEnumerable(Of String) = {"Hallo", "", " ", "Welt", "!"}

		Debug.Print("*** IEnumerable(Of String).CountNonEmptyItems Funktionstest ***" & vbCrLf)

		Debug.Print("Die Variable " & var.ToString & " enthält " & var.CountNonEmptyItems & " nicht leere Elemente.")

	End Sub


	''' <summary>
	''' Testet die Funktion CountEmptyItems für IEnumerable(Of String)
	''' </summary>
	<TestMethod> Public Sub IEnumerableCountEmptyItems_TestMethod()

		Dim var As IEnumerable(Of String) = {"Hallo", "", " ", "Welt", "!"}

		Debug.Print("*** IEnumerable(Of String).CountEmptyItems Funktionstest ***" & vbCrLf)

		Debug.Print("Die Variable " & var.ToString & " enthält " & var.CountEmptyItems & " leere Elemente.")

	End Sub


	''' <summary>
	''' Testet die Funktion ToString für IEnumerable(Of Byte)
	''' </summary>
	<TestMethod> Public Sub IEnumerableToString_TestMethod()

		Dim var As IEnumerable(Of Byte) = {84, 101, 115, 116}

		Debug.Print("*** IEnumerable.Tostring Funktionstestest ***" & vbCrLf)

		Debug.Print("Rückgabewerte der Variablen " & var.ToString & " :")
		Debug.Print("Rückgabe als Encoding.Default : " & var.ToString(Encoding.Default))
		Debug.Print("Rückgabe als Encoding.ASCII : " & var.ToString(Encoding.ASCII))
		Debug.Print("Rückgabe als Encoding.UTF7 : " & var.ToString(Encoding.UTF7))
		Debug.Print("Rückgabe als Encoding.UTF8 : " & var.ToString(Encoding.UTF8))
		Debug.Print("Rückgabe als Encoding.UTF32 : " & var.ToString(Encoding.UTF32))
		Debug.Print("Rückgabe als Encoding.Unicode : " & var.ToString(Encoding.Unicode))

	End Sub


	''' <summary>
	''' Testet die Funktion ToString für Byte()
	''' </summary>
	<TestMethod> Public Sub ByteToString_TestMethod()

		Dim var() As Byte = {84, 101, 115, 116}

		Debug.Print("*** Byte().ToString Funktionstest ***" & vbCrLf)

		Debug.Print("Rückgabewerte der Variablen " & var.ToString & " :")
		Debug.Print("Rückgabe als Encoding.Default : " & var.ToString(Encoding.Default))
		Debug.Print("Rückgabe als Encoding.ASCII : " & var.ToString(Encoding.ASCII))
		Debug.Print("Rückgabe als Encoding.UTF7 : " & var.ToString(Encoding.UTF7))
		Debug.Print("Rückgabe als Encoding.UTF8 : " & var.ToString(Encoding.UTF8))
		Debug.Print("Rückgabe als Encoding.UTF32 : " & var.ToString(Encoding.UTF32))
		Debug.Print("Rückgabe als Encoding.Unicode : " & var.ToString(Encoding.Unicode))

	End Sub


	''' <summary>
	''' Testet die Funktion Resize für Arrays
	''' </summary>
	<TestMethod()>
	Public Sub ArrayResize_TestMethod()

		Dim var As Integer = 10
		Dim arr(1) As Integer

		Debug.Print("*** ArrayResize Funktionstest ***" & vbCrLf)

		Debug.Print("anfängliche Größe -> " & arr.Length)

		For i As Integer = 1 To 5
			Debug.Write("neue Größe " & var & " -> ")
			arr = arr.Resize(var)
			Debug.Print("" & arr.Length)

			var += var * i

		Next i

	End Sub


End Class