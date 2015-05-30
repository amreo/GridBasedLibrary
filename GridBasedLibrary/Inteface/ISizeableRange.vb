''' <summary>
''' Rappresenta un range i grado di modificare i propri limiti
''' </summary>
Public Interface ISizeableRange
    Inherits IRange

    ''' <summary>
    ''' Imposta il valore minimo
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Sub SetMin(value As Integer)
    ''' <summary>
    ''' Imposta il valore massimo
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Sub SetMax(value As Integer)
    ''' <summary>
    ''' Imposta il valore minimo e massimo
    ''' </summary>
    ''' <param name="min">Il valore minimo</param>
    ''' <param name="max">Il valore massimo</param>
    Sub [Set](min As Integer, max As Integer)
    ''' <summary>
    ''' Imposta il valore minimo e massimo
    ''' </summary>
    ''' <param name="range">Range</param>
    Sub [Set](range As IRange)

    ''' <summary>
    ''' Il range viene esteso in entrambi limiti di offset
    ''' </summary>
    ''' <param name="Offset">Dimensioni di estensioni</param>
    ''' <remarks>Viene esteso in entrambi i limiti in modo equo</remarks>
    ''' <exception cref="OverflowException">Quando Max+Offset/2 sono maggiori di <see cref="Integer.MaxValue">Integer.MaxValue</see>
    ''' oppure Min-offset/2 è minore di <see cref="Integer.MinValue">Integer.MinValue</see></exception>
    Sub Extend(Offset As Integer)
    ''' <summary>
    ''' Il range viene esteso in entrambi limiti di offset
    ''' </summary>
    ''' <param name="LimitMinOffset">Estensione al limite inferiore</param>
    ''' <param name="LimitMaxOffset">Estensione al limite superiore</param>
    ''' <exception cref="OverflowException">Quando Max+Offset/2 sono maggiori di <see cref="Integer.MaxValue">Integer.MaxValue</see>
    ''' oppure Min-offset/2 è minore di <see cref="Integer.MinValue">Integer.MinValue</see></exception>
    Sub Extend(LimitMinOffset As Integer, LimitMaxOffset As Integer)
End Interface
