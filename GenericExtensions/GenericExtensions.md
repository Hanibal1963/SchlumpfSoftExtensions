## GenericExtensions

Enthät verschiedene Erweiterungsmethoden für Arrays und Auflistungstypen.

- [Die Elementanzahl eines Arrays ändern](GenericExtensions.md#die-elementanzahl-eines-arrays-ändern)
- [Byte() oder IEnumerable(Of Byte) in String-Darstellung konvertieren](GenericExtensions.md#Byte-oder_IEnumerableOf-Byte-in-String-Darstellung-konvertieren)
- [Leere oder nicht leere Elemente in IEnumerable(Of String) ermitteln](GenericExtensions.md#Leere_oder_nicht_leere_Elemente_in_IEnumerableOf_String_ermitteln)
- [Exakt gesuchte Werte in IEnumerable(Of String) ermitteln](GenericExtensions.md#Exakt_gesuchte_Werte_in_IEnumerableOf_String_ermitteln)
- [Elemente die eine angegebene Zeichenfolge enthalten in IEnumerableOf String ermitteln](GenericExtensions.md#Elemente_die_eine_angegebene_Zeichenfolge_enthalten_in_IEnumerableOf_String_ermitteln)
- [Elemente die einem Muster entsprechen in IEnumerableOf String ermitteln](GenericExtensions.md#Elemente_die_einem_Muster_entsprechen_in_IEnumerableOf_String_ermitteln)


---


### Die Elementanzahl eines Arrays ändern

Mit dieser Funktion wird die Elementanzahl eines Array neu definiert.

```vb
Dim MyArray(x) as Type
MyArray = MyArray.Resize(y)
```

---


### Byte() oder IEnumerable(Of Byte) in String-Darstellung konvertieren

Mit diesen beiden Funktionen wird der Inhalt in einen String 
(unter Angabe der Codierung) konvertiert.

```vb
Dim Var1() as Byte = {84, 101, 115, 116}
Console.WriteLine(Var1.ToString(Encoding.ASCII))

'oder

Dim Var2 as IEnumerable(Of Byte) = {84, 101, 115, 116}
Console.WriteLine(Var2.ToString(Encoding.ASCII))
```

---


### Leere oder nicht leere Elemente in IEnumerable(Of String) ermitteln


Die folgenden beiden Methoden ermitteln die Anzahl leerer oder nicht leerer Elemente:


```vb
Dim var As IEnumerable(Of String) = {"Hallo", "", " ", "Welt", "!"}

'Anzahl der leeren Elemente ermitteln
Console.WriteLine("Anzahl der leeren Elemente: " & var.CountEmptyItems)

'Anzahl der nicht leeren Elemente ermitteln
Console.WriteLine("Anzahl der nicht leeren Elemente: " & var.CountNonEmptyItems)
```

---


### Exakt gesuchte Werte in IEnumerable(Of String) ermitteln

Die folgende Methode findet exakt die gesuchten Werte in der Auflistung unter Einhaltung 
der angegebenen Sortierregeln.


```vb
Dim var As IEnumerable(Of String) = {"Hello", "Welt", "!!", "a", "b", "c", "welt"}
Dim result As String

Debug.Print("Es wird in der Variablen " & var.ToString & " ( ) nach dem Begriff """ & var.Last & """ gesucht ..." & vbCrLf)

Debug.Print("Groß und Kleinschreibung wird ignoriert:")
result = String.Join(" ,", var.FindExact(var.Last, StringComparison.OrdinalIgnoreCase))
Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)

Debug.Print("Groß und Kleinschreibung wird eingehalten:")
result = String.Join(" ,", var.FindExact(var.Last, StringComparison.Ordinal))
Debug.Print("Es wurde ""{0}"" gefunden.", result)
```


### Elemente die eine angegebene Zeichenfolge enthalten in IEnumerable(Of String) ermitteln

Die folgende Methode findet die Werte die die angegebene Zeichenfolge unter Einhaltung 
der angegebenen Sortierregeln enthalten.


```vb
Dim var As IEnumerable(Of String) = {"Hallo Welt !!", "a", "b", "c", "welt"}
Dim result As String

Debug.Print("Es wird in der Variablen " & var.ToString & " ( ) nach dem Begriff """ & var.Last & """ gesucht ..." & vbCrLf)

Debug.Print("Groß und Kleinschreibung wird ignoriert:")
result = String.Join(" ,", var.FindByContains(var.Last, True))
Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)

Debug.Print("Groß und Kleinschreibung wird eingehalten:")
result = String.Join(" ,", var.FindByContains(var.Last, False))
Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)
```


---


### Elemente die einem Muster entsprechen in IEnumerable(Of String) ermitteln

Die folgende Methode führt eine Mustersuche durch und findet 
die Werte die dem angegebenem Muster entsprechen.


```vb
Dim var As IEnumerable(Of String) = {"Hallo Welt !!", "a", "b", "c", "welt"}
Dim result As String

Debug.Print("Es wird in der Variablen " & var.ToString & " ( ) nach dem Begriff """ & "*" & var.Last & "*" & """ gesucht ..." & vbCrLf)

Debug.Print("Groß und Kleinschreibung wird ignoriert:")
result = String.Join(" ,", var.FindByLike("*" & var.Last & "*", True))
Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)

Debug.Print("Groß und Kleinschreibung wird eingehalten:")
result = String.Join(" ,", var.FindByLike("*" & var.Last & "*"))
Debug.Print("Es wurde ""{0}"" gefunden." & vbCrLf, result)
```


---






   - IEnumerable(Of String).BubbleSort As IEnumerable(Of String)
   - IEnumerable(Of String).RemoveByContains(String, Boolean) As IEnumerable(Of String)
   - IEnumerable(Of String).RemoveByLike(String, Boolean) As IEnumerable(Of String)
   - IEnumerable(Of String).RemoveExact(String, StringComparison) As IEnumerable(Of String)



---



