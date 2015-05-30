''' <summary>
''' Rappresenta un generatore di numeri casuali che utilizza l'algoritmo della class System.Random
''' </summary>
''' <remarks></remarks>
Public Class MSRandomGenerator
    Inherits Random
    Implements IRandomGenerator


    ''' <summary>
    ''' Genera un numero intero casuale compreso tra 0 e int.maxvalue
    ''' </summary>
    ''' <returns>Intero casuale compreso tra 0 e int.maxvalue</returns>
    Public Function NextInt() As Integer Implements IRandomGenerator.NextInt
        Return MyBase.Next()
    End Function
    ''' <summary>
    ''' Genera un numero intero casuale compreso tra 0 e Max
    ''' </summary>
    ''' <returns>Intero casuale compreso tra 0 e max</returns>
    Public Function NextInt(Max As Integer) As Integer Implements IRandomGenerator.NextInt
        Return MyBase.Next(Max)
    End Function
    ''' <summary>
    ''' Genera un numero intero casuale compreso tra Min e Max
    ''' </summary>
    ''' <returns>Intero casuale compreso tra Min e Max</returns>
    Public Function NextInt(Min As Integer, Max As Integer) As Integer Implements IRandomGenerator.NextInt
        Return MyBase.Next(Min, Max)
    End Function

    ''' <summary>
    ''' Genera un numero single casuale compreso tra 0 e 1
    ''' </summary>
    ''' <returns>Single casuale compreso tra 0 e 1</returns>
    Public Function NextSingle() As Single Implements IRandomGenerator.NextSingle
        Return MyBase.NextDouble
    End Function
    ''' <summary>
    ''' Genera un numero double casuale compreso tra 0 e 1
    ''' </summary>
    ''' <returns>Double casuale compreso tra 0 e 1</returns>
    Public Overrides Function NextDouble() As Double Implements IRandomGenerator.NextDouble
        Return MyBase.NextDouble()
    End Function

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
