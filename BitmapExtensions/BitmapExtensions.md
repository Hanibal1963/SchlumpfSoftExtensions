## BitmapExtensions

Verschieden Erweiterungsmethoden für die Bitmapklasse.

- [Zugeordentes Symbol ermitteln](BitmapExtensions.md#Zugeordentes-Symbol-ermitteln)
- [Alle enthaltenen Symbole ermitteln](BitmapExtensions.md#Alle-enthaltenen-Symbole-ermitteln)
- [Die Anzahl der enthaltenen Symbole ermitteln](BitmapExtensions.md#Die-Anzahl-der-enthaltenen-Symbole-ermitteln)


---


###  Zugeordentes Symbol ermitteln


Diese Funktion gibt das Symbol zurück welches einer Datei, eines Ordners oder einer Dateierweiteung zugeordnet ist.

```vb
Dim ext as String = ".doc"
Dim file as String = "c:\file.ext"
Dim folder as String = "c:\folder"
Dim bm As Bitmap = Nothing

'Das Symbol einer Dateierweiterung ermitteln
PictureBox1.Image = bm.FromFilePathOrExt(ext)
PictureBox2.Image = bm.FromFilePathOrExt(ext, IconSizes.x32)

'Das Symbol einer Datei ermitteln
PictureBox1.Image = bm.FromFilePathOrExt(file)
PictureBox2.Image = bm.FromFilePathOrExt(fille, IconSizes.x32)

'Das Symbol eines Ordners ermitteln
PictureBox1.Image = bm.FromFilePathOrExt(folder)
PictureBox2.Image = bm.FromFilePathOrExt(folder, IconSizes.x32)
```


---


### Alle enthaltenen Symbole ermitteln

Diese Funktion gibt alle in einer Datei enthaltenen Symbole zurück.

```vb
Dim file as String = "c:\file.ext"
Dim index as Integer = x
Dim bm As Bitmap = Nothing

PictureBox1.Image = bm.ExtractIcon(file, index)
PictureBox2.Image = bm.ExtractIcon(file, index, IconSizes.x32)
```

---


### Die Anzahl der enthaltenen Symbole ermitteln

Diese Funktion ermittelt die nullbasierte Anzahl der in einer Datei enthaltenen Symbole.

```vb
Dim file as String = "c:\file.ext"
Dim bm As Bitmap = Nothing
Dim index as Integer = bm.GetFileIcons(file) - 1
```
