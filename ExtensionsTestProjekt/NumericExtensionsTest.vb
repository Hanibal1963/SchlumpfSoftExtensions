'
'****************************************************************************************************************
'NumericExtensionsTest.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'


Imports ExtensionsTestProjekt.Extensions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class NumericExtensionsTest


	''' <summary>
	''' Testmethode für die Funktion "ToCSharpHex()"
	''' </summary>
	''' <remarks>
	''' Konvertiert einen Wert in seine literale hexadezimale C#-Darstellung.
	''' </remarks>
	<TestMethod> Public Sub ToCSharpHex_TestMethod()

		Dim var As Double = 100

		Debug.Print("*** ToCSharpHex Funktionstest ***" & vbCrLf)

		For i As Integer = 1 To 10

			Debug.Print("Der Wert " & var & " ergibt folgende Hex-Werte:")

			Debug.Print("Short - Datentyp -> HEX: " & CShort(var).ToCSharpHex)
			Debug.Print("UShort - Datentyp -> HEX: " & CUShort(var).ToCSharpHex)
			Debug.Print("Integer - Datentyp -> HEX: " & CInt(var).ToCSharpHex)
			Debug.Print("UInteger - Datentyp -> HEX: " & CUInt(var).ToCSharpHex)
			Debug.Print("Long - Datentyp -> HEX: " & CLng(var).ToCSharpHex)

			Debug.Print("--------------------------" & vbCrLf)

			var += 3

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "ToVBHex()"
	''' </summary>
	''' <remarks>
	''' Konvertiert einen Wert in seine literale hexadezimale Visual Basic-Darstellung.
	''' </remarks>
	<TestMethod> Public Sub ToVBHex_TestMethod()

		Dim var As Double = 100

		Debug.Print("*** ToVBHex Funktionstest ***" & vbCrLf)

		For i As Integer = 1 To 10

			Debug.Print("Der Wert " & var & " ergibt folgende Hex-Werte:")

			Debug.Print("Short - Datentyp -> HEX: " & CShort(var).ToVBHex)
			Debug.Print("UShort - Datentyp -> HEX: " & CUShort(var).ToVBHex)
			Debug.Print("Integer - Datentyp -> HEX: " & CInt(var).ToVBHex)
			Debug.Print("UInteger - Datentyp -> HEX: " & CUInt(var).ToVBHex)
			Debug.Print("Long - Datentyp -> HEX: " & CLng(var).ToVBHex)

			Debug.Print("--------------------------" & vbCrLf)

			var += 3

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "DifferenceOf(Value as <see cref="Double"/>)"
	''' </summary>
	''' <remarks>
	''' Die Differenz zwischen dem Wert und "Value" bestimmen.
	''' </remarks>
	<TestMethod> Public Sub DifferenceOf_TestMethod()

		Dim var() As Double = {5, 0}

		Debug.Print("*** DifferenceOf Funktionstest ***" & vbCrLf)

		For i As Integer = 1 To 10

			Debug.Print("Die Differenz zwischen " & var(0) & " und " & var(1) & " ermitteln ...")

			Debug.Print("Short - Datentyp: " & CShort(var(0)).DifferenceOf(var(1)))
			Debug.Print("UShort - Datentyp: " & CUShort(var(0)).DifferenceOf(var(1)))
			Debug.Print("Integer - Datentyp: " & CInt(var(0)).DifferenceOf(var(1)))
			Debug.Print("UInteger - Datentyp: " & CUInt(var(0)).DifferenceOf(var(1)))
			Debug.Print("Long - Datentyp: " & CLng(var(0)).DifferenceOf(var(1)))
			Debug.Print("ULong - Datentyp: " & CULng(var(0)).DifferenceOf(var(1)))
			Debug.Print("Decimal - Datentyp: " & CDec(var(0)).DifferenceOf(var(1)))
			Debug.Print("Single - Datentyp: " & CSng(var(0)).DifferenceOf(var(1)))
			Debug.Print("Double - Datentyp: " & var(0).DifferenceOf(var(1)))

			Debug.Print("--------------------------" & vbCrLf)

			var(1) += 1

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "IsInRangeOf(Value as <see cref="Double"/>)"
	''' </summary>
	''' <remarks>
	''' Bestimmt, ob der Wert im Bereich der angegebenen min- und max-Werte liegt.
	''' </remarks>
	<TestMethod> Public Sub IsInRangeOf_TestMethod()

		Dim var() As Double = {4, 7, 0}

		Debug.Print("*** IsInRangeOf Funktionstest ***" & vbCrLf)

		For i As Integer = 1 To 10

			Debug.Print("Feststellen ob der Wert von " & var(2) & " im Bereich von " & var(0) & " und " & var(1) & " liegt ...")

			Debug.Print("Short - Datentyp: " & CShort(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("UShort - Datentyp: " & CUShort(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("Integer - Datentyp: " & CInt(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("UInteger - Datentyp: " & CUInt(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("Long - Datentyp: " & CLng(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("ULong - Datentyp: " & CULng(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("Decimal - Datentyp: " & CDec(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("Single - Datentyp: " & CSng(var(2)).IsInRangeOf(var(0), var(1)))
			Debug.Print("Double - Datentyp: " & var(2).IsInRangeOf(var(0), var(1)))

			Debug.Print("--------------------------" & vbCrLf)

			var(2) += 1

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "IsMultipleOf(Value as <see cref="Double"/>)"
	''' </summary>
	''' <remarks>
	''' Bestimmt, ob der Wert ein vielfaches von value ist.
	''' </remarks>
	<TestMethod> Public Sub IsMultipleOf_TestMethod()

		Dim var() As Double = {3, 0}

		Debug.Print("*** IsMultipleOf Funktionstest ***" & vbCrLf)

		For i As Integer = 1 To 10

			Debug.Print("Feststellen ob der Wert von " & var(1) & " ein vielfaches von " & var(0) & " ist ...")

			Debug.Print("Short - Datentyp: " & CShort(var(1)).IsMultipleOf(var(0)))
			Debug.Print("UShort - Datentyp: " & CUShort(var(1)).IsMultipleOf(var(0)))
			Debug.Print("Integer - Datentyp: " & CInt(var(1)).IsMultipleOf(var(0)))
			Debug.Print("UInteger - Datentyp: " & CUInt(var(1)).IsMultipleOf(var(0)))
			Debug.Print("Long - Datentyp: " & CLng(var(1)).IsMultipleOf(var(0)))
			Debug.Print("ULong - Datentyp: " & CULng(var(1)).IsMultipleOf(var(0)))
			Debug.Print("Decimal - Datentyp: " & CDec(var(1)).IsMultipleOf(var(0)))
			Debug.Print("Single - Datentyp: " & CSng(var(1)).IsMultipleOf(var(0)))
			Debug.Print("Double - Datentyp: " & var(1).IsMultipleOf(var(0)))

			Debug.Print("--------------------------" & vbCrLf)


			var(1) += 5

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "IsDivisibleBy(Value as <see cref="Double"/>)"
	''' </summary>
	''' <remarks>
	''' Bestimmt, Wert durch den angegebenen Wert teilbar ist (ohne Rest).
	''' </remarks>
	<TestMethod> Public Sub IsDivisibleBy_TestMethod()

		Dim var() As Double = {10, 1}

		Debug.Print("*** IsDivisibleBy Funktionstest ***" & vbCrLf)

		For i As Integer = 1 To 10

			Debug.Print("Feststellen ob der Wert von " & var(0) & " durch " & var(1) & " teilbar ist ...")

			Debug.Print("Short - Datentyp: " & CShort(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("UShort - Datentyp: " & CUShort(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("Integer - Datentyp: " & CInt(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("UInteger - Datentyp: " & CUInt(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("Long - Datentyp: " & CLng(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("ULong - Datentyp: " & CULng(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("Decimal - Datentyp: " & CDec(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("Single - Datentyp: " & CSng(var(0)).IsDivisibleBy(var(1)))
			Debug.Print("Double - Datentyp: " & var(0).IsDivisibleBy(var(1)))

			Debug.Print("--------------------------" & vbCrLf)

			var(1) += 2

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "IsPrime()"
	''' </summary>
	''' <remarks>
	''' Bestimmt, ob der Wert eine Primzahl ist.
	''' </remarks>
	<TestMethod> Public Sub IsPrime_TestMethod()

		Dim var As Double = 1

		Debug.Print("*** IsPrime Funktionstest ***" & vbCrLf)

		For i As Integer = 1 To 11

			Debug.Print("Feststellen ob der Wert von " & var & " eine Primzahl ist ...")

			Debug.Print("Short - Datentyp: " & CShort(var).IsPrime.ToString)
			Debug.Print("UShort - Datentyp: " & CUShort(var).IsPrime.ToString)
			Debug.Print("Integer - Datentyp: " & CInt(var).IsPrime.ToString)
			Debug.Print("UInteger - Datentyp: " & CUInt(var).IsPrime.ToString)
			Debug.Print("Long - Datentyp: " & CLng(var).IsPrime.ToString)

			Debug.Print("--------------------------" & vbCrLf)

			var += 1

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "IsNegative()"
	''' </summary>
	''' <remarks>
	''' Bestimmt, ob der Wert negativ ist.
	''' </remarks>
	<TestMethod> Public Sub IsNegative_TestMethod()

		Dim var As Double = 3

		Debug.Print("*** IsNegative Funktionstest ***" & vbCrLf)

		For i As Integer = 0 To 5

			Debug.Print("Feststellen ob der Wert von " & var & " negativ ist ...")

			Debug.Print("Short - Datentyp: " & CShort(var).IsNegative.ToString)
			Debug.Print("Integer - Datentyp: " & CInt(var).IsNegative.ToString)
			Debug.Print("Long - Datentyp: " & CLng(var).IsNegative.ToString)
			Debug.Print("Decimal - Datentyp: " & CDec(var).IsNegative.ToString)
			Debug.Print("Single - Datentyp: " & CSng(var).IsNegative.ToString)
			Debug.Print("Double - Datentyp: " & var.IsNegative.ToString)

			Debug.Print("--------------------------" & vbCrLf)

			var -= 1

		Next i


	End Sub


	''' <summary>
	''' Testmethode für die Funktion "IsPositive()"
	''' </summary>
	''' <remarks>
	''' Bestimmt, ob ein Wert positiv ist.
	''' </remarks>
	<TestMethod> Public Sub IsPositive_TestMethod()

		Dim var As Double = 3

		Debug.Print("*** IsPositive Funktionstest ***" & vbCrLf)

		For i As Integer = 0 To 5

			Debug.Print("Feststellen ob der Wert von " & var & " positiv ist ...")

			Debug.Print("Short - Datentyp: " & CShort(var).IsPositive.ToString)
			Debug.Print("Integer - Datentyp: " & CInt(var).IsPositive.ToString)
			Debug.Print("Long - Datentyp: " & CLng(var).IsPositive.ToString)
			Debug.Print("Decimal - Datentyp: " & CDec(var).IsPositive.ToString)
			Debug.Print("Single - Datentyp: " & CSng(var).IsPositive.ToString)
			Debug.Print("Double - Datentyp: " & var.IsPositive.ToString)

			Debug.Print("--------------------------" & vbCrLf)

			var -= 1

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "FractionBy(Value as <see cref="Double"/>)"
	''' </summary>
	''' <remarks>
	''' Berechnet den Bruchteil eines Wertes in Prozent.
	''' </remarks>
	<TestMethod()> Public Sub FractionBy_TestMethod()

		Dim var() As Double = {150, 1}

		Debug.Print("*** FractionBy Funktionstest ***" & vbCrLf)

		For i As Integer = 0 To 5

			Debug.Print(var(1) & " Prozent von " & var(0) & " berechnen ..." & vbCrLf)

			Debug.Print("Short - Datentyp: " & var(1) & "% von " & var(0) & " sind " & CShort(var(0)).FractionBy(var(1)))
			Debug.Print("UShort - Datentyp: " & var(1) & "% von " & var(0) & " sind " & CUShort(var(0)).FractionBy(var(1)))
			Debug.Print("Integer - Datentyp: " & var(1) & "% von " & var(0) & " sind " & CInt(var(0)).FractionBy(var(1)))
			Debug.Print("UInterger - Datentyp: " & var(1) & "% von " & var(0) & " sind " & CUInt(var(0)).FractionBy(var(1)))
			Debug.Print("Long - Datentyp: " & var(1) & "% von " & var(0) & " sind " & CLng(var(0)).FractionBy(var(1)))
			Debug.Print("ULong - Datentyp: " & var(1) & "% von " & var(0) & " sind " & CULng(var(0)).FractionBy(var(1)))
			Debug.Print("Decimal - Datentyp: " & var(1) & "% von " & var(0) & " sind " & CDec(var(0)).FractionBy(var(1)))
			Debug.Print("Single - Datentyp: " & CSng(var(1)) & "% von " & var(0) & " sind " & CSng(var(0)).FractionBy(var(1)))
			Debug.Print("Double - Datentyp: " & var(1) & "% von " & var(0) & " sind " & var(0).FractionBy(var(1)))

			Debug.Print("--------------------------" & vbCrLf)

			var(1) += 5

		Next i

	End Sub


	''' <summary>
	''' Testmethode für die Funktion "PercentOf(Value as <see cref="Double"/>)"
	''' </summary>
	''' <remarks>
	''' Berechnet den Prozentsatz eines Wertes von einem gegebenen Gesamtwert.
	''' </remarks>
	<TestMethod()> Public Sub PercentOf_TestMethod()

		Dim var() As Double = {100, 50}

		Debug.Print("*** PercentOf Funktionstest ***" & vbCrLf)

		For i As Integer = 0 To 5

			Debug.Print("Wieviel Prozent sind " & var(0) & " von " & var(1) & "? ...")

			Debug.Print("Short - Datentyp: " & var(0) & " sind " & CShort(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("UShort - Datentyp: " & var(0) & " sind " & CUShort(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("Integer - Datentyp: " & var(0) & " sind " & CInt(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("UInteger - Datentyp: " & var(0) & " sind " & CUInt(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("Long - Datentyp: " & var(0) & " sind " & CLng(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("ULong - Datentyp: " & var(0) & " sind " & CULng(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("Decimal - Datentyp: " & var(0) & " sind " & CDec(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("Single - Datentyp: " & var(0) & " sind " & CSng(var(0)).PercentageOf(var(1)) & "% von " & var(1))
			Debug.Print("Short - Datentyp: " & var(0) & " sind " & var(0).PercentageOf(var(1)) & "% von " & var(1))

			Debug.Print("--------------------------" & vbCrLf)

			var(1) += 20

		Next i

	End Sub


End Class