''' <summary>
''' Rappresenta la funzione euristica che calcola la distanza tra 2 punti utilizzando l'algoritmo di Chebyshev
''' </summary>
Public NotInheritable Class DiagonalDistanceFunction
    Implements ICoordDistanceFunction

    ''' <summary>
    ''' Ottiene o imposta una istanza di DistanceFunction
    ''' </summary>
    Protected Shared DF As New DiagonalDistanceFunction
    ''' <summary>
    ''' Ottiene la funzione per il calcolo della distanza
    ''' </summary>
    ''' <value>La funzione per il calcolo della distanza</value>
    ''' <returns>La funzione per il calcolo della distanza</returns>
    Public Shared ReadOnly Property DistanceFunction As DiagonalDistanceFunction
        Get
            'restituisce DF
            Return DF
        End Get
    End Property

    ''' <summary>
    ''' Crea una nuova istanza di DiagonalDistanceFunction
    ''' </summary>
    Private Sub New()

    End Sub

    ''' <summary>
    ''' Calcola la distanza tra 1 e 2
    ''' </summary>
    ''' <param name="x1">Cordinata x del punto 1</param>
    ''' <param name="y1">Cordinata y del punto 1</param>
    ''' <param name="x2">Cordinata x del punto 2</param>
    ''' <param name="y2">Cordinata y del punto 2</param>
    ''' <param name="scale">Valore di scala</param>
    ''' <returns>Un valore che indica la distanza (euristica) tra punto 1 e 2</returns>
    Function GetDistance(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, Optional scale As Single = 1.0) As Single Implements ICoordDistanceFunction.GetDistance
        'restituisce la distanza di Chebyshev
        Return scale * Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2))
    End Function
    ''' <summary>
    ''' Calcola la distanza tra 1 e 2
    ''' </summary>
    ''' <param name="c1">Cordinata 1</param>
    ''' <param name="c2">Cordinata 2</param>
    ''' <param name="scale">Valore di scala</param>
    ''' <returns>Un valore che indica la distanza (euristica) tra punto 1 e 2</returns>
    Function GetDistance(c1 As ILocated, c2 As ILocated, Optional scale As Single = 1.0) As Single Implements ICoordDistanceFunction.GetDistance
        'restituisce la distanza di Chebyshev
        Return scale * Math.Max(Math.Abs(c1.GetX - c2.GetX), Math.Abs(c1.GetY - c2.GetY))
    End Function
End Class
