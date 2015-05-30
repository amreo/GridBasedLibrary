''' <summary>
''' Rappresenta un interfaccia per un range
''' </summary>
Public Interface IRange

    ''' <summary>
    ''' Ottiene il valore minimo
    ''' </summary>
    ''' <returns>Il valore minimo</returns>
    Function GetMin() As Integer
    ''' <summary>
    ''' Ottiene il valore massimo
    ''' </summary>
    ''' <returns>Il valore massimo</returns>
    Function GetMax() As Integer
    ''' <summary>
    ''' Ottiene la dimensione del range
    ''' </summary>
    ''' <returns>Dimensioni del range</returns>
    ''' <remarks>Max-Min+1</remarks>
    Function GetSize() As UInteger
    ''' <summary>
    ''' Ottiene il range
    ''' </summary>
    ''' <returns>Il range</returns>
    ''' <remarks>I tipo di valore restituito può variare a seconda dell' implementazione</remarks>
    Function GetRange() As IRange

    ''' <summary>
    ''' Verifica che il valore è compreso nel range
    ''' </summary>
    ''' <param name="value">Valore da verificare</param>
    ''' <returns>True se è compreso, altrimenti false</returns>
    Function CheckValue(value As Integer) As Boolean


End Interface
