''' <summary>
''' Rappresenta un comparatore radiale
''' </summary>
Public NotInheritable Class RadialCoordComparer
    Implements IComparer(Of ILocated)

    ''' <summary>
    ''' Ottiene o imposta il valore di scala da usare nelle comparazioni
    ''' </summary>
    Protected scale As Single
    ''' <summary>
    ''' Ottiene o imposta il punto centrale da usare nelle comparazioni
    ''' </summary>
    Protected centerCoord As Coord
    ''' <summary>
    ''' Funzione che calcola la distanza
    ''' </summary>
    Protected distanceFunction As ICoordDistanceFunction

    ''' <summary>
    ''' Crea una nuova istanza di RadialCoordComparer
    ''' </summary>
    ''' <param name="centerCoord">Punto centrale</param>
    ''' <param name="scale">Valore di scala da usare</param>
    ''' <param name="distanceFunction">Funzione per il calcolo della distanza</param>
    ''' <remarks>Usare un valore di scala negativo per ottenere i punti comparati dal più lontani ai più vicini di centerCoord</remarks>
    Public Sub New(centerCoord As Coord, distanceFunction As ICoordDistanceFunction, Optional scale As Single = 1.0)
        'imposta i parametri
        Me.centerCoord = centerCoord
        Me.distanceFunction = distanceFunction
        Me.scale = scale
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di RadialCoordComparer
    ''' </summary>
    ''' <param name="centerCoord">Punto centrale</param>
    ''' <param name="scale">Valore di scala da usare</param>
    ''' <param name="distanceFunction">Funzione per il calcolo della distanza</param>
    ''' <remarks>Usare un valore di scala negativo per ottenere i punti comparati dal più lontani ai più vicini di centerCoord</remarks>
    Public Sub New(centerCoord As ILocated, distanceFunction As ICoordDistanceFunction, Optional scale As Single = 1.0)
        'imposta i parametri
        Me.centerCoord = centerCoord.GetLocation
        Me.distanceFunction = distanceFunction
        Me.scale = scale
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di RadialCoordComparer
    ''' </summary>
    ''' <param name="centerCoordX">Cordinata x del punto centrale</param>
    ''' <param name="centerCoordY">Cordinata y del punto centrale</param>
    ''' <param name="scale">Valore di scala da usare</param>
    ''' <param name="distanceFunction">Funzione per il calcolo della distanza</param>
    ''' <remarks>Usare un valore di scala negativo per ottenere i punti comparati dal più lontani ai più vicini di centerCoord</remarks>
    Public Sub New(centerCoordX As Integer, centerCoordY As Integer, distanceFunction As ICoordDistanceFunction, Optional scale As Single = 1.0)
        'imposta i parametri
        Me.centerCoord = New Coord(centerCoordX, centerCoordY)
        Me.distanceFunction = distanceFunction
        Me.scale = scale
    End Sub

    ''' <summary>
    ''' Restituisce il punto centrale
    ''' </summary>
    ''' <returns>Il punto centrale</returns>
    Public Function GetCenterCoord() As Coord
        'restituisce la cordinata centrale
        Return centerCoord
    End Function
    ''' <summary>
    ''' Restituisce la funzione per il calcolo della distanza
    ''' </summary>
    ''' <returns>La funzione per il calcolo della distanza</returns>
    Public Function GetDistanceFunction() As ICoordDistanceFunction
        'restituisce la DistanceFunction
        Return distanceFunction
    End Function
    ''' <summary>
    ''' Restituisce il valore di scala per la DistanceFunction
    ''' </summary>
    ''' <returns>Il valore di scala</returns>
    Public Function GetScale() As Single
        'restituisce il valore di scala
        Return scale
    End Function

    ''' <summary>
    ''' Imposta il punto centrale
    ''' </summary>
    ''' <param name="value">Cordinata da usare</param>
    Public Sub SetCenterCoord(value As Coord)
        'imposta il valore
        Me.centerCoord = value
    End Sub
    ''' <summary>
    ''' Imposta la funzione per la distanza
    ''' </summary>
    ''' <param name="value">DistanceFunction da usare</param>
    Public Sub SetDistanceFunction(value As ICoordDistanceFunction)
        'imposta il valore
        Me.distanceFunction = value
    End Sub
    ''' <summary>
    ''' Imposta il valore di scala
    ''' </summary>
    ''' <param name="value">Valore di scala da usare</param>
    Public Sub SetScale(value As Single)
        'imposta il valore
        Me.scale = value
    End Sub

    ''' <summary>
    ''' Compara 2 cordinate 
    ''' </summary>
    ''' <param name="c1">Cordinata X</param>
    ''' <param name="c2">Cordinata Y</param>
    ''' <returns>Maggiore di 1 se x viene prima di y, 0 se sono allo stesso livello, altrimenti minore di 1 se y viene prima di x</returns>
    Public Function Compare(c1 As ILocated, c2 As ILocated) As Integer Implements System.Collections.Generic.IComparer(Of ILocated).Compare
        'calcola distanza di c1 e c2
        Dim dC1 As Single = distanceFunction.GetDistance(c1, centerCoord, scale)
        Dim dC2 As Single = distanceFunction.GetDistance(c2, centerCoord, scale)
        'verifica il loro rapporto e restituisce il risultato
        If dC1 < dC2 Then
            Return -1
        ElseIf dC1 > dC2 Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Class
