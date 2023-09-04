'
'****************************************************************************************************************
'NumericExtensions.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'

Namespace Extensions

	''' <summary>
	''' Enthält benutzerdefinierte Erweiterungsmethoden zur Verwendung mit den Datentypen
	''' <see cref="Short"/>, <see cref="UShort"/>, <see cref="Integer"/>, <see cref="UInteger"/>, 
	''' <see cref="Long"/>, <see cref="ULong"/>, <see cref="Decimal"/>, <see cref="Single"/> und <see cref="Double"/>.
	''' </summary>
	Public Module NumericExtensions

#Region "interne Funktionen"

		''' <summary>
		''' Formatiert einen Wert durch Platzieren von Punkten oder Kommas an den entsprechenden Positionen, 
		''' abhängig von der angegebenen Kultur.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalFormatted(sender As Double, precision As Integer, culture As System.Globalization.CultureInfo) As String

			If culture Is Nothing Then culture = System.Globalization.CultureInfo.CurrentUICulture
			Return sender.ToString("X" & precision, culture)

		End Function

		''' <summary>
		''' Berechnet den Prozentsatz eines Wertes von <paramref name="value"/>.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalGetPercentageOf(value As Double, total As Double) As Double

			Return value / total * 100

		End Function

		''' <summary>
		''' Berechnet den Bruchteil eines Wertes.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalFractionBy(value As Double, percent As Double) As Double

			Return value / 100 * percent

		End Function

		''' <summary>
		''' Bestimmt, ob ein Wert positiv ist.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalIsPositive(value As Double) As Boolean

			Dim result As Boolean = False
			If value > 0 Then result = True
			Return result

		End Function

		''' <summary>
		''' Bestimmt, ob der Wert negativ ist.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalIsNegative(value As Double) As Boolean

			Dim result As Boolean = False
			If value < 0 Then result = True
			Return result

		End Function

		''' <summary>
		''' Bestimmt, ob der Wert eine Primzahl ist.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalIsPrime(value As Long) As Boolean

			If (value And 1L) = 0L Then

				Return value = 2L

			Else

				Dim i As Long = 3L
				While (i * i) <= value
					If (value Mod i) = 0L Then
						Return False
					End If
					i += 2L
				End While
				Return value <> 1L

			End If

		End Function

		''' <summary>
		''' Bestimmt, Wert durch <paramref name="value"/> teilbar ist.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalIsDivisibleBy(source As Double, value As Double) As Boolean

			Return source Mod value = 0

		End Function

		''' <summary>
		''' Bestimmt, ob der Wert ein vielfaches von <paramref name="value"/> ist.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalIsMultipleOf(source As Double, value As Double) As Boolean

			Return source Mod value = 0

		End Function

		''' <summary>
		''' Bestimmt, ob der Quellwert im Bereich der angegebenen 
		''' <paramref name="minimum"/>- und <paramref name="maximum"/>-Werte liegt.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalIsInRangeOf(source As Double, minimum As Double, maximum As Double) As Boolean

			Return (source >= minimum) AndAlso (source <= maximum)

		End Function

		''' <summary>
		''' Gibt die Differenz zwischen dem Wert und <paramref name="value"/> zurück.
		''' </summary>
		<System.Diagnostics.DebuggerStepThrough>
		Private Function InternalDifferenceOf(source As Double, value As Double) As Double

			Select Case value

				Case Is > source
					Return +(value - source)

				Case Is < source
					Return -(source - value)

				Case Else
					Return 0.0R

			End Select

		End Function

#End Region

