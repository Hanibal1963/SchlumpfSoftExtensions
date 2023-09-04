'
'****************************************************************************************************************
'GenericExtensions.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'

Namespace Extensions

	''' <summary>
	''' Enthält verschiedene Erweiterungsmethoden für Arrays, Byte(), IEnumerable(Of Byte), 
	''' IEnumerable(Of String) und IEnumerable(Of T)
	''' </summary>
	Public Module GenericExtensions

#Region "Die Elementanzahl eines Arrays ändern"

		''' <summary>
		''' Ändert die Anzahl der Elemente eines <see cref="Array"/>.
		''' </summary>
		''' <param name="newSize">
		''' Die neue Größe des <see cref="Array"/>.
		''' </param>
		''' <returns>
		''' Das in der Größe geänderte <see cref="Array"/>.
		''' </returns>
		<Diagnostics.DebuggerStepThrough>
		<Runtime.CompilerServices.Extension>
		Public Function Resize(Of T)(sender As T(), newSize As Integer) As T()

			Dim preserveLength As Integer = Math.Min(sender.Length, newSize)

			If preserveLength > 0 Then

				Dim newArray As Array = Array.CreateInstance(sender.GetType.GetElementType, newSize)
				Array.Copy(sender, newArray, preserveLength)
				Return DirectCast(newArray, T())

			Else

				Return sender

			End If

		End Function

#End Region

#Region "Byte() oder IEnumerable(Of Byte) in String-Darstellung konvertieren"

		''' <summary>
		''' Konvertiert eine Byte-Folge (<see cref="Byte()"/>) in ihre String-Darstellung unter Verwendung 
		''' der angegebenen Zeichencodierung (<see cref="system.Text.Encoding"/>).
		''' </summary>
		''' <param name="encoding">
		''' Die Zeichencodierung <see cref="system.Text.Encoding"/> zum Decodieren der Bytes.
		''' </param>
		''' <returns>
		''' Die String-Darstellung.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToString(sender As Byte(), encoding As System.Text.Encoding) As String

			If encoding Is Nothing Then encoding = System.Text.Encoding.Default
			Return encoding.GetString(sender)

		End Function

		''' <summary>
		''' Konvertiert eine Byte-Folge (<see cref="IEnumerable(Of Byte)"/>) in ihre String-Darstellung unter Verwendung 
		''' der angegebenen Zeichencodierung (<see cref="system.Text.Encoding"/>).
		''' </summary>
		''' <param name="encoding">
		''' Die Zeichencodierung <see cref="system.Text.Encoding"/> zum Decodieren der Bytes.
		''' </param>
		''' <returns>
		''' Die String-Darstellung.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToString(sender As IEnumerable(Of Byte), encoding As System.Text.Encoding) As String

			Return ToString(sender.ToArray, encoding)

		End Function

#End Region

#Region "leere oder nicht leere Elemente suchen"

		''' <summary>
		''' Zählt die leeren Elemente eines <see cref="IEnumerable(Of String)"/>.
		''' </summary>
		''' <returns>
		''' Die Anzahl der leeren Elemente.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function CountEmptyItems(sender As IEnumerable(Of String)) As Integer

			Dim result As Integer = 0
			For Each str As String In sender

				If String.IsNullOrEmpty(str) OrElse String.IsNullOrWhiteSpace(str) Then result += 1

			Next
			Return result

		End Function

		''' <summary>
		''' Zählt die nicht leeren Elemente eines <see cref="IEnumerable(Of String)"/>.
		''' </summary>
		''' <returns>
		''' Die anzahl der nicht leeren Elemente.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function CountNonEmptyItems(sender As IEnumerable(Of String)) As Integer

			Dim result As Integer = 0
			For Each str As String In sender
				If Not String.IsNullOrEmpty(str) AndAlso Not String.IsNullOrWhiteSpace(str) Then result += 1
			Next
			Return result

		End Function

#End Region

#Region "Elemente nach Muster suchen"

		''' <summary>
		''' Findet die Elemente, die genau gleich der angegebenen Zeichenfolge in der Quelle sind <see cref="IEnumerable(Of String)"/>.
		''' </summary>
		''' <param name="searchString">
		''' Die Zeichenfolge, nach der gesucht werden soll.
		''' </param>
		''' <param name="stringComparison">
		''' Die Zeichenfolgenvergleichsregel.
		''' </param>
		''' <returns>
		''' Die gefundenen Elemente als <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FindExact(sender As IEnumerable(Of String), searchString As String, stringComparison As StringComparison) As IEnumerable(Of String)

			Dim result As IEnumerable(Of String)
			result = From str As String In sender Where str.Equals(searchString, stringComparison)
			Return result

		End Function

		''' <summary>
		''' Findet die Elemente, die die angegebene Zeichenfolge in der Quelle enthalten <see cref="IEnumerable(Of String)"/>.
		''' </summary>
		''' <param name="searchString">
		''' Die Zeichenfolge, nach der gesucht werden soll.
		''' </param>
		''' <param name="ignoreCase">
		''' Wenn auf True gesetzt, wird ein nicht sensibler String-Case-Vergleich durchgeführt.
		''' </param>
		''' <returns>
		''' Die gefundenen Elemente als <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FindByContains(sender As IEnumerable(Of String), searchString As String, Optional ignoreCase As Boolean = False) As IEnumerable(Of String)

			Dim result As IEnumerable(Of String)
			result = From str As String In sender Where If(ignoreCase, str.ToLower.Contains(searchString.ToLower), str.Contains(searchString))
			Return result

		End Function

		''' <summary>
		''' Führt eine Zeichenkettenähnliche Mustersuche in der Quelle <see cref="IEnumerable(Of String)"/> 
		''' durch und gibt alle Übereinstimmungen zurück.
		''' </summary>
		''' <param name="likePattern">
		''' Der mit dem <see langword="Like"/>-Operator zu verwendende Mustervergleich.
		''' </param>
		''' <param name="ignoreCase">
		''' Wenn auf True gesetzt, wird ein nicht sensibler String-Case-Vergleich durchgeführt.
		''' </param>
		''' <returns>
		''' Die gefundenen Elemente als <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function FindByLike(sender As IEnumerable(Of String), likePattern As String, Optional ignoreCase As Boolean = False) As IEnumerable(Of String)

			Dim result As IEnumerable(Of String)
			result = From str As String In sender Where If(ignoreCase, str.ToLower Like likePattern.ToLower, str Like likePattern)
			Return result

		End Function

#End Region

#Region "Element sortieren"

		''' <summary>
		''' Sortiert die Quelle <see cref="IEnumerable(Of String)"/> nach der Bubble-Sort-Methode.
		''' </summary>
		''' <returns>
		''' Die sortierten Elemente als <see cref="IEnumerable(Of T)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function BubbleSort(sender As IEnumerable(Of String)) As IEnumerable(Of String)

			Return sender.Select(
				Function(value As String)

					Return New With {
									 Key .OrgStr = value,
									 Key .SortStr =
									 System.Text.RegularExpressions.Regex.Replace(
									 value, "(\d+)|(\D+)",
									 Function(match As System.Text.RegularExpressions.Match)

										 Return match.Value.PadLeft(
										 sender.Select(
											Function(str As String)
												Return str.Length
											End Function
										).Max, If(Char.IsDigit(match.Value(0)), " "c, Char.MaxValue))
									 End Function)
					}

				End Function).OrderBy(Function(anon) anon.SortStr).Select(Function(anon) anon.OrgStr)

		End Function

