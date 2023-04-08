'
'****************************************************************************************************************
'BitmapExtensions.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'


Option Strict On
Option Explicit On
Option Infer On


Namespace Extensions


	''' <summary>
	''' Enthält Erweiterungsfunktionen für die Klasse <seealso cref="System.Drawing.Bitmap"/> 
	''' </summary>
	Public Module BitmapExtensions


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
		<System.Diagnostics.CodeAnalysis.SuppressMessage(
		"Style", "IDE0060:Nicht verwendete Parameter entfernen",
		Justification:="Parameter wird für Erweiterungsmethoden benötigt.")>
		Public Function FromFilePathOrExt(sender As System.Drawing.Bitmap,
										  FilePathOrExt As String,
										  Optional Size As IconSizes = IconSizes.x16) As System.Drawing.Bitmap
			'Ergebnis = Nothing wenn Parameter Null oder leer ist
			If String.IsNullOrEmpty(FilePathOrExt) Then
				Return Nothing
				Exit Function
			End If
			Dim fi As New NativeMethods.SHFILEINFOW
			Dim fa = If(FilePathOrExt.StartsWith(".", True, Globalization.CultureInfo.CurrentCulture),
				Size Or NativeMethods.SHGFI_USEFILEATTRIBUTES, Size)
			If NativeMethods.SHGetFileInfoW(FilePathOrExt, 0, fi, Runtime.InteropServices.Marshal.SizeOf(fi),
											NativeMethods.SHGFI_ICON Or fa) <> 0 Then
				Return System.Drawing.Icon.FromHandle(fi.hIcon).ToBitmap
				Dim unused = NativeMethods.DestroyIcon(fi.hIcon)
				Exit Function
			End If
			Return Nothing
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
			'Ergebnis = Nothing wenn der Symbolindex < 0 und >= Anzahl der Symbol in der Datei ist
			If Index < 0 Or Index >= GetFileIcons(sender, File) Then
				Return Nothing
				Exit Function
			End If
			'Handle auf das Symbol erstellen
			Dim hIcon As IntPtr = Nothing
			Select Case Size
				Case IconSizes.x16
					'kleines Symbol extrahieren wenn gefordert
					Dim unused = NativeMethods.ExtractIconExW(File, Index, Nothing, hIcon, 1)
				Case IconSizes.x32
					'großes Symbol extrahieren wenn gefordert
					Dim unused1 = NativeMethods.ExtractIconExW(File, Index, hIcon, Nothing, 1)
			End Select
			'Symbol extrahieren	und Ergebnis zurück
			Return System.Drawing.Icon.FromHandle(hIcon).ToBitmap
			'Handle zerstören
			Dim unused2 = NativeMethods.DestroyIcon(hIcon)
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
		<System.Diagnostics.CodeAnalysis.SuppressMessage(
		"Style", "IDE0060:Nicht verwendete Parameter entfernen",
		Justification:="Parameter wird für Erweiterungsmethoden benötigt.")>
		Public Function GetFileIcons(sender As System.Drawing.Bitmap,
									 File As String) As Integer
			'-1 zurück wenn Parameter leer ist
			If String.IsNullOrEmpty(File) Then
				Return -1
				Exit Function
			End If
			'-1 zurück wenn Datei nicht vorhanden ist
			If Not IO.File.Exists(File) Then
				Return -1
				Exit Function
			End If
			'Anzahl der in der Datei vorhandenen Symbole ermitteln und Ergebnis zurück
			Return CInt(NativeMethods.ExtractIconExW(File, -1, Nothing, Nothing, 0))
		End Function



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




		''' <summary>
		''' API-Definitionen
		''' </summary>
		Private Class NativeMethods



			Public Const SHGFI_ICON = &H100
			Public Const SHGFI_USEFILEATTRIBUTES = &H10




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
			Public Shared Function DestroyIcon(
											  hIcon As IntPtr) As Integer
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
			Public Shared Function ExtractIconExW(
				<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPWStr)>
				lpszFile As String,
				nIconIndex As Integer,
				ByRef phiconLarge As IntPtr,
				ByRef phiconSmall As IntPtr,
				nIcons As UInteger) As UInteger
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
			Public Shared Function SHGetFileInfoW(
				<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPWStr)>
				pszPath As String,
				dwFileAttributes As Integer,
				ByRef psfi As SHFILEINFOW,
				cbFileInfo As Integer,
				uFlags As Integer) As Integer
			End Function


			''' <summary>
			''' Enthält Informationen zu einem Dateiobjekt.
			''' </summary>
			''' <remarks>
			''' https://learn.microsoft.com/de-de/windows/win32/api/shellapi/ns-shellapi-shfileinfoa
			''' </remarks>
			<Runtime.InteropServices.StructLayout(
				Runtime.InteropServices.LayoutKind.Sequential,
				CharSet:=Runtime.InteropServices.CharSet.Unicode)>
			Public Structure SHFILEINFOW

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
				<Runtime.InteropServices.MarshalAs(
					Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=260)>
				Public szDisplayName As String

				''' <summary>
				''' Eine Zeichenfolge, die den Dateityp beschreibt.
				''' </summary>
				<Runtime.InteropServices.MarshalAs(
					Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=80)>
				Public szTypeName As String

			End Structure


		End Class



	End Module


End Namespace
