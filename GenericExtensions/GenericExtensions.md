## GenericExtensions

Enthät verschiedene Erweiterungsmethoden für Arrays und Auflistungstypen.

- [Die Elementanzahl eines Arrays ändern](GenericExtensions.md#die-elementanzahl-eines-arrays-ändern)
- [Byte() oder IEnumerable(Of Byte) in String-Darstellung konvertieren](GenericExtensions.md#Byte-oder-IEnumerableOf-Byte-in-String-Darstellung-konvertieren)
- [Leere oder nicht leere Elemente in IEnumerable(Of String) ermitteln](GenericExtensions.md#Leere-oder-nicht-leere-Elemente-in-IEnumerableOf-String-ermitteln)
- [Exakt gesuchte Werte in IEnumerable(Of String) ermitteln](GenericExtensions.md#Exakt-gesuchte-Werte-in-IEnumerableOf-String-ermitteln)
- [Elemente die eine angegebene Zeichenfolge enthalten in IEnumerableOf String ermitteln](GenericExtensions.md#Elemente-die-eine-angegebene-Zeichenfolge-enthalten-in-IEnumerableOf-String-ermitteln)
- [Elemente die einem Muster entsprechen in IEnumerableOf String ermitteln](GenericExtensions.md#Elemente-die-einem-Muster-entsprechen-in-IEnumerableOf-String-ermitteln)
- [Elemente von IEnmerable(Of String) sortieren](GenericExtensions.md#Elemente-von-IEnmerable(Of-String)-sortieren)
- [Elemente aus IEnumerable(Of String) entfernen die einem angegebenem Muster entsprechen](GenericExtensions.md#Elemente-aus-IEnumerable(Of-String)-entfernen-die-einem-angegebenem-Muster-entsprechen)
- [Elemente aus IEnumerable(Of String) entfernen die genau Zeichenfolge entsprechen](GenericExtensions.md#Elemente-aus-IEnumerable(Of-String)-entfernen-die-einer-Zeichenfolge-entsprechen)
- [Elemente aus IEnumerable(Of String) entfernen die genau einer Zeichenfolge entsprechen](GenericExtensions.md#Elemente-aus-IEnumerable(Of-String)-entfernen-die-genau-einer-Zeichenfolge-entsprechen)


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

---


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


### Elemente von IEnmerable(Of String) sortieren

Mit dieser Funktion werden die Elemente der Auflistung nach der Bubble-Sort-Methode sortiert.

```vb
Dim var As IEnumerable(Of String) = {"10", "333", "2", "45"}

Debug.Print("Der ursprüngliche Inhalt von {0} lautet:", var.ToString)
Debug.Print(String.Join(" ,", var) & vbCrLf)

Debug.Print("Der sortierte Inhalt von {0} lautet:", var.ToString)
Debug.Print(String.Join(", ", var.BubbleSort))
```


---


### Elemente aus IEnumerable(Of String) entfernen die einem angegebenem Muster entsprechen

Die folgende Funktion entfernt alle Werte die einem angegebenem Muster entsprechen.

```vb
Debug.Print("*** IEnumerable(Of String).RemoveByLike() Funktionstest ***" & vbCrLf)

Dim var As IEnumerable(Of String) = {"Hallo Welt !!!", "a", "b", "c", "hallo"}
Debug.Print("Der Wert ""{0}"" soll aus der Auflistung ""{1}"" entfernt werden.", "*" & var.Last & "*", var.ToString)
Debug.Print("Ursprünglicher Inhalt: ""{0}""" & vbCrLf, String.Join(" ,", var))

Debug.Print("Groß- und Kleinschreibung wird ignoriert ...")
Debug.Print(String.Join(", ", var.RemoveByLike("*" & var.Last & "*")) & vbCrLf)

Debug.Print("Groß- und Kleinschreibung wird beachtet ...")
Debug.Print(String.Join(", ", var.RemoveByLike("*" & var.Last & "*", False)))
```

---


### Elemente aus IEnumerable(Of String) entfernen die einer Zeichenfolge entsprechen

Die folgende Funktion entfernt alle Werte die einer angegebenen Zeichenfolge entsprechen.

```vb
Debug.Print("*** IEnumerable(Of String).RemoveByContains() Funktionstest ***" & vbCrLf)

Dim var As IEnumerable(Of String) = {"Hallo Welt !!!", "a", "b", "c", "hallo"}
Debug.Print("Der Wert ""{0}"" soll aus der Auflistung ""{1}"" entfernt werden.", var.Last, var.ToString)
Debug.Print("Ursprünglicher Inhalt: ""{0}""" & vbCrLf, String.Join(" ,", var))

Debug.Print("Groß- und Kleinschreibung wird ignoriert ...")
Debug.Print(String.Join(", ", var.RemoveByContains(var.Last)) & vbCrLf)

Debug.Print("Groß- und Kleinschreibung wird beachtet ...")
Debug.Print(String.Join(", ", var.RemoveByContains(var.Last, False)))
```


---


### Elemente aus IEnumerable(Of String) entfernen die genau einer Zeichenfolge entsprechen

Die folgende Funktion entfern alle Elemente die genau der angegebenen Zeichenfolge entsprechen.

```vb
Debug.Print("*** IEnumerableIEnumerable(Of String).RemoveExact() Funktionstest ***" & vbCrLf)

Dim var As IEnumerable(Of String) = {"Hallo Welt !!!", "a", "b", "c", "hallo"}
Debug.Print("Der Wert ""{0}"" soll aus der Auflistung ""{1}"" entfernt werden.", var.Last, var.ToString)
Debug.Print("Ursprünglicher Inhalt: ""{0}""" & vbCrLf, String.Join(" ,", var))

Debug.Print("Groß- und Kleinschreibung wird ignoriert ...")
Debug.Print(String.Join(", ", var.RemoveExact(var.Last, StringComparison.OrdinalIgnoreCase)) & vbCrLf)

Debug.Print("Groß- und Kleinschreibung wird beachtet ...")
Debug.Print(String.Join(", ", var.RemoveExact(var.Last, StringComparison.Ordinal)))
```