#Region "Prozentsatz eines Wertes von einem Gesamtwert berechnen"

		''' <summary>
		''' Berechnet den Prozentsatz eines Wertes von einem gegebenen Gesamtwert (<paramref name="total"/>).
		''' </summary>
		''' <param name="total">
		''' Der Gesamtwert.
		''' </param>
		''' <returns>
		''' Der Prozentsatz.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As Short, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As UShort, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As Integer, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As UInteger, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As Long, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As ULong, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As Decimal, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As Single, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

		''' <inheritdoc cref="PercentageOf(Short, Double)" />
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function PercentageOf(sender As Double, total As Double) As Double

			Return NumericExtensions.InternalGetPercentageOf(sender, total)

		End Function

#End Region

#Region "Den Bruchteil eines Wertes berechnen"

		''' <summary>
		''' Berechnet den Bruchteil eines Wertes in Prozent.
		''' </summary>
		''' <param name="Percentage">
		''' Der Anteil in Prozent (<paramref name="Percentage"/>) der berechnet werden soll.
		''' </param>
		''' <returns>
		''' Der Bruchteil der berchnet wurde.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As Short, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As UShort, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As Integer, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As UInteger, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As Long, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As ULong, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As Decimal, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As Single, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

		''' <inheritdoc cref="FractionBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FractionBy(sender As Double, Percentage As Double) As Double

			Return NumericExtensions.InternalFractionBy(Percentage, sender)

		End Function

#End Region

#Region "Bestimmen ob ein Wert positiv ist"

		''' <summary>
		''' Bestimmt, ob ein Wert positiv ist.
		''' </summary>
		''' <returns>
		''' <see langword="True"/> wenn der Wert eine positiv ist, andernfalls <see langword="False"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPositive(sender As Short) As Boolean

			Return NumericExtensions.InternalIsPositive(sender)

		End Function

		''' <inheritdoc cref="IsPositive(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPositive(sender As Integer) As Boolean

			Return NumericExtensions.InternalIsPositive(sender)

		End Function

		''' <inheritdoc cref="IsPositive(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPositive(sender As Long) As Boolean

			Return NumericExtensions.InternalIsPositive(sender)

		End Function

		''' <inheritdoc cref="IsPositive(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPositive(sender As Decimal) As Boolean

			Return NumericExtensions.InternalIsPositive(sender)

		End Function

		''' <inheritdoc cref="IsPositive(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPositive(sender As Single) As Boolean

			Return NumericExtensions.InternalIsPositive(sender)

		End Function

		''' <inheritdoc cref="IsPositive(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPositive(sender As Double) As Boolean

			Return NumericExtensions.InternalIsPositive(sender)

		End Function

#End Region

#Region "Bestimmen ob ein Wert negativ ist"

		''' <summary>
		''' Bestimmt, ob der Wert negativ ist.
		''' </summary>
		''' <returns>
		''' <see langword="True"/> wenn der Wert negative ist, andernfalls <see langword="False"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsNegative(sender As Short) As Boolean

			Return NumericExtensions.InternalIsNegative(sender)

		End Function

		''' <inheritdoc cref="IsNegative(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsNegative(sender As Integer) As Boolean

			Return NumericExtensions.InternalIsNegative(sender)

		End Function

		''' <inheritdoc cref="IsNegative(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsNegative(sender As Long) As Boolean

			Return NumericExtensions.InternalIsNegative(sender)

		End Function

		''' <inheritdoc cref="IsNegative(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsNegative(sender As Decimal) As Boolean

			Return NumericExtensions.InternalIsNegative(sender)

		End Function

		''' <inheritdoc cref="IsNegative(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsNegative(sender As Single) As Boolean

			Return NumericExtensions.InternalIsNegative(sender)

		End Function

		''' <inheritdoc cref="IsNegative(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsNegative(sender As Double) As Boolean

			Return NumericExtensions.InternalIsNegative(sender)

		End Function

#End Region

