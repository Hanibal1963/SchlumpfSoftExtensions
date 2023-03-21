'
'****************************************************************************************************************
'GenericExtensions.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'


Option Strict On
Option Explicit On
Option Infer Off


Namespace Extensions


	''' <summary>
	''' Enthält verschiedene Erweiterungsmethoden für Arrays, Byte(), IEnumerable(Of Byte), 
	''' IEnumerable(Of String) und IEnumerable(Of T)
	''' </summary>
	Public Module GenericExtensions


		Private Const ARGUMENT_OUT_OF_RANGE_EXCEPTION_MESSAGE As String =
			"Der Wert des Argumentes {0} liegt ausserhalb des gültigen Bereiches."


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
		''' <exception cref="ArgumentOutOfRangeException">
		''' Wird ausgelöst wenn der Wert kleiner oder gleich 0 ist.
		''' </exception>
		<Diagnostics.DebuggerStepThrough>
		<Runtime.CompilerServices.Extension>
		Public Function Resize(Of T)(sender As T(), newSize As Integer) As T()
			If newSize <= 0 Then
				Throw New ArgumentOutOfRangeException(String.Format(ARGUMENT_OUT_OF_RANGE_EXCEPTION_MESSAGE, NameOf(newSize)))
			End If
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
			If encoding Is Nothing Then
				encoding = System.Text.Encoding.Default
			End If
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


#Region "Erweiterungsmethoden für IEnumerable(Of String)"


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
				If String.IsNullOrEmpty(str) OrElse String.IsNullOrWhiteSpace(str) Then
					result += 1
				End If
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
			'Return (From str As String In sender Where Not String.IsNullOrEmpty(str) AndAlso Not String.IsNullOrWhiteSpace(str)).Count
			Dim result As Integer = 0
			For Each str As String In sender
				If Not String.IsNullOrEmpty(str) AndAlso Not String.IsNullOrWhiteSpace(str) Then
					result += 1
				End If
			Next
			Return result
		End Function


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
			result = From str As String In sender
					 Where str.Equals(searchString, stringComparison)
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
		Public Function FindByContains(sender As IEnumerable(Of String), searchString As String,
									   Optional ignoreCase As Boolean = False) As IEnumerable(Of String)
			Dim result As IEnumerable(Of String)
			result = From str As String In sender
					 Where If(ignoreCase, str.ToLower.Contains(searchString.ToLower), str.Contains(searchString))
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
		Public Function FindByLike(sender As IEnumerable(Of String), likePattern As String,
								   Optional ignoreCase As Boolean = False) As IEnumerable(Of String)
			Dim result As IEnumerable(Of String)
			result = From str As String In sender Where If(ignoreCase, str.ToLower Like likePattern.ToLower, str Like likePattern)
			Return result
		End Function





		''' <summary>
		''' Entfernt die Elemente, die exakt gleich der angegebenen Zeichenfolge 
		''' in der Quelle <see cref="IEnumerable(Of String)"/> sind .
		''' </summary>
		''' <example> This is a code example.
		''' <code>
		''' Dim col As IEnumerable(Of String) = {"Hello World !!", "a", "b", "c"}
		''' Debug.WriteLine(String.Join(", ", col.RemoveExact(searchString:="Hello", ignoreCase:=True)))
		''' </code>
		''' </example>
		''' <param name="sender">
		''' The source collections.
		''' </param>
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
		Public Function RemoveExact(sender As IEnumerable(Of String), searchString As String, stringComparison As StringComparison) As IEnumerable(Of String)
			Return From value As String In sender Where Not value.Equals(searchString, stringComparison)
		End Function





		''' <summary>
		''' Entfernt die Elemente, die die angegebene Zeichenfolge in der Quelle enthalten <see cref="IEnumerable(Of String)"/>.
		''' </summary>
		''' <example> This is a code example.
		''' <code>
		''' Dim col As IEnumerable(Of String) = {"Hello World !!", "a", "b", "c"}
		''' Debug.WriteLine(String.Join(", ", col.RemoveByContains(searchString:="Hello", ignoreCase:=True)))
		''' </code>
		''' </example>
		''' <param name="sender">
		''' The source collections.
		''' </param>
		''' <param name="searchString">
		''' The string to search for.
		''' </param>
		''' <param name="ignoreCase">
		''' If set to <c>true</c>, performs a non sensitive string-case comparison.
		''' </param>
		''' <returns>
		''' Die gefundenen Elemente als <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function RemoveByContains(sender As IEnumerable(Of String), searchString As String, ignoreCase As Boolean) As IEnumerable(Of String)
			Return From value As String In sender Where If(ignoreCase, Not value.ToLower.Contains(searchString.ToLower), Not value.Contains(searchString))
		End Function










		''' <summary>
		''' Führt eine zeichenkettenähnliche Mustersuche in der Quelle <see cref="IEnumerable(Of String)"/> durch und entfernt alle Übereinstimmungen.
		''' </summary>
		''' <example> This is a code example.
		''' <code>
		''' Dim col As IEnumerable(Of String) = {"Hello World", "a", "b", "c"}
		''' Debug.WriteLine(String.Join(", ", col.RemoveByLike(likePattern:="*hello*", ignoreCase:=True)))
		''' </code>
		''' </example>
		''' <param name="sender">
		''' The source collections.
		''' </param>
		''' <param name="likePattern">
		''' The pattern comparison to use with the <see langword="Like"/> operator.
		''' </param>
		''' <param name="ignoreCase">
		''' If set to <c>true</c>, performs a non sensitive string-case comparison.
		''' </param>
		''' <returns>
		''' Die gefundenen Elemente als <see cref="IEnumerable(Of String)"/>.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function RemoveByLike(sender As IEnumerable(Of String), likePattern As String, ignoreCase As Boolean) As IEnumerable(Of String)
			Return From value As String In sender Where If(ignoreCase, Not value.ToLower Like likePattern.ToLower, Not value Like likePattern)
		End Function






		''' ----------------------------------------------------------------------------------------------------
		''' <summary>
		''' Sorts the source <see cref="IEnumerable(Of String)"/> by BubbleSort method.
		''' </summary>
		''' ----------------------------------------------------------------------------------------------------
		''' <example> This is a code example.
		''' <code>
		''' Dim col As IEnumerable(Of String) = {"10", "333", "2", "45"}
		''' Debug.WriteLine(String.Join(", ", col.BubbleSort))
		''' </code>
		''' </example>
		''' ---------------------------------------------------------------------------------------------------- 
		''' <param name="sender">
		''' The source collection.
		''' </param>
		''' ----------------------------------------------------------------------------------------------------
		''' <returns>
		''' Die gefundenen Elemente als <see cref="IEnumerable(Of T)"/>.
		''' </returns>
		''' ----------------------------------------------------------------------------------------------------
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function BubbleSort(sender As IEnumerable(Of String)) As IEnumerable(Of String)
			Return sender.Select(Function(value As String)

									 Return New With
											{
											   Key .OrgStr = value,
											   Key .SortStr =
													System.Text.RegularExpressions.Regex.Replace(value, "(\d+)|(\D+)",
													 Function(match As System.Text.RegularExpressions.Match)
														 Return match.Value.PadLeft(sender.Select(Function(str As String)
																									  Return str.Length
																								  End Function).Max,
													 If(Char.IsDigit(match.Value(0)),
														" "c,
														Char.MaxValue))

													 End Function)
											}
								 End Function).
							 OrderBy(Function(anon) anon.SortStr).
							 Select(Function(anon) anon.OrgStr)
		End Function





