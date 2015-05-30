''' <summary>
''' Rappresenta un range in grado di essere ridimensionato
''' </summary>
Public Class SizeableRange
    Inherits StaticRange
    Implements ISizeableRange

    ''' <summary>
    ''' Crea una nuova istanza di Range
    ''' </summary>
    ''' <param name="Min">Valore minimo</param>
    ''' <param name="Max">Valore massimo</param>
    Public Sub New(Min As Integer, Max As Integer)
        'istanzia se stesso
        MyBase.New(Min, Max)
    End Sub

    ''' <summary>
    ''' Imposta il valore minimo
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Overridable Sub SetMin(value As Integer) Implements ISizeableRange.SetMin
        'imposta il minimo
        Me.Min = value
        'controlla min e max
        Check()
    End Sub
    ''' <summary>
    ''' Imposta il valore massimo
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Overridable Sub SetMax(value As Integer) Implements ISizeableRange.SetMax
        'imposta il minimo
        Me.Max = value
        'controlla min e max
        Check()
    End Sub
    ''' <summary>
    ''' Imposta il valore minimo e massimo
    ''' </summary>
    ''' <param name="min">Il valore minimo</param>
    ''' <param name="max">Il valore massimo</param>
    Overridable Sub [Set](min As Integer, max As Integer) Implements ISizeableRange.Set
        'imposta il minimo
        Me.Min = min
        Me.Max = max
        'controlla min e max
        Check()
    End Sub
    ''' <summary>
    ''' Imposta il valore minimo e massimo
    ''' </summary>
    ''' <param name="range">Range</param>
    Overridable Sub [Set](range As IRange) Implements ISizeableRange.Set
        'imposta il minimo
        Me.Min = range.GetMin
        Me.Max = range.GetMax
    End Sub

    ''' <summary>
    ''' Il range viene esteso in entrambi limiti di offset
    ''' </summary>
    ''' <param name="Offset">Dimensioni di estensioni</param>
    ''' <remarks>Viene esteso in entrambi i limiti in modo equo</remarks>
    ''' <exception cref="OverflowException">Quando Max+Offset/2 sono maggiori di <see cref="Integer.MaxValue">Integer.MaxValue</see>
    ''' oppure Min-offset/2 è minore di <see cref="Integer.MinValue">Integer.MinValue</see></exception>
    Overridable Sub Extend(Offset As Integer) Implements ISizeableRange.Extend
        'verifica l'offset per evitare che dopo x gli offset negativi aumentano le dimensioni
        'Spiegazione Offset > Max
        'Condizione originaria : Min + Offset/2 > (Max+Min)/2
        '                     => 2Min + Offset > Max+Min
        '                     => Min + Offset > Max
        If Min - Offset > Max Then Offset = Min - Max
        'ricalcola min e max
        Min = Min - Offset / 2
        Max = Max + Offset / 2
        'controlla i valori
        Check()
    End Sub
    ''' <summary>
    ''' Il range viene esteso in entrambi limiti di offset
    ''' </summary>
    ''' <param name="LimitMinOffset">Estensione al limite inferiore</param>
    ''' <param name="LimitMaxOffset">Estensione al limite superiore</param>
    ''' <exception cref="OverflowException">Quando Max+Offset/2 sono maggiori di <see cref="Integer.MaxValue">Integer.MaxValue</see>
    ''' oppure Min-offset/2 è minore di <see cref="Integer.MinValue">Integer.MinValue</see></exception>
    Overridable Sub Extend(LimitMinOffset As Integer, LimitMaxOffset As Integer) Implements ISizeableRange.Extend
        'Verifica che nel caso che nel caso che -(LimitMinOffset+LimitMaxOffset) siano > di Max-Min
        If LimitMaxOffset + LimitMinOffset > Min - Max Then
            'imposta ai offset la metà di (Min-Max)/2
            LimitMinOffset = (Min - Max) / 2
            LimitMaxOffset = LimitMinOffset
        End If
        'ricalcola min e max
        Min = Min - LimitMinOffset
        Max = Max + LimitMaxOffset
        'controlla i valori
        Check()
    End Sub
End Class
