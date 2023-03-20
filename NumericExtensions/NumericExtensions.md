
## NumericExtensions

Diese Vorlage enthält benutzerdefinierte Erweiterungsmethoden zur Verwendung mit den 
Datentypen System.Int16, System.UInt16, System.Int32, System.UInt32, System.Int64, 
System.UInt64, System.Decimal, System.Single und System.Double.


Die Anregung für diese und weitere Vorlagen stammen aus dem etwas älteren 
[GitHub-Repository **VBNetSnippets** von **ElektroStudios**](https://github.com/ElektroStudios/VBNetSnippets)


---


## Die folgenden Funktionen sind vorhanden:

- [Prozentsatz eines Wertes von einem Gesamtwert berechnen](NumericExtensions.md#Prozentsatz-eines-Wertes-von-einem-Gesamtwert-berechnen)
- [Den Bruchteil eines Wertes berechnen](NumericExtensions.md#Den-Bruchteil-eines-Wertes-berechnen)
- [Bestimmen ob ein Wert positiv ist](NumericExtensions.md#Bestimmen-ob-ein-Wert-positiv-ist)
- [Bestimmen ob der Wert negativ ist](NumericExtensions.md#Bestimmen-ob-der-Wert-negativ-ist)
- [Bestimmen ob der Wert eine Primzahl ist](NumericExtensions.md#Bestimmen-ob-der-Wert-eine-Primzahl-ist)
- [Bestimmen ob ein Wert durch einen angegebenen Wert ohne Rest teilbar ist](NumericExtensions.md#Bestimmen-ob-ein-Wert-durch-einen-angegebenen-Wert-ohne-Rest-teilbar-ist)
- [Bestimmen ob ein angegebener Wert ein vielfaches vom Wert ist](NumericExtensions.md#Bestimmen-ob-ein-angegebener-Wert-ein-vielfaches-vom-Wert-ist)
- [Die Differenz zwischen dem Wert und einem angegebenen Wert bestimmen](NumericExtensions.md#Die-Differenz-zwischen-dem-Wert-und-einem-angegebenen-Wert-bestimmen)
- [Den Wert in die Hexadezimale Darstellung für Visual Basic konvertieren](NumericExtensions.md#Den-Wert-in-die-Hexadezimale-Darstellung-für-Visual-Basic-konvertieren)
- [Den Wert in die Hexadezimale Darstellung für C# konvertieren](NumericExtensions.md#Den-Wert-in-die-Hexadezimale-Darstellung-für-C#-konvertieren)
- [Den Wert in Abhängigkeit von der Genauigkeit und der Kultur formatieren](NumericExtensions.md#Den-Wert-in-Abhängigkeit-von-der-Genauigkeit-und-der-Kultur-formatieren)


---


### Prozentsatz eines Wertes von einem Gesamtwert berechnen
 
Die folgenden Funktionen geben den Prozentsatz eines Wertes von dem Parameterwert zurück.

```<vb>
 Short.PercentageOf(Double) As Double
 UShort.PercentageOf(Double) As Double
 Integer.PercentageOf(Double) As Double
 UInteger.PercentageOf(Double) As Double
 Long.PercentageOf(Double) As Double
 ULong.PercentageOf(Double) As Double
 Decimal.PercentageOf(Double) As Double
 Single.PercentageOf(Double) As Double
 Double.PercentageOf(Double) As Double
```

---


### Den Bruchteil eines Wertes berechnen

Die folgenden Funktionen geben den Bruchteil (Prozentsatz) eines Wertes	zurück.

```<vb>
 Short.FractionBy(Double) As Double
 UShort.FractionBy(Double) As Double
 Integer.FractionBy(Double) As Double
 UInteger.FractionBy(Double) As Double
 Long.FractionBy(Double) As Double
 ULong.FractionBy(Double) As Double
 Decimal.FractionBy(Double) As Double
 Single.FractionBy(Double) As Double
 Double.FractionBy(Of Double) As Double
```

---


### Bestimmen ob ein Wert positiv ist

Die folgenden Funktionen geben True zurück wenn der Wert positiv ist.

```<vb>
 Short.IsPositive() As Boolean
 Integer.IsPositive() As Boolean
 Long.IsPositive() As Boolean
 Decimal.IsPositive() As Boolean
 Single.IsPositive() As Boolean
 Double.IsPositive() As Boolean
```


---


### Bestimmen ob der Wert negativ ist

Die folgenden Funktionen geben True zurück wenn der Wert negativ ist.

```<vb>
 Short.IsNegative() As Boolean
 Integer.IsNegative() As Boolean
 Long.IsNegative() As Boolean
 Decimal.IsNegative() As Boolean
 Single.IsNegative() As Boolean
 Double.IsNegative() As Boolean
```

---


### Bestimmen ob der Wert eine Primzahl ist

Die folgenden Funktionen geben True zurück wenn der Wert ein Primzahl ist.

```<vb>
 Short.IsPrime() As Boolean
 UShort.IsPrime() As Boolean
 Integer.IsPrime() As Boolean
 UInteger.IsPrime() As Boolean
 Long.IsPrime() As Boolean
```

---


### Bestimmen ob ein Wert durch einen angegebenen Wert ohne Rest teilbar ist

Die folgenden Funktionen geben True zurück wenn der Wert ohne Rest 
durch den angegebenen Wert teilbar ist.

```<vb>
 Short.IsDivisibleBy(Double) As Boolean
 UShort.IsDivisibleBy(Double) As Boolean
 Integer.IsDivisibleBy(Double) As Boolean
 UInteger.IsDivisibleBy(Double) As Boolean
 Long.IsDivisibleBy(Double) As Boolean
 ULong.IsDivisibleBy(Double) As Boolean
 Decimal.IsDivisibleBy(Double) As Boolean
 Single.IsDivisibleBy(Double) As Boolean
 Double.IsDivisibleBy(Double) As Boolean
```

---


### Bestimmen ob ein angegebener Wert ein vielfaches vom Wert ist

Die folgenden Funktionen geben True zurück wenn der angegebene Wert 
ein vielfaches vom Wert ist.

```<vb>
 Short.IsMultipleBOf(Double) As Boolean
 UShort.IsMultipleBOf(Double) As Boolean
 Integer.IsMultipleBOf(Double) As Boolean
 UInteger.IsMultipleBOf(Double) As Boolean
 Long.IsMultipleBOf(Double) As Boolean
 ULong.IsMultipleBOf(Double) As Boolean
 Decimal.IsMultipleBOf(Double) As Boolean
 Single.IsMultipleBOf(Double) As Boolean
 Double.IsMultipleBOf(Double) As Boolean
```

---


### Bestimmen ob ein Wert im Bereich von Minimum und Maximum liegt.

Die folgenden Funktionen geben True zurück wenn der Wert im Bereich
eines Minimalwertes und eines Maximalwertes liegt.

```<vb>
 Short.IsInRangeOf(Double, Double) As Boolean
 UShort.IsInRangeOf(Double, Double) As Boolean
 Integer.IsInRangeOf(Double, Double) As Boolean
 UInteger.IsInRangeOf(Double, Double) As Boolean
 Long.IsInRangeOf(Double, Double) As Boolean
 ULong.IsInRangeOf(Double, Double) As Boolean
 Decimal.IsInRangeOf(Double, Double) As Boolean
 Single.IsInRangeOf(Double, Double) As Boolean
 Double.IsInRangeOf(Double, Double) As Boolean
```

---


### Die Differenz zwischen dem Wert und einem angegebenen Wert bestimmen

Die folgenden Funktionen ermitteln die Differenz zwischen dem Wert und 
einem angegebenen Wert.

```<vb>
 Short.DifferenceOf(Double) As Double
 UShort.DifferenceOf(Double) As Double
 Integer.DifferenceOf(Double) As Double
 UInteger.DifferenceOf(Double) As Double
 Long.DifferenceOf(Double) As Double
 ULong.DifferenceOf(Double) As Double
 Decimal.DifferenceOf(Double) As Double
 Single.DifferenceOf(Double) As Double
 Double.DifferenceOf(Double) As Double
```

---


### Den Wert in die Hexadezimale Darstellung für Visual Basic konvertieren

Die folgenden Funktionen geben einen String zurück der die Headezimale Darstellung
des Wertes wiedergibt.

```<vb>
 Short.ToVBHex() As String
 UShort.ToVBHex() As String
 Integer.ToVBHex() As String
 UInteger.ToVBHex() As String
 Long.ToVBHex() As String
```

---

### Den Wert in die Hexadezimale Darstellung für C# konvertieren

Die folgenden Funktionen geben einen String zurück der die Headezimale Darstellung
des Wertes wiedergibt.

```<vb>
 Short.ToCSharpHex() As String
 UShort.ToCSharpHex() As String
 Integer.ToCSharpHex() As String
 UInteger.ToCSharpHex() As String
 Long.ToCSharpHex() As String
```

---


### Den Wert in Abhängigkeit von der Genauigkeit und der Kultur formatieren

Die folgenden Funktionen geben einen String zurück der den Wert in Abhängigkeit 
von der angegebenen Kultur mit einer angegebenen Genauigkeit der Dezimalstelle darstellt.

```<vb>
 Short.Formatted(Opt: Integer, Opt: CultureInfo) As String
 UShort.Formatted(Opt: Integer, Opt: CultureInfo) As String
 Integer.Formatted(Opt: Integer, Opt: CultureInfo) As String
 UInteger.Formatted(Opt: Integer, Opt: CultureInfo) As String
 Long.Formatted(Opt: Integer, Opt: CultureInfo) As String
 ULong.Formatted(Opt: Integer, Opt: CultureInfo) As String
 Decimal.Formatted(Opt: Integer, Opt: CultureInfo) As String
 Single.Formatted(Opt: Integer, Opt: CultureInfo) As String
 Double.Formatted(Opt: Integer, Opt: CultureInfo) As String
```