#End Region


#Region ""


		'TODO: bearbeiten 3


		'### Erweiterungsmethoden für IEnumerable(Of T) Extensions
		'Contains Custom extension methods To use With an IEnumerable(Of T).

		'Public Members Summary

		' - Extension Functions
		'   - IEnumerable(Of T)().ConcatMultiple(IEnumerable(Of T)()) As IEnumerable(Of T)
		'   - IEnumerable(Of T)().StringJoin As IEnumerable(Of T)
		'   - IEnumerable(Of T).CountEmptyItems As Integer
		'   - IEnumerable(Of T).CountNonEmptyItems As Integer
		'   - IEnumerable(Of T).Duplicates As IEnumerable(Of T)
		'   - IEnumerable(Of T).Randomize As IEnumerable(Of T)
		'   - IEnumerable(Of T).RemoveDuplicates As IEnumerable(Of T)
		'   - IEnumerable(Of T).SplitIntoNumberOfElements(Integer) As IEnumerable(Of T)
		'   - IEnumerable(Of T).SplitIntoNumberOfElements(Integer, Boolean, T) As IEnumerable(Of T)
		'   - IEnumerable(Of T).SplitIntoParts(Integer) As IEnumerable(Of T)
		'   - IEnumerable(Of T).UniqueDuplicates As IEnumerable(Of T)
		'   - IEnumerable(Of T).Uniques As IEnumerable(Of T)




		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Gets all the duplicated values of the source <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim col As IEnumerable(Of Integer) = {1, 1, 2, 2, 3, 3, 0}
		'		''' Debug.WriteLine(String.Join(", ", col.Duplicates))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of T)"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function Duplicates(Of T)(sender As IEnumerable(Of T)) As IEnumerable(Of T)

		'			Return sender.GroupBy(Function(value As T) value).
		'						  Where(Function(group As IGrouping(Of T, T)) group.Count > 1).
		'						  SelectMany(Function(group As IGrouping(Of T, T)) group)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Gets the unique duplicated values of the source <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim col As IEnumerable(Of Integer) = {1, 1, 2, 2, 3, 3, 0}
		'		''' Debug.WriteLine(String.Join(", ", col.UniqueDuplicates))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of T)"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function UniqueDuplicates(Of T)(sender As IEnumerable(Of T)) As IEnumerable(Of T)

		'			Return sender.GroupBy(Function(value As T) value).
		'						  Where(Function(group As IGrouping(Of T, T)) group.Count > 1).
		'						  Select(Function(group As IGrouping(Of T, T)) group.Key)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Gets the unique values of the source <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim col As IEnumerable(Of Integer) = {1, 1, 2, 2, 3, 3, 0}
		'		''' Debug.WriteLine(String.Join(", ", col.Uniques))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of T)"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function Uniques(Of T)(sender As IEnumerable(Of T)) As IEnumerable(Of T)

		'			Return sender.Except(UniqueDuplicates(sender))

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Removes duplicated values in the source <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>   
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim col As IEnumerable(Of Integer) = {1, 1, 2, 2, 3, 3, 0}
		'		''' Debug.WriteLine(String.Join(", ", col.RemoveDuplicates))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of T)"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function RemoveDuplicates(Of T)(sender As IEnumerable(Of T)) As IEnumerable(Of T)

		'			Return sender.Distinct

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Splits the source <see cref="IEnumerable(Of T)"/> into the specified amount of secuences.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		'''  Dim mainCol As IEnumerable(Of Integer) = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}
		'		'''  Dim splittedCols As IEnumerable(Of IEnumerable(Of Integer)) = mainCol.SplitIntoParts(amount:=2)
		'		'''  splittedCols.ToList.ForEach(Sub(col As IEnumerable(Of Integer))
		'		'''                                  Debug.WriteLine(String.Join(", ", col))
		'		'''                              End Sub)
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' 
		'		''' <param name="amount">
		'		''' The target amount of secuences.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of IEnumerable(Of T))"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function SplitIntoParts(Of T)(sender As IEnumerable(Of T),
		'amount As Integer) As IEnumerable(Of IEnumerable(Of T))

		'			If (amount = 0) OrElse (amount > sender.Count) OrElse (sender.Count Mod amount <> 0) Then
		'				Throw New ArgumentOutOfRangeException(paramName:=NameOf(amount),
		'													  message:="value should be greater than '0', smallest than 'col.Count', and multiplier of 'col.Count'.")
		'			End If

		'			Dim chunkSize As Integer = CInt(Math.Ceiling(sender.Count() / amount))

		'			Return From index As Integer In Enumerable.Range(0, amount)
		'				   Select sender.Skip(chunkSize * index).Take(chunkSize)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Splits the source <see cref="IEnumerable(Of T)"/> into secuences with the specified amount of elements.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		'''  Dim mainCol As IEnumerable(Of Integer) = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		'		'''  Dim splittedCols As IEnumerable(Of IEnumerable(Of Integer)) = mainCol.SplitIntoNumberOfElements(amount:=4)
		'		'''  splittedCols.ToList.ForEach(Sub(col As IEnumerable(Of Integer))
		'		'''                                  Debug.WriteLine(String.Join(", ", col))
		'		'''                              End Sub)
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' 
		'		''' <param name="amount">
		'		''' The target amount of elements.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of IEnumerable(Of T))"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function SplitIntoNumberOfElements(Of T)(sender As IEnumerable(Of T),
		'amount As Integer) As IEnumerable(Of IEnumerable(Of T))

		'			Return From index As Integer In Enumerable.Range(0, CInt(Math.Ceiling(sender.Count() / amount)))
		'				   Select sender.Skip(index * amount).Take(amount)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Splits the source <see cref="IEnumerable(Of T)"/> into secuences with the specified amount of elements.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		'''  Dim mainCol As IEnumerable(Of Integer) = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		'		'''  Dim splittedCols As IEnumerable(Of IEnumerable(Of Integer)) = mainCol.SplitIntoNumberOfElements(amount:=4, fillEmpty:=True, valueToFill:=0)
		'		'''  splittedCols.ToList.ForEach(Sub(col As IEnumerable(Of Integer))
		'		'''                                  Debug.WriteLine(String.Join(", ", col))
		'		'''                              End Sub)
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' 
		'		''' <param name="amount">
		'		''' The target amount of elements.
		'		''' </param>
		'		''' 
		'		''' <param name="fillEmpty">
		'		''' If set to <c>true</c>, generates empty elements to fill the last secuence's part amount.
		'		''' </param>
		'		''' 
		'		''' <param name="valueToFill">
		'		''' An optional value used to fill the last secuence's part amount.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of IEnumerable(Of T))"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function SplitIntoNumberOfElements(Of T)(sender As IEnumerable(Of T),
		'amount As Integer,
		'fillEmpty As Boolean,
		'														Optional valueToFill As T = Nothing) As IEnumerable(Of IEnumerable(Of T))

		'			Return (From count As Integer In Enumerable.Range(0, CInt(Math.Ceiling(sender.Count() / amount)))).
		'					Select(Function(count)

		'							   Select Case fillEmpty

		'								   Case True

		'									   Return If((sender.Count - (count * amount)) >= amount,
		'										   sender.Skip(count * amount).Take(amount),
		'										   sender.Skip(count * amount).Take(amount).
		'													  Concat(Enumerable.Repeat(Of T)(
		'															 valueToFill,
		'															 amount - (sender.Count() - (count * amount)))))

		'								   Case Else
		'									   Return sender.Skip(count * amount).Take(amount)

		'							   End Select

		'						   End Function)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Randomizes the elements of the source <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim col As IEnumerable(Of Integer) = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		'		''' Debug.WriteLine(String.Join(", ", col.Randomize))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collection.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of T)"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function Randomize(Of T)(sender As IEnumerable(Of T)) As IEnumerable(Of T)

		'			Dim rand As New Random

		'			Return From item As T In sender
		'				   Order By rand.Next

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Concatenates multiple <see cref="IEnumerable(Of T)"/> at once into a single <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim col1 As IEnumerable(Of Integer) = {1, 2, 3}
		'		''' Dim col2 As IEnumerable(Of Integer) = {4, 5, 6}
		'		''' Dim col3 As IEnumerable(Of Integer) = {7, 8, 9}
		'		''' Debug.WriteLine(String.Join(", ", {col1, col2, col3}.ConcatMultiple))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collections.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="IEnumerable(Of T)"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function ConcatMultiple(Of T)(sender As IEnumerable(Of T)()) As IEnumerable(Of T)

		'			Return sender.SelectMany(Function(col As IEnumerable(Of T)) col)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Joins multiple <see cref="IEnumerable(Of T)"/> at once into a single string.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim col1 As IEnumerable(Of Integer) = {1, 2, 3}
		'		''' Dim col2 As IEnumerable(Of Integer) = {4, 5, 6}
		'		''' Dim col3 As IEnumerable(Of Integer) = {7, 8, 9}
		'		''' Debug.WriteLine({col1, col2, col3}.StringJoin(", ")))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <typeparam name="T">
		'		''' </typeparam>
		'		'''     
		'		''' <param name="separator">
		'		''' The string to use as a separator.
		'		''' </param>
		'		''' 
		'		''' <param name="sender">
		'		''' The source collections.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' <see cref="String"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function StringJoin(Of T)(sender As IEnumerable(Of T)(), separator As String) As String
		'			Dim sb As New System.Text.StringBuilder
		'			For Each col As IEnumerable(Of T) In sender
		'				sb.Append(String.Join(separator, col) & separator)
		'			Next col
		'			Return sb.Remove(sb.Length - separator.Length, separator.Length).ToString
		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim emptyItemCount As Integer = {"Hello", "   ", "World!"}.CountEmptyItems
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Counts the empty items of the source <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The total amount of empty items.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function CountEmptyItems(Of T)(sender As IEnumerable(Of T)) As Integer

		'			Return (From item As T In sender
		'					Where item.Equals(Nothing)).Count

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Counts the non-empty items of the source <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' Dim nonEmptyItemCount As Integer = {"Hello", "   ", "World!"}.CountNonEmptyItems
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The total amount of non-empty items.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function CountNonEmptyItems(Of T)(sender As IEnumerable(Of T)) As Integer

		'			Return sender.Count - CountEmptyItems(sender)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object and returns the zero-based index of the first occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' MsgBox({1, 2, 3, 4, 5, 6, 7, 8, 9}.IndexOf(value:=1))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="value">
		'		''' The object to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of the first occurrence of object within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, –1.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOf(Of T)(sender As IEnumerable(Of T),
		'value As T) As Integer

		'			Return IndexOf(sender, {value}, 0, sender.Count)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object and returns the zero-based index of the first occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' MsgBox({1, 2, 3, 4, 5, 6, 7, 8, 9}.IndexOf(value:=1))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="value">
		'		''' The object to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of the first occurrence of object within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, –1.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOf(Of T)(sender As IEnumerable(Of T),
		'value As T,
		'index As Integer) As Integer

		'			Return IndexOf(sender, {value}, index, sender.Count - index)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object and returns the zero-based index of the first occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' MsgBox({1, 2, 3, 4, 5, 6, 7, 8, 9}.IndexOf(value:=1))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="value">
		'		''' The object to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' 
		'		''' <param name="count">
		'		''' The number of elements in the <see cref="IEnumerable(Of T)"/> to search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of the first occurrence of object within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, –1.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOf(Of T)(sender As IEnumerable(Of T),
		'value As T,
		'index As Integer,
		'count As Integer) As Integer

		'			Return IndexOf(sender, {value}, index, count)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object pattern and returns the zero-based index of the first occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' MsgBox({0, 1, 2, 3, 4, 5, 6, 7, 8, 9}.IndexOf(pattern:={5, 6, 7}))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="pattern">
		'		''' The object pattern to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of the first occurrence of object pattern within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, –1.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOf(Of T)(sender As IEnumerable(Of T),
		'pattern As IEnumerable(Of T)) As Integer

		'			Return IndexOf(sender, pattern, 0, sender.Count)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object pattern and returns the zero-based index of the first occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' MsgBox({0, 1, 2, 3, 4, 5, 6, 7, 8, 9}.IndexOf(pattern:={5, 6, 7}, index:=5))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="pattern">
		'		''' The object pattern to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of the first occurrence of object pattern within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, –1.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOf(Of T)(sender As IEnumerable(Of T),
		'pattern As IEnumerable(Of T),
		'index As Integer) As Integer

		'			Return IndexOf(sender, pattern, index, sender.Count - index)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object pattern and returns the zero-based index of the first occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' MsgBox({0, 1, 2, 3, 4, 5, 6, 7, 8, 9}.IndexOf(pattern:={5, 6, 7}, index:=5, count:=3))
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="pattern">
		'		''' The object pattern to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' 
		'		''' <param name="count">
		'		''' The number of elements in the <see cref="IEnumerable(Of T)"/> to search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of the first occurrence of object pattern within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, –1.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <exception cref="ArgumentOutOfRangeException">
		'		''' index;Value equals or bigger than 0 is required.
		'		''' or
		'		''' count;Value bigger than 0 is required.
		'		''' or
		'		''' count;Value equals or bigger than the pattern length is required.
		'		''' </exception>
		'		''' 
		'		''' <exception cref="IndexOutOfRangeException">
		'		''' </exception>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOf(Of T)(sender As IEnumerable(Of T),
		'pattern As IEnumerable(Of T),
		'index As Integer,
		'count As Integer) As Integer

		'			If (sender Is Nothing) OrElse Not sender.Any Then
		'				Return -1

		'			ElseIf (pattern Is Nothing) OrElse Not pattern.Any Then
		'				Return -1

		'			ElseIf index < 0 Then
		'				Throw New ArgumentOutOfRangeException(paramName:=NameOf(index), message:="Value equals or bigger than 0 is required.")

		'			ElseIf count <= 0 Then
		'				Throw New ArgumentOutOfRangeException(paramName:=NameOf(count), message:="Value bigger than 0 is required.")

		'			ElseIf count < pattern.Count Then
		'				Throw New ArgumentOutOfRangeException(paramName:=NameOf(count), message:="Value equals or bigger than the pattern length is required.")

		'			ElseIf (index >= sender.Count) OrElse ((index + count) > sender.Count) Then
		'				Throw New IndexOutOfRangeException()

		'			Else
		'				Dim result As Integer =
		'					Enumerable.Range(index, count).
		'							   Where(Function(i As Integer) pattern.Select(Function(b1, b2) New With {b2, b1}).
		'							   All(Function(p) sender(i + p.b2).Equals(p.b1))).FirstOrDefault

		'				' Fix default return value.
		'				If (result = 0) AndAlso (index <> 0) Then
		'					Return -1

		'				ElseIf (result = 0) AndAlso Not index <> 0 AndAlso (sender.Take(index + pattern.Count).Count > count) Then
		'					Return -1

		'				ElseIf (result = 0) AndAlso (index = 0) AndAlso Not sender.Take(pattern.Count).
		'																	 Select(Function(b1, b2) New With {b2, b1}).
		'																	 All(Function(p) pattern(p.b2).Equals(p.b1)) Then
		'					Return -1

		'				ElseIf (result <> 0) AndAlso (index <> 0) AndAlso ((result + pattern.Count) > (index + count)) Then
		'					Return -1

		'				Else
		'					Return result

		'				End If

		'			End If

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object and returns the zero-based indexes of all the occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' 
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="value">
		'		''' The object to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of all the occurrences of object within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, <see langword="Nothing"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <exception cref="ArgumentOutOfRangeException">
		'		''' index;Value equals or bigger than 0 is required.
		'		''' or
		'		''' count;Value bigger than 0 is required.
		'		''' or
		'		''' count;Value equals or bigger than the pattern length is required.
		'		''' </exception>
		'		''' 
		'		''' <exception cref="IndexOutOfRangeException">
		'		''' </exception>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOfAll(Of T)(sender As IEnumerable(Of T),
		'value As T) As IEnumerable(Of Integer)

		'			Return IndexOfAll(sender, {value}, 0, sender.Count)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object and returns the zero-based indexes of all the occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' 
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="value">
		'		''' The object to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of all the occurrences of object within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, <see langword="Nothing"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <exception cref="ArgumentOutOfRangeException">
		'		''' index;Value equals or bigger than 0 is required.
		'		''' or
		'		''' count;Value bigger than 0 is required.
		'		''' or
		'		''' count;Value equals or bigger than the pattern length is required.
		'		''' </exception>
		'		''' 
		'		''' <exception cref="IndexOutOfRangeException">
		'		''' </exception>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOfAll(Of T)(sender As IEnumerable(Of T),
		'value As T,
		'index As Integer) As IEnumerable(Of Integer)

		'			Return IndexOfAll(sender, {value}, index, sender.Count - index)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object and returns the zero-based indexes of all the occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' 
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="value">
		'		''' The object to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' 
		'		''' <param name="count">
		'		''' The number of elements in the <see cref="IEnumerable(Of T)"/> to search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of all the occurrences of object within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, <see langword="Nothing"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <exception cref="ArgumentOutOfRangeException">
		'		''' index;Value equals or bigger than 0 is required.
		'		''' or
		'		''' count;Value bigger than 0 is required.
		'		''' or
		'		''' count;Value equals or bigger than the pattern length is required.
		'		''' </exception>
		'		''' 
		'		''' <exception cref="IndexOutOfRangeException">
		'		''' </exception>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOfAll(Of T)(sender As IEnumerable(Of T),
		'value As T,
		'index As Integer,
		'count As Integer) As IEnumerable(Of Integer)

		'			Return IndexOfAll(sender, {value}, index, count)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object pattern and returns the zero-based indexes of all the occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' 
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="pattern">
		'		''' The object pattern to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of all the occurrences of object pattern within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, <see langword="Nothing"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <exception cref="ArgumentOutOfRangeException">
		'		''' index;Value equals or bigger than 0 is required.
		'		''' or
		'		''' count;Value bigger than 0 is required.
		'		''' or
		'		''' count;Value equals or bigger than the pattern length is required.
		'		''' </exception>
		'		''' 
		'		''' <exception cref="IndexOutOfRangeException">
		'		''' </exception>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOfAll(Of T)(sender As IEnumerable(Of T),
		'pattern As IEnumerable(Of T)) As IEnumerable(Of Integer)

		'			Return IndexOfAll(sender, pattern, 0, sender.Count)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object pattern and returns the zero-based indexes of all the occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' 
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="pattern">
		'		''' The object pattern to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of all the occurrences of object pattern within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, <see langword="Nothing"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <exception cref="ArgumentOutOfRangeException">
		'		''' index;Value equals or bigger than 0 is required.
		'		''' or
		'		''' count;Value bigger than 0 is required.
		'		''' or
		'		''' count;Value equals or bigger than the pattern length is required.
		'		''' </exception>
		'		''' 
		'		''' <exception cref="IndexOutOfRangeException">
		'		''' </exception>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOfAll(Of T)(sender As IEnumerable(Of T),
		'pattern As IEnumerable(Of T),
		'index As Integer) As IEnumerable(Of Integer)

		'			Return IndexOfAll(sender, pattern, index, sender.Count - index)

		'		End Function

		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <summary>
		'		''' Searches for the specified object pattern and returns the zero-based indexes of all the occurrence within the 
		'		''' entire <see cref="IEnumerable(Of T)"/>.
		'		''' </summary>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <example> This is a code example.
		'		''' <code>
		'		''' 
		'		''' </code>
		'		''' </example>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <param name="sender">
		'		''' The source <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="pattern">
		'		''' The object pattern to locate in the <see cref="IEnumerable(Of T)"/>.
		'		''' </param>
		'		''' 
		'		''' <param name="index">
		'		''' The zero-based starting index of the search.
		'		''' </param>
		'		''' 
		'		''' <param name="count">
		'		''' The number of elements in the <see cref="IEnumerable(Of T)"/> to search.
		'		''' </param>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <returns>
		'		''' The zero-based index of all the occurrences of object pattern within the entire <see cref="IEnumerable(Of T)"/>, 
		'		''' if found; otherwise, <see langword="Nothing"/>.
		'		''' </returns>
		'		''' ----------------------------------------------------------------------------------------------------
		'		''' <exception cref="ArgumentOutOfRangeException">
		'		''' index;Value equals or bigger than 0 is required.
		'		''' or
		'		''' count;Value bigger than 0 is required.
		'		''' or
		'		''' count;Value equals or bigger than the pattern length is required.
		'		''' </exception>
		'		''' 
		'		''' <exception cref="IndexOutOfRangeException">
		'		''' </exception>
		'		''' ----------------------------------------------------------------------------------------------------
		'		<DebuggerStepThrough>
		'		<System.Runtime.CompilerServices.Extension>
		'		Public Function IndexOfAll(Of T)(sender As IEnumerable(Of T),
		'pattern As IEnumerable(Of T),
		'index As Integer,
		'count As Integer) As IEnumerable(Of Integer)

		'			If (sender Is Nothing) OrElse Not sender.Any Then
		'				Return Nothing

		'			ElseIf (pattern Is Nothing) OrElse Not pattern.Any Then
		'				Return Nothing

		'			ElseIf index < 0 Then
		'				Throw New ArgumentOutOfRangeException(paramName:=NameOf(index), message:="Value equals or bigger than 0 is required.")

		'			ElseIf count <= 0 Then
		'				Throw New ArgumentOutOfRangeException(paramName:=NameOf(count), message:="Value bigger than 0 is required.")

		'			ElseIf count < pattern.Count Then
		'				Throw New ArgumentOutOfRangeException(paramName:=NameOf(count), message:="Value equals or bigger than the pattern length is required.")

		'			ElseIf (index >= sender.Count) OrElse ((index + count) > sender.Count) Then
		'				Throw New IndexOutOfRangeException()

		'			Else
		'				Dim result As IEnumerable(Of Integer) =
		'					Enumerable.Range(index, count).
		'							   Where(Function(i As Integer) pattern.Select(Function(b1, b2) New With {b2, b1}).
		'							   All(Function(p) sender(i + p.b2).Equals(p.b1)))

		'				' Fix default return value.
		'				If (result(0) = 0) AndAlso (index <> 0) Then
		'					Return Nothing

		'				ElseIf (result(0) = 0) AndAlso Not index <> 0 AndAlso (sender.Take(index + pattern.Count).Count > count) Then
		'					Return Nothing

		'				ElseIf (result(0) = 0) AndAlso (index = 0) AndAlso Not sender.Take(pattern.Count).
		'																		Select(Function(b1, b2) New With {b2, b1}).
		'																		All(Function(p) pattern(p.b2).Equals(p.b1)) Then
		'					Return Nothing

		'				ElseIf (result(0) <> 0) AndAlso (index <> 0) AndAlso ((result(0) + pattern.Count) > (index + count)) Then
		'					Return Nothing

		'				Else
		'					Return result

		'				End If

		'			End If

		'		End Function



#End Region


	End Module


End Namespace