#Region "Bestimmen ob ein Wert eine Primzahl ist"

		''' <summary>
		''' Bestimmt, ob der Wert eine Primzahl ist.
		''' </summary>
		''' <returns>
		''' <see langword="True"/> wenn der Wert eine Primzahl ist, andernfalls <see langword="False"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPrime(sender As Short) As Boolean

			Return NumericExtensions.InternalIsPrime(sender)

		End Function

		''' <inheritdoc cref="IsPrime(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPrime(sender As UShort) As Boolean

			Return NumericExtensions.InternalIsPrime(sender)

		End Function

		''' <inheritdoc cref="IsPrime(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPrime(sender As Integer) As Boolean

			Return NumericExtensions.InternalIsPrime(sender)

		End Function

		''' <inheritdoc cref="IsPrime(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPrime(sender As UInteger) As Boolean

			Return NumericExtensions.InternalIsPrime(sender)

		End Function

		''' <inheritdoc cref="IsPrime(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsPrime(sender As Long) As Boolean

			Return NumericExtensions.InternalIsPrime(sender)

		End Function

#End Region

#Region "Bestimmen ob ein Wert durch einen angegebenen Wert teilbar ist"

		''' <summary>
		''' Bestimmt, Wert durch den angegebenen Wert teilbar ist (ohne Rest).
		''' </summary>
		''' <param name="Divisor">
		''' Der Wert, durch den dividiert werden soll.
		''' </param>
		''' <returns>
		''' <see langword="True"/> wenn der Wert teilbar ist, andernfalls <see langword="False"/> .
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As Short, Divisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Divisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As UShort, Devisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Devisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As Integer, Devisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Devisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As UInteger, Devisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Devisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As Long, Devisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Devisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As ULong, Devisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Devisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As Decimal, Dvisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Dvisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As Single, Devisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Devisor)

		End Function

		''' <inheritdoc cref="IsDivisibleBy(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsDivisibleBy(sender As Double, Devisor As Double) As Boolean

			Return NumericExtensions.InternalIsDivisibleBy(sender, Devisor)

		End Function

#End Region

#Region "Bestimmen ob ein Wert das vielfache von einem angegebenen Wert ist"

		''' <summary>
		''' Bestimmt, ob der Wert ein vielfaches von <paramref name="value"/> ist.
		''' </summary>
		''' <param name="value">
		''' Der Wert.
		''' </param>
		''' <returns>
		''' <see langword="True"/> wenn der Wert ein vielfaches ist, andernfalls <see langword="False"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As Short, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As UShort, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As Integer, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As UInteger, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As Long, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As ULong, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As Decimal, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As Single, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

		''' <inheritdoc cref="IsMultipleOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsMultipleOf(sender As Double, value As Double) As Boolean

			Return NumericExtensions.InternalIsMultipleOf(sender, value)

		End Function

#End Region

#Region "Bestimmen ob ein Wert im Bereich innerhalb von Minimum und Maximum liegt"

		''' <summary>
		''' Bestimmt, ob der Wert im Bereich der angegebenen 
		''' <paramref name="min"/>- und <paramref name="max"/>-Werte liegt.
		''' </summary>
		''' <param name="min">
		''' Der Mindestwert des Bereichs.
		''' </param>
		''' <param name="max">
		''' Der Maximalwert des Bereichs.
		''' </param>
		''' <returns>
		''' <see langword="True"/> wenn der Wert im Bereich liegt, andernfalls <see langword="False"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As Short, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As UShort, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As Integer, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As UInteger, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As Long, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As ULong, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As Decimal, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As Single, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

		''' <inheritdoc cref="IsInRangeOf(Short, Double, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function IsInRangeOf(sender As Double, min As Double, max As Double) As Boolean

			Return NumericExtensions.InternalIsInRangeOf(sender, min, max)

		End Function

#End Region

