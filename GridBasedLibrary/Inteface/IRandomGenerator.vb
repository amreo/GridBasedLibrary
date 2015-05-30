''' <summary>
''' Rappresenta l'interfaccia di base di un generatore di numeri casuali
''' </summary>
Public Interface IRandomGenerator

    ''' <summary>
    ''' Genera un numero intero casuale compreso tra 0 e int.maxvalue
    ''' </summary>
    ''' <returns>Intero casuale compreso tra 0 e int.maxvalue</returns>
    Function NextInt() As Integer
    ''' <summary>
    ''' Genera un numero intero casuale compreso tra 0 e Max
    ''' </summary>
    ''' <returns>Intero casuale compreso tra 0 e max</returns>
    Function NextInt(Max As Integer) As Integer
    ''' <summary>
    ''' Genera un numero intero casuale compreso tra Min e Max
    ''' </summary>
    ''' <returns>Intero casuale compreso tra Min e Max</returns>
    Function NextInt(Min As Integer, Max As Integer) As Integer


    ''' <summary>
    ''' Genera un numero single casuale compreso tra 0 e 1
    ''' </summary>
    ''' <returns>Single casuale compreso tra 0 e 1</returns>
    Function NextSingle() As Single
    ''' <summary>
    ''' Genera un numero double casuale compreso tra 0 e 1
    ''' </summary>
    ''' <returns>Double casuale compreso tra 0 e 1</returns>
    Function NextDouble() As Double

    ''' <summary>
    ''' Estrae un elemento casuale dalla lista
    ''' </summary>
    ''' <typeparam name="T">Tipo di elemento</typeparam>
    ''' <param name="coll">Collezione di origine</param>
    ''' <returns>Un elemento casuale</returns>
    Function NextItem(Of T)(ByVal coll As IEnumerable(Of T)) As T
    ' ''' <summary>
    ' ''' Estrae un elemento casuale dalla lista
    ' ''' </summary>
    ' ''' <param name="coll">Collezione di origine</param>
    ' ''' <returns>Un elemento casuale</returns>
    'Function NextItem(ByVal coll As IEnumerable) As Object


End Interface