#End Region

#Region "Elemente nach Muster entfernen"

		''' <summary>
		''' Entfernt die Elemente, die genau gleich der angegebenen Zeichenfolge in der Quelle sind <see cref="IEnumerable(Of String)"/>.
		''' </summary>
		''' <param name="searchString">
		''' Die Zeichenfolge, nach der gesucht werden soll.
		''' </param>
		''' <param name="stringComparison">
		''' Die Zeichenfolgenvergleichsregel.
		''' </param>
		''' <returns>
		''' Die übrigen Elemente in <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function RemoveExact(sender As IEnumerable(Of String), searchString As String, stringComparison As StringComparison) As IEnumerable(Of String)

			Return From value As String In sender Where Not value.Equals(searchString, stringComparison)

		End Function

		''' <summary>
		''' Entfernt die Elemente, die die angegebene Zeichenfolge in der Quelle enthalten <see cref="IEnumerable(Of String)"/>.
		''' </summary>
		''' <param name="searchString">
		''' Die Zeichenfolge, nach der gesucht werden soll.
		''' </param>
		''' <param name="ignoreCase">
		''' Standardmässig wird ein nicht sensibler String-Case-Vergleich durchgeführt.
		''' </param>
		''' <returns>
		''' Die übrigen Elemente in <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function RemoveByContains(sender As IEnumerable(Of String), searchString As String, Optional ignoreCase As Boolean = True) As IEnumerable(Of String)

			Dim result As IEnumerable(Of String)
			result = From str As String In sender Where If(ignoreCase, Not str.ToLower.Contains(searchString.ToLower), Not str.Contains(searchString))
			Return result

		End Function

		''' <summary>
		''' Führt eine Zeichenkettenähnliche Mustersuche in der Quelle <see cref="IEnumerable(Of String)"/> durch und entfernt alle Übereinstimmungen.
		''' </summary>
		''' <param name="likePattern">
		''' Der mit dem <see langword="Like"/>-Operator zu verwendende Mustervergleich.
		''' </param>
		''' <param name="ignoreCase">
		''' Standardmässig wird ein nicht sensibler String-Case-Vergleich durchgeführt.
		''' </param>
		''' <returns>
		''' Die übrigen Elemente in <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function RemoveByLike(sender As IEnumerable(Of String), likePattern As String, Optional ignoreCase As Boolean = True) As IEnumerable(Of String)

			Dim result As IEnumerable(Of String)
			result = From str As String In sender Where If(ignoreCase, Not str.ToLower Like likePattern.ToLower, Not str Like likePattern)
			Return result

		End Function

#End Region

	End Module

End Namespace
