'
'****************************************************************************************************************
'BitmapExtensions.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'

Imports System.Drawing

Namespace Extensions

	''' <summary>
	''' Enthält Erweiterungsfunktionen für die Klasse <seealso cref="System.Drawing.Bitmap"/> 
	''' </summary>
	Public Module BitmapExtensions

#Region "Konstantendefinitionen"

		Private Const _sHGFI_ICON = &H100
		Private Const _sHGFI_USEFILEATTRIBUTES = &H10

		Public ReadOnly Property SHGFI_ICON As Integer
			Get
				Return _sHGFI_ICON
			End Get
		End Property

		Public ReadOnly Property SHGFI_USEFILEATTRIBUTES As Integer
			Get
				Return _sHGFI_USEFILEATTRIBUTES
			End Get
		End Property

#End Region

#Region "Aufzählungsdefinitionen"

		''' <summary>
		''' Aufzählung der möglichen Symbolgrößen
		''' </summary>
		<Flags>
		Public Enum IconSizes

			''' <summary>
			''' großes Symbol (32*32 Pixel)
			''' </summary>
			x32 = 0

			''' <summary>
			''' kleines Symbol (16*16 Pixel)
			''' </summary>
			x16 = 1

		End Enum

#End Region

#Region "Strukturdefinitionen"

		''' <summary>
		''' Enthält Informationen zu einem Dateiobjekt.
		''' </summary>
		''' <remarks>
		''' https://learn.microsoft.com/de-de/windows/win32/api/shellapi/ns-shellapi-shfileinfoa
		''' </remarks>
		<Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential, CharSet:=Runtime.InteropServices.CharSet.Unicode)>
		Private Structure SHFILEINFOW

			''' <summary>
			''' Ein Handle zum Symbol, das die Datei darstellt. 
			''' </summary>
			Public hIcon As IntPtr

			''' <summary>
			''' Der Index des Symbolbilds in der Systembildliste.
			''' </summary>
			Public iIcon As Integer

			''' <summary>
			''' Ein Array von Werten, das die Attribute des Dateiobjekts angibt.
			''' </summary>
			''' <remarks>
			''' https://learn.microsoft.com/de-de/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getattributesof
			''' </remarks>
			Public dwAttributes As Integer

			''' <summary>
			''' Eine Zeichenfolge, die den Namen der Datei enthält, wie sie in der Windows-Shell angezeigt wird, 
			''' oder den Pfad und Dateinamen der Datei, die das Symbol enthält, das die Datei darstellt.
			''' </summary>
			<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=260)>
			Public szDisplayName As String

			''' <summary>
			''' Eine Zeichenfolge, die den Dateityp beschreibt.
			''' </summary>
			<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=80)>
			Public szTypeName As String

		End Structure

#End Region

#Region "API Definitionen"

		''' <summary>
		''' Zerstört ein Symbol und gibt jeglichen Speicher frei, den das Symbol belegt hat.
		''' </summary>
		''' <param name="hIcon">
		''' Ein Handle für das Symbol, das zerstört werden soll. Das Symbol darf nicht verwendet werden.
		''' </param>
		''' <remarks>
		''' https://learn.microsoft.com/de-de/windows/win32/api/winuser/nf-winuser-destroyicon
		''' </remarks>
		<Runtime.InteropServices.DllImport("User32.dll", EntryPoint:="DestroyIcon")>
		Private Function DestroyIcon(hIcon As IntPtr) As Integer
			'API Definition
		End Function

		''' <summary>
		''' Erstellt ein Array von Handles für große oder kleine Symbole, die aus der angegebenen
		''' ausführbaren Datei, DLL oder Symboldatei extrahiert wurden.
		''' </summary>
		''' <param name="lpszFile">
		''' Zeiger auf eine null-beendete Zeichenfolge, die den Namen einer ausführbaren Datei, 
		''' DLL oder Symboldatei angibt, aus der Symbole extrahiert werden.
		''' </param>
		''' <param name="nIconIndex">
		''' Gibt den nullbasierten Index des ersten Symbols an, das extrahiert werden soll.
		''' </param>
		''' <param name="phiconLarge">
		''' Zeiger auf ein Array von Symbolhandhandpunkten, die die großen Symbole empfängt, 
		''' die aus der Datei extrahiert wurden.
		''' </param>
		''' <param name="phiconSmall">
		''' Zeigen Sie auf ein Array von Symbolhandhandpunkten, die die kleinen Symbole empfängt, 
		''' die aus der Datei extrahiert wurden.
		''' </param>
		''' <param name="nIcons">
		''' Die Anzahl der Symbole, die aus der Datei extrahiert werden sollen.
		''' </param>
		''' <remarks>
		''' https://docs.microsoft.com/de-de/windows/win32/api/shellapi/nf-shellapi-extracticonexw
		''' </remarks>
		<Runtime.InteropServices.DllImport("shell32.dll", EntryPoint:="ExtractIconExW")>
		Private Function ExtractIconExW(
				<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPWStr)>
				lpszFile As String,
				nIconIndex As Integer,
				ByRef phiconLarge As IntPtr,
				ByRef phiconSmall As IntPtr,
				nIcons As UInteger) As UInteger
			'API Definition
		End Function

		''' <summary>
		''' Ruft Informationen zu einem Objekt im Dateisystem ab, z. B. eine Datei, einen Ordner,
		''' ein Verzeichnis oder einen Laufwerkstamm.
		''' </summary>
		''' <param name="pszPath">
		''' Ein Zeiger auf eine null-beendete Zeichenfolge mit maximaler Länge MAX_PATH, 
		''' die den Pfad und dateinamen enthält.
		''' </param>
		''' <param name="dwFileAttributes">
		''' Eine Kombination aus einem oder mehreren Dateiattributen 
		''' (FILE_ATTRIBUTE_ Werte gemäß Der Definition in Winnt.h).
		''' </param>
		''' <param name="psfi">
		''' Zeiger auf eine SHFILEINFO-Struktur , um die Dateiinformationen zu erhalten.
		''' </param>
		''' <param name="cbFileInfo">
		''' Die Größe in Bytes der SHFILEINFO-Struktur , auf die der psfi-Parameter verweist.
		''' </param>
		''' <param name="uFlags">
		''' Die Flags, die die abzurufenden Dateiinformationen angeben.
		''' </param>
		''' <remarks>
		''' https://docs.microsoft.com/de-de/windows/win32/api/shellapi/nf-shellapi-shgetfileinfow
		''' </remarks>
		<Runtime.InteropServices.DllImport("shell32.dll", EntryPoint:="SHGetFileInfoW")>
		Private Function SHGetFileInfoW(
				<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPWStr)>
				pszPath As String,
				dwFileAttributes As Integer,
				ByRef psfi As SHFILEINFOW,
				cbFileInfo As Integer,
				uFlags As Integer) As Integer
			'API Definition
		End Function

#End Region

#Region "Interne Funktionen"

		''' <summary>
		''' Wandelt ein Bild in HTML-Code
		''' </summary>
		Private Function InternalGetHtmlCode(sender As System.Drawing.Bitmap, RelSize As Integer, Alt As String) As String

			Dim code As String = "<img width='{0}' height='{1}' src='data:image;base64,{2}' alt='{3}' />"

			'Base64 - Code erzeugen
			Dim b64code As String = sender.ToBase64

			'Bildgröße anpassen
			Dim w As Integer = CInt(sender.Width / 100 * RelSize)
			Dim h As Integer = CInt(sender.Height / 100 * RelSize)

			'Ergebnis zurück
			Return String.Format(code, CStr(w), CStr(h), b64code, Alt)

		End Function

		''' <summary>
		''' Gibt das Symbol zurück welches einer Datei, eines Ordners oder einer Dateierweiteung zugeordnet ist.
		''' </summary>
		Private Function InternalGetBitmapFromFilePathOrExt(FilePathOrExt As String, Size As IconSizes) As System.Drawing.Bitmap

			Dim fi As New SHFILEINFOW
			Dim fa = If(FilePathOrExt.StartsWith(".", True, Globalization.CultureInfo.CurrentCulture), Size Or SHGFI_USEFILEATTRIBUTES, Size)

			If SHGetFileInfoW(FilePathOrExt, 0, fi, Runtime.InteropServices.Marshal.SizeOf(fi), SHGFI_ICON Or fa) <> 0 Then
				Return System.Drawing.Icon.FromHandle(fi.hIcon).ToBitmap
				Dim unused = DestroyIcon(fi.hIcon)
				Exit Function
			End If

			Return Nothing

		End Function

#End Region

		''' <summary>
		''' Wandelt das Bitmap in Html-Code.
		''' </summary>
		''' <param name="RelSize">
		''' Relative Größe des Bitmap in Prozent.
		''' </param>
		''' <param name="Alt">
		''' Alternativer Text.
		''' </param>
		''' <returns>
		''' Der erzeugte Html-Code oder leer wenn Bitmap Nothing ist.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToHtml(sender As System.Drawing.Bitmap, RelSize As Integer, Alt As String) As String

			If IsNothing(sender) Then Return ""
			Return InternalGetHtmlCode(sender, RelSize, Alt)

		End Function

		''' <summary>
		''' Wandelt das Bitmap in Html-Code.
		''' </summary>
		''' <param name="RelSize">
		''' Relative Größe des Bitmap in Prozent.
		''' </param>
		''' <returns>
		''' Der erzeugte Html-Code oder leer wenn Bitmap Nothing ist.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToHtml(sender As System.Drawing.Bitmap, RelSize As Integer) As String

			If IsNothing(sender) Then Return ""
			Return InternalGetHtmlCode(sender, RelSize, "")

		End Function

		''' <summary>
		''' Wandelt das Bitmap in Html-Code.
		''' </summary>
		''' <param name="Alt">
		''' Alternativer Text.
		''' </param>
		''' <returns>
		''' Der erzeugte Html-Code oder leer wenn Bitmap Nothing ist.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToHtml(sender As System.Drawing.Bitmap, Alt As String) As String

			If IsNothing(sender) Then Return ""
			Return InternalGetHtmlCode(sender, 100, Alt)

		End Function

		''' <summary>
		''' Wandelt Base64-Code in ein Bitmap um.
		''' </summary>
		''' <param name="Base64Code">
		''' Der Base64-Code.
		''' </param>
		''' <returns>
		''' Das erzeugte Bitmap oder Nothing wenn der Parameter Bas64Code keinen wert enthält.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		<CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification:="<Ausstehend>")>
		Public Function FromBase64(sender As System.Drawing.Bitmap, Base64Code As String) As System.Drawing.Bitmap

			'Nothing zurück wenn der Parameter Base64Code keinen Wert enthält.
			If String.IsNullOrEmpty(Base64Code) Then Return Nothing

			Dim ic As New System.Drawing.ImageConverter

			'String decodieren und in Byte-Array umwandeln
			Dim bytes() As Byte = Convert.FromBase64String(Base64Code)

			'Byte-Array in Image-Objekt umwandeln und das Image-Objekt zurückgeben 
			Return CType(ic.ConvertFrom(bytes), System.Drawing.Bitmap)

		End Function

		''' <summary>
		''' Wandelt ein Bitmap in Base64-Code.
		''' </summary>
		''' <returns>
		''' Der erzeugte Base64-Code.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ToBase64(sender As System.Drawing.Bitmap) As String

			Dim ic As New System.Drawing.ImageConverter

			'Bitmap in Byte-Array umwandeln
			Dim bytes() As Byte = CType(ic.ConvertTo(sender, GetType(Byte())), Byte())

			'Byte-Array in Base64-codierten String umwandeln	und Datenstring zurückgeben
			Return Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks)

		End Function

		''' <summary>
		''' Gibt das Symbol zurück welches einer Datei, eines Ordners oder einer Dateierweiteung zugeordnet ist.
		''' </summary>
		''' <param name="FilePathOrExt">
		''' Der Pfad zu einer Datei, einem Ordner oder die Dateierweiterung.
		''' </param>
		''' <param name="Size">
		''' Die gewünschte Größe des Symbols. (16x16 oder 32x32 Pixel)
		''' </param>
		''' <returns>
		''' Ein Bitmap bei Erfolg oder Nothing bei Fehler.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		<CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification:="<Ausstehend>")>
		Public Function FromFilePathOrExt(sender As System.Drawing.Bitmap, FilePathOrExt As String, Size As IconSizes) As System.Drawing.Bitmap

			'Ergebnis = Nothing wenn Parameter Null oder leer ist
			If String.IsNullOrEmpty(FilePathOrExt) Then Return Nothing

			Return InternalGetBitmapFromFilePathOrExt(FilePathOrExt, Size)

		End Function

		''' <summary>
		''' Gibt das Symbol zurück welches einer Datei, eines Ordners oder einer Dateierweiteung zugeordnet ist.
		''' </summary>
		''' <param name="FilePathOrExt">
		''' Der Pfad zu einer Datei, einem Ordner oder die Dateierweiterung.
		''' </param>
		''' <returns>
		''' Ein Bitmap bei Erfolg oder Nothing bei Fehler.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		<CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification:="<Ausstehend>")>
		Public Function FromFilePathOrExt(sender As System.Drawing.Bitmap, FilePathOrExt As String) As System.Drawing.Bitmap

			'Ergebnis = Nothing wenn Parameter Null oder leer ist
			If String.IsNullOrEmpty(FilePathOrExt) Then Return Nothing

			Return InternalGetBitmapFromFilePathOrExt(FilePathOrExt, IconSizes.x16)

		End Function

		''' <summary>
		''' Gibt das angeforderte Symbol zurück.
		''' </summary>
		''' <param name="File">
		''' Vollständiger Pfad zu der Datei aus der das Symbol extrahiert werden soll.
		''' </param>
		''' <param name="Index">
		''' Nullbasierter Index des Symbols welches extrahiert werden soll.
		''' </param>
		''' <param name="Size">
		''' Größe des Symbols das extrahiert werden soll.
		''' </param>
		''' <returns>
		''' Ein Bitmap welches das angeforderte Symbol darstellt oder Nothing.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		Public Function ExtractIcon(sender As System.Drawing.Bitmap,
									File As String, Index As Integer,
									Optional Size As IconSizes = IconSizes.x16) As System.Drawing.Bitmap

			'Ergebnis = Nothing wenn Parameter leer ist
			If String.IsNullOrEmpty(File) Then
				Return Nothing
				Exit Function
			End If

			'Ergebnis = Nothing wenn Datei nicht existiert
			If Not IO.File.Exists(File) Then
				Return Nothing
				Exit Function
			End If

			'Ergebnis = Nothing wenn der Symbolindex < 0 oder >= Anzahl der Symbol in der Datei ist
			If Index < 0 OrElse Index >= GetFileIcons(sender, File) Then
				Return Nothing
				Exit Function
			End If

			'Handle auf das Symbol erstellen
			Dim hIcon As IntPtr = Nothing
			Select Case Size

				Case IconSizes.x16  'kleines Symbol extrahieren wenn gefordert
					Dim unused1 = ExtractIconExW(File, Index, Nothing, hIcon, 1)

				Case IconSizes.x32 'großes Symbol extrahieren wenn gefordert
					Dim unused2 = ExtractIconExW(File, Index, hIcon, Nothing, 1)

				Case Else

			End Select

			'Symbol extrahieren	und Ergebnis zurück
			Return System.Drawing.Icon.FromHandle(hIcon).ToBitmap

			'Handle zerstören
			Dim unused = DestroyIcon(hIcon)

		End Function

		''' <summary>
		''' Gibt die Anzahl der Symbole zurück die in der Datei enthalten sind,
		''' die im Parameter "<paramref name="File"/>" angegeben ist.
		''' </summary>
		''' <param name="File">
		''' Pfad und Datei deren Symbolanzahl ermittelt werden soll.
		''' </param>
		''' <returns>
		''' Die nullbasierte Anzahl der in der Datei enthaltenen Symbole oder -1 bei Fehler.
		''' </returns>
		<System.Diagnostics.DebuggerStepThrough>
		<System.Runtime.CompilerServices.Extension>
		<CodeAnalysis.SuppressMessage("Style", "IDE0060:Nicht verwendete Parameter entfernen", Justification:="<Ausstehend>")>
		Public Function GetFileIcons(sender As System.Drawing.Bitmap, File As String) As Integer

			'-1 zurück wenn Parameter leer ist
			If String.IsNullOrEmpty(File) Then Return -1

			'-1 zurück wenn Datei nicht vorhanden ist
			If Not IO.File.Exists(File) Then Return -1

			'Anzahl der in der Datei vorhandenen Symbole ermitteln und Ergebnis zurück
			Return CInt(ExtractIconExW(File, -1, Nothing, Nothing, 0))

		End Function

	End Module

End Namespace