#Region "Die Differenz zwischen dem Wert und einem angegebenen Wert bestimmen"

		''' <summary>
		''' Gibt die Differenz zwischen dem Wert und <paramref name="value"/> zurück.
		''' </summary>
		''' <param name="value">
		''' Der Wert.
		''' </param>
		''' <returns>
		''' Die Differenz.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As Short, value As Double) As Double

			Return NumericExtensions.InternalDifferenceOf(sender, value)

		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As UShort, value As Double) As Double

			Return NumericExtensions.InternalDifferenceOf(sender, value)

		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As Integer, value As Double) As Double

			Return NumericExtensions.InternalDifferenceOf(sender, value)

		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As UInteger, value As Double) As Double

			Return NumericExtensions.InternalDifferenceOf(sender, value)

		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As Long, value As Double) As Double

			Return NumericExtensions.InternalDifferenceOf(sender, value)

		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As ULong, value As Double) As Double
			Return NumericExtensions.InternalDifferenceOf(sender, value)
		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As Decimal, value As Double) As Double
			Return NumericExtensions.InternalDifferenceOf(sender, value)
		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As Single, value As Double) As Double

			Return NumericExtensions.InternalDifferenceOf(sender, value)

		End Function

		''' <inheritdoc cref="DifferenceOf(Short, Double)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function DifferenceOf(sender As Double, value As Double) As Double

			Return NumericExtensions.InternalDifferenceOf(sender, value)

		End Function

#End Region

#Region "Einen Wert in seine literale hexadezimale Visual Basic-Darstellung konvertieren"

		''' <summary>
		''' Konvertiert einen Wert in seine literale hexadezimale Visual Basic-Darstellung.
		''' </summary>
		''' <returns>
		''' Der Hexadezimalwert.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToVBHex(sender As Short) As String

			Return String.Format("&H{0}S", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToVBHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToVBHex(sender As UShort) As String

			Return String.Format("&H{0}US", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToVBHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToVBHex(sender As Integer) As String

			Return String.Format("&H{0}I", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToVBHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToVBHex(sender As UInteger) As String

			Return String.Format("&H{0}UI", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToVBHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToVBHex(sender As Long) As String

			Return String.Format("&H{0}L", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

#End Region

#Region "Einen Wert in seine literale hexadezimale C#-Darstellung konvertieren"

		''' <summary>
		''' Konvertiert einen Wert in seine literale hexadezimale C#-Darstellung.
		''' </summary>
		''' <returns>
		''' Der Hexadezimalwert.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToCSharpHex(sender As Short) As String

			Return String.Format("0x{0}", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToCSharpHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToCSharpHex(sender As UShort) As String

			Return String.Format("0x{0}", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToCSharpHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToCSharpHex(sender As Integer) As String

			Return String.Format("0x{0}", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToCSharpHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToCSharpHex(sender As UInteger) As String

			Return String.Format("0x{0}U", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

		''' <inheritdoc cref="ToCSharpHex(Short)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToCSharpHex(sender As Long) As String

			Return String.Format("0x{0}L", Convert.ToString(sender, toBase:=16).ToUpper)

		End Function

#End Region

#Region "Einen Wert in Abhängigkeit von der Kultur formatieren"

		''' <summary>
		''' Formatiert einen Wert durch Platzieren von Punkten oder Kommas an den entsprechenden Positionen, 
		''' abhängig von der angegebenen Kultur.
		''' </summary>
		''' <param name="precision">
		''' Die Genauigkeit der Dezimalstellen.
		''' </param>
		''' <param name="culture">
		''' Das Kulturformat.
		''' </param>
		''' <returns>
		''' Der formatierte Wert.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As Short, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As UShort, Optional precision As Integer = 0,
							Optional culture As System.Globalization.CultureInfo = Nothing) As String
			Return NumericExtensions.InternalFormatted(sender, precision, culture)
		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As Integer, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As UInteger, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As Long, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As ULong, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As Decimal, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As Single, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

		''' <inheritdoc cref="Formatted(Short, Integer, Globalization.CultureInfo)"/>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function Formatted(sender As Double, Optional precision As Integer = 0, Optional culture As System.Globalization.CultureInfo = Nothing) As String

			Return NumericExtensions.InternalFormatted(sender, precision, culture)

		End Function

#End Region

	End Module

End Namespace
