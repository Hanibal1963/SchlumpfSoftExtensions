## GenericExtensions

Enthält benutzerdefinierte Erweiterungsmethoden zur Verwendung mit:

- [Die Elementanzahl eines Arrays ändern](GenericExtensions.md#Die_Elementanzahl_eines_Arrays_ändern)
- [Byte() oder IEnumerable(Of Byte) in String-Darstellung konvertieren](GenericExtensions.md#Byte()_oder_IEnumerable(Of_Byte)_in_String-Darstellung_konvertieren)
- [Erweiterungsmethoden für IEnumerable(Of String)](GenericExtensions.md#Erweiterungsmethoden_für_IEnumerable(Of_String))


---


### Die Elementanzahl eines Arrays ändern

Mit dieser Funktion wird die Elementanzahl eines Array neu definiert.

```<vb>
Dim MyArray(x) as Type
MyArray = MyArray.Resize(y)
```

---


### Byte() oder IEnumerable(Of Byte) in String-Darstellung konvertieren

Mit diesen beiden Funktionen wird der Inhalt in einen String 
(unter Angabe der Codierung) konvertiert.

```<vb>
Dim Var1() as Byte = {84, 101, 115, 116}
Console.WriteLine(Var1.ToString(Encoding.ASCII))

'oder

Dim Var2 as IEnumerable(Of Byte) = {84, 101, 115, 116}
Console.WriteLine(Var2.ToString(Encoding.ASCII))
```


---


### Erweiterungsmethoden für IEnumerable(Of String)


Die folgenden beiden Methoden ermitteln die Anzahl leerer oder nicht leerer Elemente:

```<vb>
Dim var As IEnumerable(Of String) = {"Hallo", "", " ", "Welt", "!"}

'Anzahl der leeren Elemente ermitteln
Console.WriteLine("Anzahl der leeren Elemente: " & var.CountEmptyItems)

'Anzahl der nicht leeren Elemente ermitteln
Console.WriteLine("Anzahl der nicht leeren Elemente: " & var.CountNonEmptyItems)
```







 - Extension Functions
   - IEnumerable(Of String).BubbleSort As IEnumerable(Of String)
   - IEnumerable(Of String).FindByContains(String, Boolean) As IEnumerable(Of String)
   - IEnumerable(Of String).FindByLike(String, Boolean) As IEnumerable(Of String)
   - IEnumerable(Of String).FindExact(String, StringComparison) As IEnumerable(Of String)
   - IEnumerable(Of String).RemoveByContains(String, Boolean) As IEnumerable(Of String)
   - IEnumerable(Of String).RemoveByLike(String, Boolean) As IEnumerable(Of String)
   - IEnumerable(Of String).RemoveExact(String, StringComparison) As IEnumerable(Of String)



---


### Erweiterungsmethoden für IEnumerable(Of T) Extensions
Contains custom extension methods to use with an IEnumerable(Of T).

Public Members Summary

 - Extension Functions
   - IEnumerable(Of T)().ConcatMultiple(IEnumerable(Of T)()) As IEnumerable(Of T)
   - IEnumerable(Of T)().StringJoin As IEnumerable(Of T)
   - IEnumerable(Of T).CountEmptyItems As Integer
   - IEnumerable(Of T).CountNonEmptyItems As Integer
   - IEnumerable(Of T).Duplicates As IEnumerable(Of T)
   - IEnumerable(Of T).Randomize As IEnumerable(Of T)
   - IEnumerable(Of T).RemoveDuplicates As IEnumerable(Of T)
   - IEnumerable(Of T).SplitIntoNumberOfElements(Integer) As IEnumerable(Of T)
   - IEnumerable(Of T).SplitIntoNumberOfElements(Integer, Boolean, T) As IEnumerable(Of T)
   - IEnumerable(Of T).SplitIntoParts(Integer) As IEnumerable(Of T)
   - IEnumerable(Of T).UniqueDuplicates As IEnumerable(Of T)
   - IEnumerable(Of T).Uniques As IEnumerable(Of T)


