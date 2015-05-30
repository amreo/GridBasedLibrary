''' <summary>
''' Rappresenta un generatore di numeri casuali
''' </summary>
Public MustInherit Class RandomGenerator
    Implements IRandomGenerator

    ''' <summary>
    ''' Genera un numero intero casuale compreso tra 0 e int.maxvalue
    ''' </summary>
    ''' <returns>Intero casuale compreso tra 0 e int.maxvalue</returns>
    Public MustOverride Function NextInt() As Integer Implements IRandomGenerator.NextInt
    ''' <summary>
    ''' Genera un numero intero casuale compreso tra 0 e Max
    ''' </summary>
    ''' <returns>Intero casuale compreso tra 0 e max</returns>
    Public MustOverride Function NextInt(Max As Integer) As Integer Implements IRandomGenerator.NextInt
    ''' <summary>
    ''' Genera un numero intero casuale compreso tra Min e Max
    ''' </summary>
    ''' <returns>Intero casuale compreso tra Min e Max</returns>
    Public MustOverride Function NextInt(Min As Integer, Max As Integer) As Integer Implements IRandomGenerator.NextInt


    ''' <summary>
    ''' Genera un numero single casuale compreso tra 0 e 1
    ''' </summary>
    ''' <returns>Single casuale compreso tra 0 e 1</returns>
    Public MustOverride Function NextSingle() As Single Implements IRandomGenerator.NextSingle
    ''' <summary>
    ''' Genera un numero double casuale compreso tra 0 e 1
    ''' </summary>
    ''' <returns>Double casuale compreso tra 0 e 1</returns>
    Public MustOverride Function NextDouble() As Double Implements IRandomGenerator.NextDouble

    ''' <summary>
    ''' Estrae un elemento casuale dalla lista
    ''' </summary>
    ''' <typeparam name="T">Tipo di elemento</typeparam>
    ''' <param name="coll">Collezione di origine</param>
    ''' <returns>Un elemento casuale</returns>
    Public Overridable Function NextItem(Of T)(ByVal coll As IEnumerable(Of T)) As T Implements IRandomGenerator.NextItem
        'restituisce un elemento casuale
        Return coll(NextInt(coll.Count))
    End Function
End Class
